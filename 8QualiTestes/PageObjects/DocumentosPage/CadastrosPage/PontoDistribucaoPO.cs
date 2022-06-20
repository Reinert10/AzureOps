using _8QualiTestes.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _8QualiTestes.PageObjects.Documentos_Internos.Cadastros
{
    public class PontoDistribucaoPO : BasePage
    {

        public PontoDistribucaoPO acessoTelaPontoDeDistribuicao()
        {
            acessarTela("https://app.8quali.com.br/GestaoDocumento/PontoDistribuicao");
            return this;
        }

        public void aguardaJanelaExclusao()
        {
            aguarda_BotaoVisivel(By.Id("Confirmar"));
        }

        public void aguardaInputDescricao(string descricao)
        {
            aguarda_EscreveInputPagina(By.Id("Descricao"), descricao);
        }



        public void clicarBotaoAdicionarPontoDeDistribuicao()
        {
            clicarBotao("novo");
        }

        public void clicarBotaoSalvarPonto()
        {
            clicarBotao("botao-salvar-modal");
        }


        public void preenchePontoDistribuicao(string descricao)
        {

            clicarBotaoAdicionarPontoDeDistribuicao();
            aguarda_EscreveInputPagina(By.Id("Descricao"), descricao);
            clicarBotaoSalvarPonto();

        }

        public void aguardaTituloDocumentoGrid(string tituloTabela)
        {
            aguarda_ElementoPagina(By.XPath("//*[@title='" + tituloTabela + "']"));
        }


        public string obterMensagemDescricaoObrigatoria()
        {
            return obterTexto(By.XPath("//*[@id='FormCadastro']//span"));
        }

        public string obterMensagemDescricaoJaCadastrada()
        {
            return obterTexto(By.XPath("//*[@id='FormCadastro']//span"));
        }

        public void aguarda_MensagemDescricaoJaCadastrada()
        {
            aguarda_ElementoPagina(By.XPath("//*[@id='FormCadastro']//span[@class='field-validation-error']"));
        }

       

        public void aguarda_MensagemDescricaoObrigatoria()
        {
            aguarda_ElementoPagina(By.XPath("//*[@id='FormCadastro']//span[@class='field-validation-error']"));
        }

        public void clicarAlterarLocal(string dados)

        {
            obterCelula("Descrição", dados, "Excluir", "sortabledoc")
                .FindElement(By.XPath("//*[@title='Alteração Ponto de Distribuição']")).Click();
        }

        public void clicarExcluirPonto(string dados)
        {
            obterCelula("Descrição", dados, "Excluir", "sortabledoc")
                .FindElement(By.XPath("./button")).Click();

        }

        public string GetMensagemSalvoComSucesso()
        {
            return obterTexto("alertaSalvo");
        }

        public void AguardaMensagemSalvoComSucesso()
        {
            aguarda_ElementoPagina("alertaSalvo");
        }

    }
}
