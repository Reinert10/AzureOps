using _8QualiTestes.PageObjects.Documentos_Internos.Cadastros;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using _8QualiTestes.Helpers;

namespace _8QualiTestes.Testes.Documentos_Internos.Cadastros
{

    public class LocalArmazenagem : BaseTest
    {

        private LocalArmazenagemPO localArmazenagemPage = new LocalArmazenagemPO();

        [Test]
        public void CadastroLocalArmazenagemValido()
        {

            //Cadastro
            localArmazenagemPage.acessarTelaLocalArmazenagem();
            localArmazenagemPage.preencheLocalArmazenagem("Cadastro Local Armazenagem Valido");
            localArmazenagemPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", localArmazenagemPage.GetMensagemSalvoComSucesso());

            //Exclusão
            localArmazenagemPage.acessarTelaLocalArmazenagem();
            localArmazenagemPage.aguardaDocumentoGrid("Cadastro Local Armazenagem Valido");
            localArmazenagemPage.clicarExcluirLocal("Cadastro Local Armazenagem Valido");
            localArmazenagemPage.aguardaJanelaExclusao();


        }

        [Test]
        public void AlterarLocalArmazenagem()
        {

            //Cadastro
            localArmazenagemPage.acessarTelaLocalArmazenagem();
            localArmazenagemPage.preencheLocalArmazenagem("Alteração Local Armazenagem");
            localArmazenagemPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", localArmazenagemPage.GetMensagemSalvoComSucesso());

            //Alteração
            localArmazenagemPage.acessarTelaLocalArmazenagem();
            localArmazenagemPage.aguardaDocumentoGrid("Alteração Local Armazenagem");
            localArmazenagemPage.clicarAlterarLocal("Alteração Local Armazenagem");
            localArmazenagemPage.aguardaInputDescricao("Local Armazenagem alterado");
            localArmazenagemPage.clicarBotaoSalvarLocalArmazenagem();
            localArmazenagemPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", localArmazenagemPage.GetMensagemSalvoComSucesso());

            //Exclusão
            localArmazenagemPage.acessarTelaLocalArmazenagem();
            localArmazenagemPage.clicarExcluirLocal("Local Armazenagem alterado");
            localArmazenagemPage.aguardaJanelaExclusao();

        }




        [Test]
        public void CadastroLocalArmazenagemInvalido()
        {
            localArmazenagemPage.acessarTelaLocalArmazenagem();
            localArmazenagemPage.preencheLocalArmazenagem("");
            localArmazenagemPage.aguardaMensagemObrigatoria();
            Assert.AreEqual("O campo Descrição do Meio de Armazenagem é obrigatório!", localArmazenagemPage.obterMensagemDescricaoObrigatoria());


        }

    }
}
