using _8QualiTestes.Helpers;
using _8QualiTestes.PageObjects.Documentos.Explorer;
using _8QualiTestes.PageObjects.Documentos.Registros;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _8QualiTestes.Tests.Documentos.Registros
{
    public class Registros : BaseTest
    {

        private RegistrosPO registrosPage = new RegistrosPO();
        private ExplorerPO explorerPage = new ExplorerPO();


        [Test]
        [TestCase("Cadastro Registro Valido", "123", "2", "Unidade A", "Produção", "Processo A", "Local Armazenamento A", "Meio Armazenamento A",
            "Recuperação automação", "Proteção automação", "Descarte automação", "Retenção Ativo Automação", "Retenção Morto automação", "Anexo.pdf")]
        public void cadastroRegistro(string titulo, string codigo, string numeroReviso, string unidade,
       string setor, string processo, string armazenamento, string meioArmazenamento, string recuperacao, string protecao, string descarte,
       string retencaoAtivo, string retencaoMorto, string url)
        {

            registrosPage.acessarTelaRegistro();
            registrosPage.clicarBotaoNovo();
            registrosPage.preencherRegistro(titulo, codigo, numeroReviso, unidade, setor, processo, retornaDataAtual(), retornaDataAtual(), armazenamento, meioArmazenamento,
                recuperacao, protecao, descarte, retencaoAtivo, retencaoMorto);
            registrosPage.localizarResponsaveis();
            registrosPage.selecaoResponsaveis("Matheus Selenium", "Matheus Selenium", "Matheus Selenium", "Matheus Selenium");

            registrosPage.selecionarAnexo("Anexo 1", retornaDataAtual(), "Sim", registrosPage.descricaoArquivo(url));
            registrosPage.aguardaAnexoTabela();
            registrosPage.clicarBotaoSalvarRegistro();
            registrosPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", registrosPage.GetMensagemSalvoComSucesso());
            registrosPage.aguardaTituloDocumentoGrid("Cadastro Registro Valido");

            //EXPLORER
            explorerPage.acessarTelaExplorer();
            explorerPage.clicarPastaSetor("Produção");
            explorerPage.clicarPastaProcesso("Processo A");
            explorerPage.clicarDocumento("123 - Anexo 1");

            /*explorerPage.clicarBotaoVisualizar();
            explorerPage.clicarBotaoBaixar();
            getDriver().Close();
            explorerPage.clicarBotaoImprimir();
            getDriver().Close();
            */

            //EXCLUSÃO
            registrosPage.acessarTelaRegistro();
            registrosPage.clicarExcluirRegistro("Cadastro Registro Valido");
            registrosPage.aguardaJanelaExclusaoExterno();




        }


        [Test]
        public void cadastroRegistroCamposObrigatorios()
        {

            registrosPage.acessarTelaRegistro();
            registrosPage.clicarBotaoNovo();
            registrosPage.setTitulo("");
            registrosPage.clicarBotaoSalvarRegistro();
            registrosPage.aguarda_mensagemObrigatoria();
            Assert.AreEqual("O campo Setor é obrigatório!", registrosPage.mensagemSetorObrigatório());
            Assert.AreEqual("O campo Elaboradores é obrigatório!", registrosPage.mensagemResponsavelObrigatório());


        }

        [Test]

        public void AlterarRegistroDocumento()
        {

            //CADASTRO
            registrosPage.acessarTelaRegistro();
            registrosPage.clicarBotaoNovo();
            registrosPage.preencherRegistro("Alteração Registro", "123", "1", "Unidade A", "Produção", "Processo A", retornaDataAtual(), retornaDataAtual(), "Local Armazenamento A",
                "Meio Armazenamento A", "Recuperação automação 1", "Proteção automação 1", "Descarte automação 1", "Retenção Ativo Automação 1", "Retenção Morto automação 1");
            registrosPage.localizarResponsaveis();
            registrosPage.selecaoResponsaveis("Matheus Selenium", "Matheus Selenium", "Matheus Selenium", "Matheus Selenium");
            registrosPage.clicarBotaoSalvarRegistro();
            registrosPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", registrosPage.GetMensagemSalvoComSucesso());

            //EDIÇÃO
            registrosPage.acessarTelaRegistro();
            registrosPage.aguardaTituloDocumentoGrid("Alteração Registro");
            registrosPage.clicarDocumentoAlterarCadastro("Alteração Registro");
            registrosPage.preencherRegistro("Registro Alterado", "234", "2", "Unidade B", "Gestão Da Qualidade", "Processo B", retornaDataAtual(), retornaDataAtual(), "Local Armazenamento B",
                "Meio Armazenamento B", "Recuperação automação 2", "Proteção automação 2", "Descarte automação 2", "Retenção Ativo Automação 2", "Retenção Morto automação 2");
            registrosPage.clicarBotaoSalvarRegistro();
            registrosPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", registrosPage.GetMensagemSalvoComSucesso());

            //EXCLUSÃO
            registrosPage.acessarTelaRegistro();
            registrosPage.aguardaTituloDocumentoGrid("Registro Alterado");
            registrosPage.clicarExcluirRegistro("Registro Alterado");
            registrosPage.aguardaJanelaExclusaoExterno();



        }


    }

}
