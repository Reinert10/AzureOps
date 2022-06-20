using _8QualiTestes.Helpers;
using _8QualiTestes.PageObjects.Documentos.Explorer;
using _8QualiTestes.PageObjects.Documentos.Internos;
using _8QualiTestes.PageObjects.DocumentosPage.InternosPage;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace _8QualiTestes.Testes.Documentos.Internos
{

    public class DocumentoInternos : BaseTest

    {


        private DocumentosInternosPO documentosInternoPage = new DocumentosInternosPO();
        private ConsultarDocumentosInternosPO consultarDocumentosInternosPage = new ConsultarDocumentosInternosPO();

        [Test]
        [TestCase("Tipo documento interno", "Cadastro Documento Interno Valido", "1", "Unidade B", "Produção", "Processo A", "Indeterminada")]
        public void FluxoCompletoLiberaçãoDocumento(string tipoDocumento, string titulo, string numeroRevisao,
            string unidade, string setor, string processo, string tipoValidade)
        {

            //CADASTRO
            documentosInternoPage.acessarTelaDocumentosInternos();
            documentosInternoPage.clicarBotaoNovoDocumentoInterno();
            documentosInternoPage.preencherDocumentoInterno(tipoDocumento, titulo, numeroRevisao, retornaDataAtual(), unidade,
             setor, processo, tipoValidade);
            documentosInternoPage.selecaoResponsaveisEtapas("Matheus Selenium", "Matheus Selenium", "Matheus Selenium");
            documentosInternoPage.selecaoResponsaveisSeguranca("Matheus Selenium", "Matheus Selenium", "Matheus Selenium");
            documentosInternoPage.clicarBotaoSalvarDocumentoInterno();
            documentosInternoPage.aguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", documentosInternoPage.getMensagemSalvoComSucesso());

            //ELABORAÇÃO
            documentosInternoPage.acessarTelaDocumentosInternos();
            documentosInternoPage.clicarDocumentoGrid();
            documentosInternoPage.aguardaBotaoVisualizar();
            documentosInternoPage.enviarArquivoElaboracao(documentosInternoPage.descricaoArquivo("Anexo.pdf"));
            Thread.Sleep(900);
            documentosInternoPage.clicarBotaoFinalizarElaboracao();

            //CONSENSO
            documentosInternoPage.clicarBotaoFiltrar();
            documentosInternoPage.clicarDocumentoTabela();
            documentosInternoPage.clicarAprovarConsenso();

            //APROVAÇÃO
            documentosInternoPage.clicarBotaoFiltrar();
            documentosInternoPage.clicarDocumentoTabela();
            documentosInternoPage.clicarBotaoAprovarAprovacao();

            //EXCLUSÃO
            documentosInternoPage.clicarBotaoOcorrenciasGerais();
            documentosInternoPage.aguardaDocumentoGrid();
            documentosInternoPage.excluirDocumentoInterno("Cadastro Documento Interno Valido");
            documentosInternoPage.clicarBotaoConfirmaExclusao();


        }

        [Test]
        public void ValidarMensagemMotivoRevisaoObrigatorio()
        {
            consultarDocumentosInternosPage.acessarTelaConsultarDocumentos();
            consultarDocumentosInternosPage.clicarDocumentoTabela("Documento revisão");
            consultarDocumentosInternosPage.clicarBotaoRevisar();
            consultarDocumentosInternosPage.aguardaMensagemRevisaoObrigatorio();
            Assert.AreEqual("Campo Motivo da revisão obrigatório!", consultarDocumentosInternosPage.getMensagemMotivoRevisaoObrigatorio());


        }

        [Test]
        public void ValidarMensagemCamposObrigatoriosCadastroDocumento()
        {

            documentosInternoPage.acessarTelaDocumentosInternos();
            documentosInternoPage.clicarBotaoNovoDocumentoInterno();
            documentosInternoPage.clicarBotaoSalvarDocumentoInterno();

            documentosInternoPage.aguardaMensagemTipoDocumentoObrigatorio();

            Assert.AreEqual("O campo Tipo de Documento é obrigatório!", documentosInternoPage.obterMensagemTipoDocumentoObrigatorio());
            Assert.AreEqual("O campo Título é obrigatório!", documentosInternoPage.obterMensagemTituloObrigatorio());
            Assert.AreEqual("O campo Setor é obrigatório!", documentosInternoPage.obterMensagemSetorObrigatorio());
            Assert.AreEqual("O campo Elaboradores é obrigatório!", documentosInternoPage.obterMensagemElaboradorObrigatorio());
            Assert.AreEqual("O campo Aprovadores é obrigatório!", documentosInternoPage.obterMensagemAprovadorObrigatorio());
            Assert.AreEqual("O campo Tipo De Validade é obrigatório!", documentosInternoPage.obterMensagemTipoValidadeObrigatorio());

        }

        [Test]
        public void ValidarMensagemDocumentoJaCadastradoComEsseTipoETitulo()
        {

            documentosInternoPage.acessarTelaDocumentosInternos();
            documentosInternoPage.clicarBotaoNovoDocumentoInterno();
            documentosInternoPage.setTipoDocumento("abc");
            documentosInternoPage.setTitulo("Documento Ja Cadastrado");
            documentosInternoPage.clicarBotaoSalvarDocumentoInterno();

            documentosInternoPage.aguardaMensagemJaExisteDocumentoComEsseTipoETitulo();
            Assert.AreEqual("Já existe um documento cadastrado com esse título para esse tipo de documento!",
                documentosInternoPage.obterMensagemJaExisteDocumentoComEsseTipoETitulo());
        }

    }
}


