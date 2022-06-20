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
    public class LocalArmazenagemPO : BasePage
    {

        public LocalArmazenagemPO acessarTelaLocalArmazenagem()
        {
            acessarTela("https://app.8quali.com.br/GestaoDocumento/ArmazenamentoDocumentoRegistro");
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

        public void clicarBotaoAdicionarLocalArmazenagem()
        {
            clicarBotao("novo");
        }

        public void clicarBotaoSalvarLocalArmazenagem()
        {
            clicarBotao("botao-salvar-modal");
        }

        public void clicarBotaoConfirmarExclusao()
        {
            clicarBotao("Confirmar");
        }

        public void preencheLocalArmazenagem(string descricao)
        {

            clicarBotaoAdicionarLocalArmazenagem();
            aguarda_EscreveInputPagina(By.Id("Descricao"), descricao);
            escrever("Descricao", descricao);
            clicarBotaoSalvarLocalArmazenagem();
           
        }

        public void aguardaDocumentoGrid(string descricao)
        {
            aguarda_ElementoPagina(By.XPath("//*[@title='" + descricao + "']"));
        }

        public string GetMensagemSalvoComSucesso()
        {
            return obterTexto("alertaSalvo");
        }

        public void AguardaMensagemSalvoComSucesso()
        {
            aguarda_ElementoPagina("alertaSalvo");
        }



        public void setDescricao(string descricao)
        {
            escrever("Descricao", descricao);
        }

        public string obterMensagemDescricaoObrigatoria()
        {
            return obterTexto(By.XPath("//*[@id='FormCadastroArmazenamentoDocumentoRegistro']//span[@class='field-validation-error']"));
        }

        public void aguardaMensagemObrigatoria()
        {
            aguarda_ElementoPagina(By.XPath("//*[@id='FormCadastroArmazenamentoDocumentoRegistro']//span[@class='field-validation-error']"));
        }


        public void clicarExcluirLocal(string dados)
        {
            obterCelula("Descrição", dados, "Excluir", "sortabledoc").FindElement(By.XPath(".//button")).Click();

        }
        public void clicarAlterarLocal(string dados)

        {
            obterCelula("Descrição", dados, "Excluir", "sortabledoc")
                .FindElement(By.XPath("//*[@title='Alteração Local Armazenagem']")).Click();
        }
    }

}




