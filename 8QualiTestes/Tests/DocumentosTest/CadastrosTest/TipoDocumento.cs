
using _8QualiTestes.PageObjects.Documentos_Internos.Cadastros;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using _8QualiTestes.Helpers;

namespace _8QualiTestes.Testes.Documentos_Internos.Cadastros
{

    [TestFixture]
    //[Parallelizable]

    public class TipoDocumento : BaseTest
    {

        private TipoDocumentoPO tipoDocumentoPage = new TipoDocumentoPO();

        [Test]

        public void CadastroTipoDocumentoValido()
        {
            tipoDocumentoPage.acessarTelaTipoDocumentos();
            tipoDocumentoPage.clicarBotaoAdicionarTipoDocumento();
            tipoDocumentoPage.PreencherTipoDocumento(
                "Cadastro Tipo Documento Valido",
                "MT",
                "5",
                "Sem espa�o entre a sigla e o n�mero");
            tipoDocumentoPage.clicarBotaoSalvarTipoDocumento();
            tipoDocumentoPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", tipoDocumentoPage.GetMensagemSalvoComSucesso());

            tipoDocumentoPage.acessarTelaTipoDocumentos();
            tipoDocumentoPage.aguardaTituloDocumentoGrid("Cadastro Tipo Documento Valido");
            tipoDocumentoPage.clicarExcluirTipo("Cadastro Tipo Documento Valido");
            tipoDocumentoPage.aguardaJanelaExclusao();

        }


        [Test]
        public void AlterarTipoDocumento()
        {


            tipoDocumentoPage.acessarTelaTipoDocumentos();
            tipoDocumentoPage.clicarBotaoAdicionarTipoDocumento();
            tipoDocumentoPage.PreencherTipoDocumento(
               "Altera��o Cadastro Tipo Documento",
               "MT",
               "5",
               "Sem espa�o entre a sigla e o n�mero");
            tipoDocumentoPage.clicarBotaoSalvarTipoDocumento();
            tipoDocumentoPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", tipoDocumentoPage.GetMensagemSalvoComSucesso());
            tipoDocumentoPage.acessarTelaTipoDocumentos();
            tipoDocumentoPage.clicarAlterarLocal("Altera��o Cadastro Tipo Documento");
            tipoDocumentoPage.PreencherTipoDocumento(
              "Tipo Documento Alterado",
              "MT",
              "5",
              "Sem espa�o entre a sigla e o n�mero");
            tipoDocumentoPage.clicarBotaoSalvarTipoDocumento();
            tipoDocumentoPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", tipoDocumentoPage.GetMensagemSalvoComSucesso());
            tipoDocumentoPage.acessarTelaTipoDocumentos();
            tipoDocumentoPage.aguardaTipoDocumentoGrid();
            tipoDocumentoPage.clicarExcluirTipo("Tipo Documento Alterado");
            tipoDocumentoPage.aguardaJanelaExclusao();


        }


        [Test]

        public void CadastroTipoDocumentoDescricaoObrigatoria()
        {

            tipoDocumentoPage.acessarTelaTipoDocumentos();
            tipoDocumentoPage.clicarBotaoAdicionarTipoDocumento();
            tipoDocumentoPage.PreencherTipoDocumento(
                "",
                "MT",
                "2",
                "Sem espa�o entre a sigla e o n�mero");
            tipoDocumentoPage.clicarBotaoSalvarTipoDocumento();

            tipoDocumentoPage.aguardaMensagemTipoObrigatorio();
            Assert.AreEqual("O campo Tipo de Documento � obrigat�rio!", tipoDocumentoPage.obterMensagemTipoObrigatorio());

        }

        [Test]

        public void CadastroTipoDocumentoDescricaoJaCadastrada()
        {

            tipoDocumentoPage.acessarTelaTipoDocumentos();
            tipoDocumentoPage.clicarBotaoAdicionarTipoDocumento();
            tipoDocumentoPage.PreencherTipoDocumento(
                "Tipo de Documento j� cadastrado",
                "MT",
                "3",
                "Sem espa�o entre a sigla e o n�mero");
            tipoDocumentoPage.clicarBotaoSalvarTipoDocumento();

            tipoDocumentoPage.aguardaMensagemTipoJaCadastrado();
            Assert.AreEqual("Tipo de Documento j� cadastrado!", tipoDocumentoPage.obterMensagemTipoJaCadastrado());


        }
    }

}













