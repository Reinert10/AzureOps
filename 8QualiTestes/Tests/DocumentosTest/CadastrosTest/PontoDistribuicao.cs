
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
    [TestFixture]


    public class PontoDistribuicao : BaseTest
    {



        protected PontoDistribucaoPO pontoDistribuicaoPage = new PontoDistribucaoPO();


        [Test]
        public void CadastroPontoDistribuicaoValido()
        {
            //Cadastro
            pontoDistribuicaoPage.acessoTelaPontoDeDistribuicao();
            pontoDistribuicaoPage.preenchePontoDistribuicao("Cadastro Ponto Distribuicao Valido");
            pontoDistribuicaoPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", pontoDistribuicaoPage.GetMensagemSalvoComSucesso());

            //Exclusão
            pontoDistribuicaoPage.acessoTelaPontoDeDistribuicao();
            pontoDistribuicaoPage.aguardaTituloDocumentoGrid("Cadastro Ponto Distribuicao Valido");
            pontoDistribuicaoPage.clicarExcluirPonto("Cadastro Ponto Distribuicao Valido");
            pontoDistribuicaoPage.aguardaJanelaExclusao();
            

        }

        [Test]
        public void CadastroPontoDistribuicaoJaCadastrado()
        {

            pontoDistribuicaoPage.acessoTelaPontoDeDistribuicao();
            pontoDistribuicaoPage.preenchePontoDistribuicao("Ponto Distribuicao Ja Cadastrado");
            pontoDistribuicaoPage.aguarda_MensagemDescricaoJaCadastrada();
            Assert.AreEqual("Ponto de distribuição já cadastrado!", pontoDistribuicaoPage.obterMensagemDescricaoJaCadastrada());

        }

        [Test]
        public void AlterarPontoDistribuicao()
        {

            //Cadastro
            pontoDistribuicaoPage.acessoTelaPontoDeDistribuicao();
            pontoDistribuicaoPage.preenchePontoDistribuicao("Alteração Ponto de Distribuição");
            pontoDistribuicaoPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", pontoDistribuicaoPage.GetMensagemSalvoComSucesso());

            //Alteração
            pontoDistribuicaoPage.acessoTelaPontoDeDistribuicao();
            pontoDistribuicaoPage.aguardaTituloDocumentoGrid("Alteração Ponto de Distribuição");
            pontoDistribuicaoPage.clicarAlterarLocal("Alteração Ponto de Distribuição");
            pontoDistribuicaoPage.aguardaInputDescricao("Ponto alterado");
            pontoDistribuicaoPage.clicarBotaoSalvarPonto();
            pontoDistribuicaoPage.AguardaMensagemSalvoComSucesso();
            Assert.AreEqual("Salvo com sucesso", pontoDistribuicaoPage.GetMensagemSalvoComSucesso());

            //Exclusão
            pontoDistribuicaoPage.acessoTelaPontoDeDistribuicao();
            pontoDistribuicaoPage.aguardaTituloDocumentoGrid("Ponto alterado");
            pontoDistribuicaoPage.clicarExcluirPonto("Ponto alterado");
            pontoDistribuicaoPage.aguardaJanelaExclusao();
           

        }




        [Test]
        public void CadastroPontoDistribuicaoInvalido()
        {

            pontoDistribuicaoPage.acessoTelaPontoDeDistribuicao();
            pontoDistribuicaoPage.preenchePontoDistribuicao("");
            pontoDistribuicaoPage.aguarda_MensagemDescricaoObrigatoria();
            Assert.AreEqual("O campo Ponto de Distribuição é obrigatório!", pontoDistribuicaoPage.obterMensagemDescricaoObrigatoria());



        }

    }

}

