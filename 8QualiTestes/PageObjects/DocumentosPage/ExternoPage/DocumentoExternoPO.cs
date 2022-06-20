using _8QualiTestes.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QualiTestes.PageObjects.Documentos.Externo
{
    public class DocumentoExternoPO : BasePage
    {

        public DocumentoExternoPO acessarTelaDocumentoExterno()
        {
            acessarTela("https://app.8quali.com.br/GestaoDocumento/DocumentoExterno");
            return this;
        }




        /************ PREENCHIMENTO CAMPOS ***************/


        public void clica_botaoAdicionar()
        {
            clicarBotao("novo");
        }

       public void preencherDocumentoExterno(string titulo, string codigo, string dataValidade, string QntdDeDiasDataValidade, string unidade,
       string setor, string processo, string origem, string protecao, string retencao, string descarte, string armazenamento,
       string meioArmazenamento)
        {

            aguarda_EscreveInputPagina("Titulo", titulo);
            escrever("Codigo", codigo);
            clicarBotao("DataDeValidade");
            escrever("DataValidade", dataValidade);
            escrever("QuantidadeDeDiasQueDesejaAvisarSobreDataValidade", QntdDeDiasDataValidade);
            selecionarCombo("EmpresaAuditadaId", unidade);
            selecionarCombo("ProcessoId", setor);
            selecionarCombo("SetorId", processo);
            escrever("Origem", origem);
            escrever("Protecao", protecao);
            escrever("Retencao", retencao);
            escrever("Descarte", descarte);
            selecionarCombo("ArmazenamentoDocumentoRegistroId", armazenamento);
            selecionarCombo("MeioArmazenamentoDocumentoRegistroId", meioArmazenamento);

        }

        public string GetMensagemSalvoComSucesso()
        {
            return obterTexto("alertaSalvo");
        }

        public void AguardaMensagemSalvoComSucesso()
        {
            aguarda_ElementoPagina("alertaSalvo");
        }


        public void preencherDocumentoExterno(string titulo, string codigo, string unidade,
        string setor, string processo, string origem, string protecao, string retencao, string descarte, string armazenamento,
        string meioArmazenamento)
        {

            aguarda_EscreveInputPagina("Titulo", titulo);
            escrever("Codigo", codigo);
            selecionarCombo("EmpresaAuditadaId", unidade);
            selecionarCombo("ProcessoId", setor);
            selecionarCombo("SetorId", processo);
            escrever("Origem", origem);
            escrever("Protecao", protecao);
            escrever("Retencao", retencao);
            escrever("Descarte", descarte);
            selecionarCombo("ArmazenamentoDocumentoRegistroId", armazenamento);
            selecionarCombo("MeioArmazenamentoDocumentoRegistroId", meioArmazenamento);

        }

        public void clicarBotaoSalvar()
        {
            aguarda_BotaoClicavel("botao-salvar-modal");
        }

        public void localizarResponsaveis()
        {
            rodarMouse(By.XPath("//*[@class='multiselect dropdown-toggle btn btn-default']"));
        }

        public void setTitulo(string titulo)
        {
            aguarda_EscreveInputPagina("Titulo", titulo);
        }


        public string mensagemTituloObrigatório()
        {
            return obterTexto("Err_Titulo");
        }



        public string mensagemSetorObrigatório()
        {
            return obterTexto("Err_ProcessoId");

        }
        public string mensagemResponsavelObrigatório()
        {
            return obterTexto("Err_SelectedUsuariosDocumentoExternoResponsavel");
        }
        public void aguardaMensagemTitulo()
        {
            aguarda_ElementoPagina("Err_Titulo");
        }
        public void aguardaJanelaExclusaoExterno()
        {
            aguarda_BotaoVisivel(By.Id("Confirmar"));
        }

        public void clicarBotaoAdicionarAnexo()
        {
            clicarBotao(By.XPath("//*[@id='uploadlink']/button"));
        }



        /************ SELEÇÃO USUÁRIOS RESPONSÁVEIS (Só seleciona Matheus Selenium) ***************/


        public void selecaoResponsaveis(string elaborador, string quemPodeVisualizar, string quemPodeBaixar, string quemPodeImprimir)
        {

            //Elaborador
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentoExternoResponsavel']/..//button"));
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentoExternoResponsavel']/..//ul//label[normalize-space(text())='" + elaborador + "']//input[@type='checkbox']"));

            //Quem pode visualizar
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentoExternoQuemPodeVisualizar']/..//button"));
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentoExternoQuemPodeVisualizar']/..//ul//label[normalize-space(text())='" + quemPodeVisualizar + "']//input[@type='checkbox']"));

            //Quem pode baixar
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentoExternoQuemPodeBaixar']/..//button"));
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentoExternoQuemPodeBaixar']/..//ul//label[normalize-space(text())='" + quemPodeBaixar + "']//input[@type='checkbox']"));

            //Quem pode imprimir
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentoExternoQuemPodeImprimirSalvar']/..//button"));
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentoExternoQuemPodeImprimirSalvar']/..//ul//label[normalize-space(text())='" + quemPodeImprimir + "']//input[@type='checkbox']"));

        }

        /************ PREENCHIMENTO DADOS ANEXO ***************/
        public void selecionarAnexo(string descricaoAnexo, string dataAnexo, string visualizarExplorer, string caminhoArquivo)
        {

            escrever("CurrentConsultarDescricao", descricaoAnexo);
            escrever("CurrentData", dataAnexo);
            selecionarCombo("visualizarexplorer", visualizarExplorer);
            anexarArquivo("uploadBtnanexo", caminhoArquivo);
            clicarBotao(By.XPath("//*[@id='uploadlink']//button"));

        }

        public string descricaoArquivo(string valor)
        {

            string folder = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(folder, @"Utils\Files\" + valor + "");

        }



        /************ TABELA ***************/
        public void clicarExcluirDocumentoExterno(string dados)
        {
            obterCelula("Título", dados, "Excluir", "sortabledoc").FindElement(By.XPath("./button")).Click();
        }

        internal void clicarDocumentoAlterarCadastro(string dados)
        {
            obterCelula("Título", dados, "", "sortabledoc").FindElement(By.XPath("//*[@title='Alteração Documento Externo']")).Click();
        }


        public void aguardaAnexoTabela()
        {
            aguarda_ElementoPagina(By.XPath("//*[@id='grid_anexo_tr_0']"));
        }

        public void aguardaTituloDocumentoGrid(string tituloTabela)
        {
            aguarda_ElementoPagina(By.XPath("//*[@title='" + tituloTabela + "']"));
        }

    }
}
