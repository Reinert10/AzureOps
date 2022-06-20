using _8QualiTestes.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _8QualiTestes.PageObjects.Documentos.Internos
{
    public class DocumentosInternosPO : BasePage
    {


        public DocumentosInternosPO acessarTelaDocumentosInternos()
        {
            acessarTela("https://app.8quali.com.br/GestaoDocumento/Documento");
            return this;
        }

        public void clicarBotaoNovoDocumentoInterno()
        {
            clicarBotao("novo");
        }

        public void enviarArquivoElaboracao(string valor)
        {
            anexarArquivo("uploadBtn", valor);

        }

        public string descricaoArquivo(string valor)
        {

            string folder = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(folder, @"Utils\Files\" + valor + "");

        }

        public void clicarBotaoSalvarDocumentoInterno()
        {
            aguarda_BotaoClicavel("botao-salvar-modal");
        }

        public void clicarBotaoFinalizarElaboracao()
        {
            aguarda_BotaoClicavel("botao-finalizar-modal");
        }

        public void clicarBotaoAprovarConsenso()
        {
            clicarBotao("botao-finalizar-modal");
        }

        public string getMensagemSalvoComSucesso()
        {
            return obterTexto("alertaSalvo");
        }

        public void aguardaMensagemSalvoComSucesso()
        {
            aguarda_ElementoPagina("alertaSalvo");
        }

        public void preencherDocumentoInterno(string tipoDocumento, string titulo, string numeroRevisao, string dataEmissao,
            string unidade, string setor, string processo, string tipoValidade)
        {
            aguarda_ElementoPagina("TipoDocumentoId");
            selecionarCombo("TipoDocumentoId", tipoDocumento);
            escrever("Titulo", titulo);
            escrever("NumeroDaRevisao", numeroRevisao);
            escrever("DataEmissao", dataEmissao);
            selecionarUnidade(unidade);
            selecionarCombo("ProcessoId", setor);
            selecionarCombo("SetorId", processo);
            selecionarCombo("TipoValidade", tipoValidade);

        }

        public void setTitulo(string titulo)
        {
            aguarda_EscreveInputPagina("Titulo", titulo);
        }

        public void setTipoDocumento(string tipoDocumento)
        {
            aguarda_ElementoPagina("TipoDocumentoId");
            selecionarCombo("TipoDocumentoId", tipoDocumento);
        }

        public void clicarBotaoConfirmaExclusao()
        {
            aguarda_BotaoVisivel("Confirmar");
        }

        public void clicarDocumentoGrid()
        {
            aguarda_BotaoClicavel(By.XPath("//*[@title='Cadastro Documento Interno Valido']"));
        }

        public void aguardaDocumentoGrid()
        {
            aguarda_ElementoPagina(By.XPath("//*[@title='Cadastro Documento Interno Valido']"));
        }

        public void clicarBotaoFiltrar()
        {
            aguarda_BotaoClicavel(By.XPath("//*[@id='div_filtro01']//button[1]"));
        }

        public void clicarDocumentoTabela()
        {
            IWebElement button1 = getDriver().FindElement(By.XPath("//td[normalize-space(text())='Cadastro Documento Interno Valido']"));
            button1.Click();
        }

        public void clicarAprovarConsenso()
        {
            aguarda_BotaoClicavel(By.XPath("/html/body/div[15]/div[11]//button[@id='botao-finalizar-modal'][1]"));
        }

        public void clicarBotaoAprovarAprovacao()
        {
            aguarda_BotaoClicavel(By.XPath("/html/body/div[14]/div[11]/div//button[1]"));
        }

        public void clicarBotaoOcorrenciasGerais()
        {
            aguarda_BotaoClicavel("botaogeralpendencia");
        }

        public void aguardaBotaoVisualizar()
        {
            aguarda_ElementoPagina("visualizar");
        }

        public void selecaoResponsaveisEtapas(string elaborador, string revisor, string aprovador)
        {

            //Elaborador
            clicarBotao(By.XPath("//*[@id='SelectedUsuarios']/..//button"));
            aguarda_BotaoClicavel(By.XPath("//*[@id='SelectedUsuarios']/..//ul//label[normalize-space(text())='" + elaborador + "']//input[@type='checkbox']"));

            //Quem pode consensar
            clicarBotao(By.XPath("//*[@id='SelectedRevisores']/..//button"));
            aguarda_BotaoClicavel(By.XPath("//*[@id='SelectedRevisores']/..//ul//label[normalize-space(text())='" + revisor + "']//input[@type='checkbox']"));

            //Quem pode aprovar
            clicarBotao(By.XPath("//*[@id='SelectedAprovadores']/..//button"));
            aguarda_BotaoClicavel(By.XPath("//*[@id='SelectedAprovadores']/..//ul//label[normalize-space(text())='" + aprovador + "']//input[@type='checkbox']"));


        }

        internal void excluirDocumentoInterno(string dados)
        {
            obterCelula("Título", dados, "Excluir", "sortabledoc").FindElement(By.XPath("./button")).Click();
        }


        public void selecaoResponsaveisSeguranca(string quemPodeBaixar, string quemPodeVisualizar, string quemPodeImprimir)
        {

            //Quem pode baixar
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosQuemPodeBaixar']/..//button"));
            aguarda_BotaoClicavel(By.XPath("//*[@id='SelectedUsuariosQuemPodeBaixar']/..//ul//label[normalize-space(text())='" + quemPodeBaixar + "']//input[@type='checkbox']"));

            //Quem pode visualizar
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosQuemPodeVisualizar']/..//button"));
            aguarda_BotaoClicavel(By.XPath("//*[@id='SelectedUsuariosQuemPodeVisualizar']/..//ul//label[normalize-space(text())='" + quemPodeVisualizar + "']//input[@type='checkbox']"));

            //Quem pode imprimir
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosQuemPodeImprimirSalvar']/..//button"));
            aguarda_BotaoClicavel(By.XPath("//*[@id='SelectedUsuariosQuemPodeImprimirSalvar']/..//ul//label[normalize-space(text())='" + quemPodeImprimir + "']//input[@type='checkbox']"));

        }

        public void selecionarUnidade(string unidade)
        {

            clicarBotao(By.XPath("//*[@id='Empresas']/..//button"));
            aguarda_BotaoClicavel(By.XPath("//*[@id='Empresas']/..//ul//label[normalize-space(text())='" + unidade + "']//input[@type='checkbox']"));

        }

        /************ FILTROS TELA ******************/

        public void filtrosGerais(string etapa, string codigo, string titulo, string setor, string tipoDocumento)
        {
            selecionarCombo(By.XPath("//*[@name='_filtroStatus']"), etapa);
            escrever(By.XPath("//*[@name='_filtroCodigo']"), codigo);
            escrever(By.XPath("//*[@name='_filtroTitulo']"), titulo);
            escrever(By.XPath("//*[@name='_filtroSetorDescricao']"), setor);
            selecionarCombo(By.XPath("//*[@name='_filtroTipo']"), tipoDocumento);
        }

        public void botaoFiltrar()
        {
            clicarBotao(By.XPath("//*[@class='btn btn-primary'][1]"));
        }

        public void clica_BotaoFiltrar()
        {
            clicarBotao(By.XPath("//*[@class='btn btn-primary'][1]"));
        }

        public string tituloDocumentoTabela()
        {
            return obterTexto(By.XPath("//*[@title='Documento filtro']"));
        }

        public string codigoDocumentoTabela()
        {
            return obterTexto(By.XPath("//*[@title='123']"));
        }

        public string setorDocumentoTabela()
        {
            return obterTexto(By.XPath("//*[@title='Produção']"));
        }

        public string etapaDocumentoTabela()
        {
            return obterTexto(By.XPath("//*[@title='Elaboração']"));
        }

        public string tipoDocumentoTabela()
        {
            return obterTexto(By.XPath("//*[@title='Documento filtro']"));
        }

        public void aguardaMensagemTipoDocumentoObrigatorio()
        {
            aguarda_ElementoPagina(By.XPath("//span[.='O campo Tipo de Documento é obrigatório!']"));
        }

        public string obterMensagemTipoDocumentoObrigatorio()
        {
            return obterTexto(By.XPath("//span[.='O campo Tipo de Documento é obrigatório!']"));
        }

        public string obterMensagemTituloObrigatorio()
        {
            return obterTexto(By.XPath("//span[.='O campo Título é obrigatório!']"));
        }

        public string obterMensagemSetorObrigatorio()
        {
            return obterTexto(By.XPath("//span[.='O campo Setor é obrigatório!']"));
        }

        public string obterMensagemElaboradorObrigatorio()
        {
            return obterTexto(By.XPath("//span[.='O campo Elaboradores é obrigatório!']"));
        }

        public string obterMensagemAprovadorObrigatorio()
        {
            return obterTexto(By.XPath("//span[.='O campo Aprovadores é obrigatório!']"));
        }

        public string obterMensagemTipoValidadeObrigatorio()
        {
            return obterTexto(By.XPath("//span[.='O campo Tipo De Validade é obrigatório!']"));
        }

        public string obterMensagemJaExisteDocumentoComEsseTipoETitulo()
        {
            return obterTexto(By.XPath("//span[.='Já existe um documento cadastrado com esse título para esse tipo de documento!']"));
        }

        public void aguardaMensagemJaExisteDocumentoComEsseTipoETitulo()
        {
            aguarda_ElementoPagina(By.XPath("//span[.='Já existe um documento cadastrado com esse título para esse tipo de documento!']"));
        }
    }
}
