using _8QualiTestes.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QualiTestes.PageObjects.Documentos.Registros
{
    public class RegistrosPO : BasePage
    {

        public RegistrosPO acessarTelaRegistro()
        {
            acessarTela("https://app.8quali.com.br/GestaoDocumento/DocumentoRegistro");
            return this;
        }

       

        public void clicarBotaoNovo()
        {
            clicarBotao("novo");
        }

        public void clicarBotaoSalvarRegistro()
        {
            clicarBotao("botao-salvarregistro-modal");
        }

        public void setTitulo(string titulo)
        {
            aguarda_EscreveInputPagina("Titulo", titulo);
        }

        public void aguardaAnexoTabela()
        {
            aguarda_ElementoPagina(By.XPath("//*[@id='grid_anexo_tr_0']"));
        }

        public void localizarResponsaveis()
        {
            rodarMouse(By.XPath("//*[@class='multiselect dropdown-toggle btn btn-default']"));
        }



        public void preencherRegistro(string titulo, string codigo, string numeroReviso, string unidade,
       string setor, string processo, string dataEmissao, string dataUltimaRevisao, string armazenamento,
       string meioArmazenamento, string recuperacao, string protecao, string descarte, string retencaoAtivo, string retencaoMorto)
        {

            aguarda_EscreveInputPagina("Titulo", titulo);
            escrever("Codigo", codigo);
            escrever("NumeroDaRevisao", numeroReviso);
            selecionarCombo("EmpresaAuditadaId", unidade);
            selecionarCombo("ProcessoId", setor);
            selecionarCombo("SetorId", processo);
            escrever("DataEmissao", dataEmissao);
            escrever("DataRevisao", dataUltimaRevisao);
            selecionarCombo("ArmazenamentoDocumentoRegistroId", armazenamento);
            selecionarCombo("MeioArmazenamentoDocumentoRegistroId", meioArmazenamento);
            escrever("Recuperacao", recuperacao);
            escrever("Protecao", protecao);
            escrever("Descarte", descarte);
            escrever("RetencaoAtivo", retencaoAtivo);
            escrever("RetencaoMorto", retencaoMorto);
           
        }

        public void aguardaTituloDocumentoGrid(string tituloTabela)
        {
            aguarda_ElementoPagina(By.XPath("//*[@title='" + tituloTabela + "']"));
        }



        public void selecaoResponsaveis(string elaborador, string quemPodeVisualizar, string quemPodeBaixar, string quemPodeImprimir)
        {

            //Elaborador
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentoRegistroResponsavel']/..//button"));
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentoRegistroResponsavel']/..//ul//label[normalize-space(text())='" + elaborador + "']//input[@type='checkbox']"));

            //Quem pode visualizar
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentoRegistroQuemPodeVisualizar']/..//button"));
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentoRegistroQuemPodeVisualizar']/..//ul//label[normalize-space(text())='" + quemPodeVisualizar + "']//input[@type='checkbox']"));

            //Quem pode baixars
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentoRegistroQuemPodeBaixar']/..//button"));
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentoRegistroQuemPodeBaixar']/..//ul//label[normalize-space(text())='" + quemPodeBaixar + "']//input[@type='checkbox']"));

            //Quem pode imprimir
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentorRegistroQuemPodeImprimirSalvar']/..//button"));
            clicarBotao(By.XPath("//*[@id='SelectedUsuariosDocumentorRegistroQuemPodeImprimirSalvar']/..//ul//label[normalize-space(text())='" + quemPodeImprimir + "']//input[@type='checkbox']"));

        }

        public string GetMensagemSalvoComSucesso()
        {
            return obterTexto("alertaSalvo");
        }

        public void AguardaMensagemSalvoComSucesso()
        {
            aguarda_ElementoPagina("alertaSalvo");
        }

        internal void clicarDocumentoAlterarCadastro(string dados)
        {
            obterCelula("Título", dados, "Excluir", "sortabledoc")
                .FindElement(By.XPath("//*[@title='Alteração Registro']")).Click();
        }

        public void clicarExcluirRegistro(string dados)
        {
            obterCelula("Título", dados, "Excluir", "sortabledoc").FindElement(By.XPath(".//button")).Click();
        }

        public string mensagemSetorObrigatório()
        {
            return obterTexto(By.XPath("//span[.='O campo Setor é obrigatório!']"));

        }

        public void aguarda_mensagemObrigatoria()
        {
            aguarda_ElementoPagina(By.XPath("//span[.='O campo Setor é obrigatório!']"));
        }

        public string mensagemResponsavelObrigatório()
        {
            return obterTexto(By.XPath("//*[@id='Err_SelectedUsuariosDocumentoRegistroResponsavel']/../span"));
        }

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





        public void aguardaJanelaExclusaoExterno()
        {
            aguarda_BotaoVisivel("Confirmar");
        }
    }
}
