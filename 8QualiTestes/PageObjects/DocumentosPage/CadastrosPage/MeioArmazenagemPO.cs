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
    public class MeioArmazenagemPO : BasePage
    {
        

        public MeioArmazenagemPO acessarTelaMeioArmazenagem()
        {
            acessarTela("https://app.8quali.com.br/GestaoDocumento/MeioArmazenamentoDocumentoRegistro");
            return this;
        }

        public void clicarBotaoAdicionarMeioArmazenagem()
        {
            clicarBotao("novo");
        }

        public void clicarBotaoSalvarMeioArmazenagem()
        {
            clicarBotao("botao-salvar-modal");
        }

        public void preencheMeioArmazenagem(string descricao)
        {

            clicarBotaoAdicionarMeioArmazenagem();
            aguarda_EscreveInputPagina(By.Id("Descricao"), descricao);
            escrever("Descricao", descricao);
            clicarBotaoSalvarMeioArmazenagem();
        }

        internal void aguardaMensagemObrigatoria()
        {
            aguarda_ElementoPagina(By.XPath("//*[@id='FormCadastroMeioArmazenamentoDocumentoRegistro']//span[@class='field-validation-error']"));
        }

        public string obterMensagemDescricaoObrigatoria()
        {
            return obterTexto(By.XPath("//*[@id='FormCadastroMeioArmazenamentoDocumentoRegistro']//span[@class='field-validation-error']"));
        }

        public void aguardaDocumentoGrid(string descricao)
        {
            aguarda_ElementoPagina(By.XPath("//*[@title='"+ descricao +"']"));
        }

        public string GetMensagemSalvoComSucesso()
        {
            return obterTexto("alertaSalvo");
        }

        public void AguardaMensagemSalvoComSucesso()
        {
            aguarda_ElementoPagina("alertaSalvo");
        }


        internal void aguardaInputDescricao(string descricao)
        {
            aguarda_EscreveInputPagina(By.Id("Descricao"), descricao);
        }

        internal void aguardaJanelaExclusao()
        {
            aguarda_BotaoVisivel(By.Id("Confirmar"));
        }

        public void clicarExcluirMeio(string dados)
        {
            obterCelula("Descrição", dados, "Excluir", "sortabledoc")
                .FindElement(By.XPath(".//button[@class='btn ui-state-default ui-corner-all btn-executar']")).Click();

        }
        public void clicarAlterarMeio(string dados)

        {
            obterCelula("Descrição", dados, "Excluir", "sortabledoc")
                .FindElement(By.XPath("//*[@title='Alteração Meio Armazenagem']")).Click();
        }

    }
}
