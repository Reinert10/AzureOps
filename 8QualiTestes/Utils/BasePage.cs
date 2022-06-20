
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace _8QualiTestes.Helpers;
public class BasePage : DriverFactory
{




    public string retornaDataAtual()
    {
        DateTime dataAnexo = DateTime.Now;
        return dataAnexo.ToString("dd/MM/yyyy");

    }

    public void acessarTela(string url)
    {
        getDriver().Manage().Window.Maximize();
        getDriver().Navigate().GoToUrl(url);
    }

    public void escrever(By by, string texto)
    {
        getDriver().FindElement(by).Clear();
        getDriver().FindElement(by).SendKeys(texto);
    }

    public void escrever(string id_campo, string texto)
    {
        escrever(By.Id(id_campo), texto);
    }

    public string obterTexto(By by)
    {
        return getDriver().FindElement(by).Text;
    }


    public string obterTexto(string id)
    {
        return getDriver().FindElement(By.Id(id)).Text;
    }

    public void clicarBotao(string id)
    {
        clicarBotao(By.Id(id));
    }

    public void clicarBotao(By by)
    {
        getDriver().FindElement(by).Click();
    }


    public void clicarDuasVezesBotao(By by)
    {
        Actions act = new Actions(getDriver());
        act.DoubleClick(driver.FindElement((by))).Build().Perform();
    }

    public void clicarDuasVezesBotao(string id)
    {
        clicarDuasVezesBotao(By.Id(id));
    }

    public void selecionarCombo(By by, string valor)
    {

        IWebElement element = getDriver().FindElement(by);
        SelectElement combo = new SelectElement(element);
        if (valor == "")
        {
            combo.SelectByValue("");
        }
        else
        {
            combo.SelectByText(valor);
        }
    }

    public void selecionarCombo(string id_campo, string valor)
    {

        selecionarCombo(By.Id(id_campo), valor);

    }


    public void limpaCampo(string id)
    {
        getDriver().FindElement(By.XPath(id)).Clear();
    }


    public void aguarda_EscreveInputPagina(By by, string valor)
    {

        WebDriverWait wait = new WebDriverWait(getDriver(), TimeSpan.FromSeconds(10));
        IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
        getDriver().FindElement(by).Clear();
        element.SendKeys(valor);
    }

    public void aguarda_EscreveInputPagina(string id, string valor)
    {

        aguarda_EscreveInputPagina(By.Id(id), valor);

    }


    public void aguarda_BotaoClicavel(By by)
    {

        WebDriverWait wait = new WebDriverWait(getDriver(), TimeSpan.FromSeconds(15));
        IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(by));
        element.Click();
    }

    public void aguarda_BotaoClicavel(String id)
    {

        aguarda_BotaoClicavel(By.Id(id));

    }

    public void aguarda_BotaoVisivel(By by)
    {

        WebDriverWait wait = new WebDriverWait(getDriver(), TimeSpan.FromSeconds(15));
        IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(by));
        element.Click();
    }

    public void aguarda_BotaoVisivel(String id)
    {

        aguarda_BotaoClicavel(By.Id(id));

    }


    public void aguarda_ElementoPagina(By by)
    {

        WebDriverWait wait = new WebDriverWait(getDriver(), TimeSpan.FromSeconds(20));
        wait.Until(ExpectedConditions.ElementIsVisible(by));

    }

    public void aguarda_ElementoPagina(string id)
    {

        aguarda_ElementoPagina(By.Id(id));

    }


    public void clicarLink(string id)
    {
        getDriver().FindElement(By.LinkText(id)).Click();
    }


    public void aguarda_UrlPagina(string url)
    {

        WebDriverWait wait = new WebDriverWait(getDriver(), TimeSpan.FromSeconds(15));
        wait.Until(ExpectedConditions.UrlContains(url));

    }

    public void aguarda_UrlContem(string url)
    {

        WebDriverWait wait = new WebDriverWait(getDriver(), TimeSpan.FromSeconds(15));
        wait.Until(ExpectedConditions.UrlContains(url));

    }

    /************ Tabela ******************/

    public IWebElement obterCelula(string colunaBusca, string valor, string colunaBotao, string idTabela)
    {

        // procurar coluna do registro
        IWebElement tabela = getDriver().FindElement(By.XPath("//*[@id='" + idTabela + "']"));
        int idColuna = obterIndiceColuna(colunaBusca, tabela);

        // encontrar a linha do registro
        int idLinha = obterIndiceLinha(valor, tabela, idColuna);

        // procurar coluna do botão
        int idColunaBotao = obterIndiceColuna(colunaBotao, tabela);

        // clica botão encontrado na tabela
        IWebElement celula = tabela.FindElement(By.XPath(".//tr[" + idLinha + "]/td[" + idColunaBotao + "]"));
        return celula;

    }

    private int obterIndiceLinha(string valor, IWebElement tabela, int idColuna)
    {
        IList<IWebElement> linhas = tabela.FindElements(By.XPath("./tbody/tr/td[" + idColuna + "]"));
        int idLinha = -1;
        for (int i = 0; i < linhas.Count(); i++)
        {

            if (linhas.ElementAt(i).Text.Equals(valor))
            {
                idLinha = i + 2;
                break;

            }

        }

        return idLinha;
    }

    private int obterIndiceColuna(string coluna, IWebElement tabela)
    {
        IList<IWebElement> colunas = tabela.FindElements(By.XPath(".//th"));
        int idColuna = -1;
        for (int i = 0; i < colunas.Count(); i++)
        {
            if (colunas.ElementAt(i).Text.Equals(coluna))
            {
                idColuna = i + 1;
                break;
            }
        }
        return idColuna;

    }

    public void rodarMouse(By by)
    {
        IWebElement element = getDriver().FindElement(by);
        ((IJavaScriptExecutor)getDriver()).ExecuteScript("arguments[0].scrollIntoView();", element);
    }


    public void rodarMouse(string id)
    {

        rodarMouse(By.Id(id));

    }


    public void anexarArquivo(string id, string valor)
    {
        IWebElement addFile = getDriver().FindElement(By.Id(id));
        addFile.SendKeys(valor);


    }


    public void TrocarJanelaAtual()
    {

        string originalWindow = getDriver().CurrentWindowHandle;

        foreach (string window in getDriver().WindowHandles)
        {
            if (originalWindow != window)
            {
                getDriver().SwitchTo().Window(window);
                break;
            }
        }

    }

    public void entrarFrame(string id)
    {
        aguarda_ElementoPagina(By.CssSelector(".cboxIframe"));
        IWebElement iframe = driver.FindElement(By.CssSelector(id));
        getDriver().SwitchTo().Frame(iframe);


    }

    public void sairFrame()
    {
        getDriver().SwitchTo().DefaultContent();
    }

}
