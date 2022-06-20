
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
   

    public class MeioArmazenagem : BaseTest
    {

        private MeioArmazenagemPO meioArmazenagemPage = new MeioArmazenagemPO();

        [Test]
        public void CadastroMeioArmazenagemValido()
        {
            //Cadastro
            meioArmazenagemPage.acessarTelaMeioArmazenagem();
            meioArmazenagemPage.preencheMeioArmazenagem("Cadastro Meio Armazenagem Valido");
            meioArmazenagemPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", meioArmazenagemPage.GetMensagemSalvoComSucesso());

            //Exclusão
            meioArmazenagemPage.acessarTelaMeioArmazenagem();
            meioArmazenagemPage.aguardaDocumentoGrid("Cadastro Meio Armazenagem Valido");
            meioArmazenagemPage.clicarExcluirMeio("Cadastro Meio Armazenagem Valido");
            meioArmazenagemPage.aguardaJanelaExclusao();
        
            
        }

        [Test]
        public void CadastroDescricaoObrigatoria()
        {
            meioArmazenagemPage.acessarTelaMeioArmazenagem();
            meioArmazenagemPage.preencheMeioArmazenagem("");
            meioArmazenagemPage.aguardaMensagemObrigatoria();
            Assert.AreEqual("O campo Descrição do Local de Armazenagem é obrigatório!", meioArmazenagemPage.obterMensagemDescricaoObrigatoria());
            

        }


        [Test]
        public void AlterarMeioArmazenagem()
        {

            //Cadastro
            meioArmazenagemPage.acessarTelaMeioArmazenagem();
            meioArmazenagemPage.preencheMeioArmazenagem("Alteração Meio Armazenagem");
            meioArmazenagemPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", meioArmazenagemPage.GetMensagemSalvoComSucesso());

            //Alteração
            meioArmazenagemPage.acessarTelaMeioArmazenagem();
            meioArmazenagemPage.aguardaDocumentoGrid("Alteração Meio Armazenagem");
            meioArmazenagemPage.clicarAlterarMeio("Alteração Meio Armazenagem");
            meioArmazenagemPage.aguardaInputDescricao("Meio Armazenagem alterado");
            meioArmazenagemPage.clicarBotaoSalvarMeioArmazenagem();
            meioArmazenagemPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", meioArmazenagemPage.GetMensagemSalvoComSucesso());

            //Exclsuão
            meioArmazenagemPage.acessarTelaMeioArmazenagem();
            meioArmazenagemPage.aguardaDocumentoGrid("Meio Armazenagem alterado");
            meioArmazenagemPage.clicarExcluirMeio("Meio Armazenagem alterado");
            meioArmazenagemPage.aguardaJanelaExclusao();
            

        }

    }
}
