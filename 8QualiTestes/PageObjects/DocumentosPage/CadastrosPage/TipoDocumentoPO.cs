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
    public class TipoDocumentoPO : BasePage
    {
       

        public TipoDocumentoPO acessarTelaTipoDocumentos()
        {
            acessarTela("https://app.8quali.com.br/GestaoDocumento/TipoDocumento");
            return this;
        }

        public void clicarBotaoAdicionarTipoDocumento()
        {
            aguarda_BotaoClicavel("AdicionarTipoDocumento");
        }

        public void clicarBotaoSalvarTipoDocumento()
        {
            clicarBotao("btn-salvar-gestaodocumento");
        }

        public void clicarBotaoCancelar()
        {
            clicarBotao("btn-cancelar-gestaodocumento");
        }

      

        internal void aguardaJanelaExclusao()
        {
            aguarda_BotaoVisivel(By.Id("Confirmar"));
        }

        public void PreencherTipoDocumento(
            string descricao,
            string sigla,
            string casasDecimais,
            string tipoFormatacao)
        {
            //clicarBotaoAdicionarTipoDocumento();
            aguarda_EscreveInputPagina("Descricao", descricao);
            escrever("Sigla", sigla);
            escrever("QuantidadeCasasDecimais", casasDecimais);
            selecionarCombo("TipoFormatacaoCodigo", tipoFormatacao);
            
            


        }

        public string GetMensagemSalvoComSucesso()
        {
            return obterTexto("alertaSalvo");
        }

        public void AguardaMensagemSalvoComSucesso()
        {
            aguarda_ElementoPagina("alertaSalvo");
        }

        internal void clicarAlterarLocal(string dados)
        {
            obterCelula("Tipo de documento", dados, "Editar", "sortabledoc")
                .FindElement(By.XPath("./button")).Click();
        }

        internal void clicarExcluirTipo(string dados)
        {
            obterCelula("Tipo de documento", dados, "Excluir", "sortabledoc")
                .FindElement(By.XPath("./button")).Click();
        }

        public void aguardaTipoDocumentoGrid()
        {
            aguarda_ElementoPagina(By.XPath("//*[@title='Tipo Documento Alterado']"));
        }

        public string obterMensagemTipoObrigatorio()
        {
            return obterTexto(By.XPath("//span[.='O campo Tipo de Documento é obrigatório!']"));
        }

        public string obterMensagemTipoJaCadastrado()
        {
            return obterTexto(By.XPath("//span[.='Tipo de Documento já cadastrado!']"));
        }

        public void aguardaMensagemTipoObrigatorio()
        {
            aguarda_ElementoPagina(By.XPath("//span[.='O campo Tipo de Documento é obrigatório!']"));
        }

        public void aguardaMensagemTipoJaCadastrado()
        {
            aguarda_ElementoPagina(By.XPath("//span[.='Tipo de Documento já cadastrado!']"));
        }

        public void aguardaTituloDocumentoGrid(string tituloTabela)
        {
            aguarda_ElementoPagina(By.XPath("//*[@title='" + tituloTabela + "']"));
        }

    }
}


