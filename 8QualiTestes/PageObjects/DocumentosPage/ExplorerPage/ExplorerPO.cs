using _8QualiTestes.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace _8QualiTestes.PageObjects.Documentos.Explorer
{
    public class ExplorerPO : BasePage
    {

        public ExplorerPO acessarTelaExplorer()
        {
            acessarTela("https://app.8quali.com.br/GestaoDocumento/Explorer");
            aguarda_UrlPagina("https://app.8quali.com.br/GestaoDocumento/Explorer");
            return this;
        }


        public void clicarPastaSetor(string Setor)
        {
            aguarda_ElementoPagina(By.XPath("//span[.='" + Setor + "']"));
            clicarDuasVezesBotao(By.XPath("//span[.='" + Setor + "']"));
        }

        public void clicarPastaProcesso(string Processo)
        {
            aguarda_ElementoPagina(By.XPath("//span[.='" + Processo + "']"));
            clicarDuasVezesBotao(By.XPath("//span[.='" + Processo + "']"));
        }

        public void clicarDocumento(string descricaoDocumento)
        {
            clicarBotao(By.XPath("//span[.='" + descricaoDocumento + "']")); 

        }

        public void clicarBotaoVisualizar()
        {
            clicarBotao(By.XPath(".//span[@title='Visualizar']"));
        }

        public void clicarBotaoBaixar()
        {
            aguarda_BotaoClicavel(By.XPath(".//span[@title='Baixar']"));
        }

        public void clicarBotaoImprimir()
        {

            aguarda_BotaoClicavel(By.XPath(".//span[@title='Imprimir']"));
            //getDriver().Close();
        }


        public void clicarVisualizar(string pasta, string documento)
        {
            
            clicarPastaSetor(pasta);
            clicarDocumento(documento);
            clicarBotaoVisualizar();
        }

        public void clicarBaixar(string pasta, string documento)
        {
            
            clicarPastaSetor(pasta);
            clicarDocumento(documento);
            clicarBotaoBaixar();
        }

        public void clicarImprimir(string pasta, string documento)
        {
           
            clicarPastaSetor(pasta);
            clicarDocumento(documento);
            clicarBotaoImprimir();
        }


    }
}
