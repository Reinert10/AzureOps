using _8QualiTestes.Helpers;
using _8QualiTestes.PageObjects.Documentos.Explorer;
using _8QualiTestes.PageObjects.Documentos.Externo;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _8QualiTestes.Testes.Documentos.Externo
{
    public class DocumentoExterno : BaseTest
    {


        private DocumentoExternoPO documentoExternoPage = new DocumentoExternoPO();
        private ExplorerPO explorerPage = new ExplorerPO();
        
        


        [Test]
        [TestCase("Cadastro Documento Externo valido", "345", "2", "Unidade A", "Produção", "Selecionar", "Origem exemplo", "Protecao Exemplo", "Retencao Exemplo", "Descarte Exemplo", 
            "Local Armazenamento A", "Meio Armazenamento A","Anexo.pdf", "Anexo 1", "345 - Cadastro Documento Externo valido - Anexo 1", "Cadastro Documento Externo valido",
            "Cadastro Documento Externo valido")]
        
        
        public void cadastroDocumentoExternoTodasExtensoes(string titulo, string codigo, string QntdDeDiasDataValidade, string unidade, string setor, string processo, string origem, string protecao, string retencao,
            string descarte, string armazenamento, string meioArmazenamento, string url, string descricaoAnexo, string documento, string tituloTabela, string excluirTituloDocumento)
        {

            //CADASTRO DOCUMENTO
            documentoExternoPage.acessarTelaDocumentoExterno();
            documentoExternoPage.clica_botaoAdicionar();
            documentoExternoPage.preencherDocumentoExterno(titulo, codigo, retornaDataAtual(), QntdDeDiasDataValidade, unidade,  setor,  processo,  origem,  protecao,  retencao,
             descarte,  armazenamento,  meioArmazenamento);
            documentoExternoPage.localizarResponsaveis();
            documentoExternoPage.selecaoResponsaveis("Matheus Selenium", "Matheus Selenium", "Matheus Selenium", "Matheus Selenium");
            documentoExternoPage.selecionarAnexo(descricaoAnexo, retornaDataAtual(), "Sim",
                documentoExternoPage.descricaoArquivo(url));
            documentoExternoPage.aguardaAnexoTabela();
            documentoExternoPage.clicarBotaoSalvar();
            documentoExternoPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", documentoExternoPage.GetMensagemSalvoComSucesso());
            documentoExternoPage.aguardaTituloDocumentoGrid(tituloTabela);

            //EXPLORER
            
            /*explorerPage.acessarTelaExplorer();
            explorerPage.clicarVisualizar("Produção", documento);
            explorerPage.clicarBaixar("Produção", documento);
            explorerPage.clicarImprimir("Produção", documento);adasdasdasd
            */

           
            //EXCLUSÃO
            documentoExternoPage.acessarTelaDocumentoExterno();
            documentoExternoPage.clicarExcluirDocumentoExterno(excluirTituloDocumento);
            documentoExternoPage.aguardaJanelaExclusaoExterno();
            
            
        }

        [Test]
        public void documentoExternoCamposObrigatorios()
        {

            documentoExternoPage.acessarTelaDocumentoExterno();
            documentoExternoPage.clica_botaoAdicionar();
            documentoExternoPage.setTitulo("");
            documentoExternoPage.clicarBotaoSalvar();
            Thread.Sleep(1200);
            Assert.AreEqual("O campo Título é obrigatório!", documentoExternoPage.mensagemTituloObrigatório());
            Assert.AreEqual("O campo Setor é obrigatório!", documentoExternoPage.mensagemSetorObrigatório());
            Assert.AreEqual("O campo Elaboradores é obrigatório!", documentoExternoPage.mensagemResponsavelObrigatório());
          

        }


        [Test]
       
        public void AlterarDocumentoExterno()
        {

            //CADASTRO DOCUMENTO
            documentoExternoPage.acessarTelaDocumentoExterno();
            documentoExternoPage.clica_botaoAdicionar();
            documentoExternoPage.preencherDocumentoExterno("Alteração Documento Externo", "123", "Unidade A", "Produção", "Processo A", "Origem exemplo",
                "Protecao Exemplo", "Retencao Exemplo", "Descarte Exemplo", "Local Armazenamento A", "Meio Armazenamento A");
            documentoExternoPage.localizarResponsaveis();
            documentoExternoPage.selecaoResponsaveis("Matheus Selenium", "Matheus Selenium", "Matheus Selenium", "Matheus Selenium");
            documentoExternoPage.clicarBotaoSalvar();
            documentoExternoPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", documentoExternoPage.GetMensagemSalvoComSucesso());
            documentoExternoPage.acessarTelaDocumentoExterno();

            //ALTERAÇÃO
            documentoExternoPage.clicarDocumentoAlterarCadastro("Alteração Documento Externo");
            documentoExternoPage.preencherDocumentoExterno("Documento alterado", "234", "Unidade A", "Produção", "Processo A", "Origem exemplo",
                "Protecao Exemplo", "Retencao Exemplo", "Descarte Exemplo", "Local Armazenamento A", "Meio Armazenamento A");
            documentoExternoPage.clicarBotaoSalvar();
            documentoExternoPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", documentoExternoPage.GetMensagemSalvoComSucesso());

            //EXCLUSÃO
            documentoExternoPage.acessarTelaDocumentoExterno();
            documentoExternoPage.clicarExcluirDocumentoExterno("Documento alterado");
            documentoExternoPage.aguardaJanelaExclusaoExterno();
            

        }

    }

}
