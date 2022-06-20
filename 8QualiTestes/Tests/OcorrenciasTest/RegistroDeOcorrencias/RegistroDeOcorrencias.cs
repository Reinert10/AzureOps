using _8QualiTestes.Helpers;
using _8QualiTestes.PageObjects.OcorrenciasPage;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _8QualiTestes.Tests.OcorrenciasTest
{
    public class RegistroDeOcorrencias : BaseTest
    {

        private RegistroDeOcorrenciasPO registroDeOcorrenciasPage = new RegistroDeOcorrenciasPO();
        private ConsultarOcorrenciasPO consultarOcorrenciasPage = new ConsultarOcorrenciasPO();


        [Test]
        [TestCase("Tipo Ocorrência Registro", "Registro", "Ocorrência Registro Valido", "Origem ocorrência registro", "5", "Produção", "Gestão Da Qualidade", "Unidade A",
            "Processo A", "Risco 1", "Produto 1", "Fornecedor 1", "Cliente 1", "Matheus Selenium")]
        public void CadastroOcorrenciaRegistro(string tipoOcorrencia, string tratativa, string descricaoOcorrencia, string origem, string custo, string setorOrigem,
            string setorDestino, string unidade, string processo, string risco, string produto, string fornecedor, string cliente, string responsavelAprovarOcorrencia)
        {
            //Cadastro
            registroDeOcorrenciasPage.acessarTelaOcorrencias();
            registroDeOcorrenciasPage.ClicarBotaoAdicionarNovo();
            registroDeOcorrenciasPage.PreencherRegistroOcorrencia(tipoOcorrencia, tratativa, descricaoOcorrencia, origem, custo, setorOrigem, setorDestino, unidade, processo,
                risco, produto, fornecedor, cliente);
            registroDeOcorrenciasPage.clicarBotaoConcluirCadastroOcorrencia();

            //Exclusão
            consultarOcorrenciasPage.AcessarTelaConsultaOcorrencias();
            consultarOcorrenciasPage.ClicarBotaoFiltrar();
            consultarOcorrenciasPage.aguardaOcorrenciaGrid("Ocorrência Registro Valido");
            consultarOcorrenciasPage.ExcluirOcorrencia("Ocorrência Registro Valido");
            consultarOcorrenciasPage.aguardaJanelaExclusaoOcorrencia();

         


        }

        [Test]
        [TestCase("Tipo Ocorrência Registro", "PlnoAcao", "Ocorrência Plano de Acao Valido", "Origem ocorrência registro", "5", "Produção", "Gestão Da Qualidade", "Unidade A",
        "Processo A", "Risco 1", "Produto 1", "Fornecedor 1", "Cliente 1")]
        public void CadastroOcorrenciaPlanoDeAcao(string tipoOcorrencia, string tratativa, string descricaoOcorrencia, string origem, string custo, string setorOrigem,
        string setorDestino, string unidade, string processo, string risco, string produto, string fornecedor, string cliente)
        {


            //Cadastro
            registroDeOcorrenciasPage.acessarTelaOcorrencias();
            registroDeOcorrenciasPage.ClicarBotaoAdicionarNovo();
            registroDeOcorrenciasPage.PreencherRegistroOcorrencia(tipoOcorrencia, tratativa, descricaoOcorrencia, origem, custo, setorOrigem, setorDestino, unidade, processo,
            risco, produto, fornecedor, cliente);
            registroDeOcorrenciasPage.SelecaoResponsaveisEtapasOcorrenciaPlanoDeAcao("Matheus Selenium", "Matheus Selenium", "Matheus Selenium");
            registroDeOcorrenciasPage.clicarBotaoConcluirCadastroOcorrencia();

            //Plano de Ação
            registroDeOcorrenciasPage.acessarTelaOcorrencias();
            registroDeOcorrenciasPage.aguardaBotaoFiltrar();
            registroDeOcorrenciasPage.clicarBotaoFiltrar();
            registroDeOcorrenciasPage.aguardaOcorrenciaTabela("Ocorrência Plano de Acao Valido");
            registroDeOcorrenciasPage.clicarOcorrenciaTabela("Ocorrência Plano de Acao Valido");

            //Cadastro Ação
            registroDeOcorrenciasPage.ClicarBotaoNovaAcao();
            registroDeOcorrenciasPage.aguardaTelaCadastrarAcao();

            registroDeOcorrenciasPage.PreencherAcao("Ação Valida", "Oque valido", "Matheus Selenium", retornaDataAtual(), retornaDataAtual(), "Onde valido", "Porque valido", "Como valido",
                "Quanto valido");
            registroDeOcorrenciasPage.clicarBotaoSalvarAcao();
            registroDeOcorrenciasPage.sairFrame();
            Thread.Sleep(2000);
            registroDeOcorrenciasPage.aguarda_ElementoPagina("btnconcluirgeral");
            registroDeOcorrenciasPage.clicarBotaoConcluir();

            //Aprovação Plano de Ação
            registroDeOcorrenciasPage.clicarBotaoAprovarPlanoDeAcao();

            //Implementação Plano de Ação
            registroDeOcorrenciasPage.clicarBotaoEditarPlanoDeAcao();
            registroDeOcorrenciasPage.aguardaTelaCadastrarAcao();
            registroDeOcorrenciasPage.preencherEvidenciaAcao("Evidencia valida");
            registroDeOcorrenciasPage.clicarBotaoSalvarAcao();

            registroDeOcorrenciasPage.sairFrame();
            Thread.Sleep(2000);
            registroDeOcorrenciasPage.clicarBotaoEficaciaOcorrenciaSim();
            registroDeOcorrenciasPage.clicarBotaoConcluir();


            //Exclusão
            consultarOcorrenciasPage.AcessarTelaConsultaOcorrencias();
            consultarOcorrenciasPage.ClicarBotaoFiltrar();
            consultarOcorrenciasPage.aguardaOcorrenciaGrid("Ocorrência Plano de Acao Valido");
            consultarOcorrenciasPage.ExcluirOcorrencia("Ocorrência Plano de Acao Valido");
            consultarOcorrenciasPage.aguardaJanelaExclusaoOcorrencia();



        }

        [Test]

        [TestCase("Tipo Ocorrência Registro", "PlanoAcaoCausaRaiz", "Ocorrência Acao Corretiva Valido", "Origem ocorrência registro", "5", "Produção", "Gestão Da Qualidade", "Unidade A",
         "Processo A", "Risco 1", "Produto 1", "Fornecedor 1", "Cliente 1")]
        public void CadastroOcorrenciaAcaoCorretiva(string tipoOcorrencia, string tratativa, string descricaoOcorrencia, string origem, string custo, string setorOrigem,
          string setorDestino, string unidade, string processo, string risco, string produto, string fornecedor, string cliente)
        {


            //Cadastro
            registroDeOcorrenciasPage.acessarTelaOcorrencias();
            registroDeOcorrenciasPage.ClicarBotaoAdicionarNovo();
            registroDeOcorrenciasPage.PreencherRegistroOcorrencia(tipoOcorrencia, tratativa, descricaoOcorrencia, origem, custo, setorOrigem, setorDestino, unidade, processo,
            risco, produto, fornecedor, cliente);
            registroDeOcorrenciasPage.SelecaoResponsaveisEtapasOcorrenciaAcaoCorretiva("Matheus Selenium", "Matheus Selenium", "Matheus Selenium", "Matheus Selenium");
            registroDeOcorrenciasPage.clicarBotaoConcluirCadastroOcorrencia();


            //Ação Corretiva
            registroDeOcorrenciasPage.acessarTelaOcorrencias();
            registroDeOcorrenciasPage.aguardaBotaoFiltrar();
            registroDeOcorrenciasPage.clicarBotaoFiltrar();
            registroDeOcorrenciasPage.aguardaOcorrenciaTabela("Ocorrência Acao Corretiva Valido");
            registroDeOcorrenciasPage.clicarOcorrenciaTabela("Ocorrência Acao Corretiva Valido");


            //Diagrama de espinha de peixe
            registroDeOcorrenciasPage.preencherDiagramaDeEspinhaDePeixe("Meio ambiente valido", "Medida valido", "Maquina valido", "Metodo valido", "Mao de Obra valido",
                "Materia prima valido");
           

            //5 Porquês
            registroDeOcorrenciasPage.preencher5Porques("Primeiro Porque Valido", "Segundo Porque Valido", "Terceiro Porque Valido", "Quarto Porque Validado", "Quinto Porque Valido");

            //Brainstorm
            registroDeOcorrenciasPage.preencherBrainstorm("Matheus", "Ideia teste valida");

            registroDeOcorrenciasPage.clicarBotaoConcluir();

         

            //Cadastro Ação
            registroDeOcorrenciasPage.ClicarBotaoNovaAcao();
            registroDeOcorrenciasPage.aguardaTelaCadastrarAcao();

            registroDeOcorrenciasPage.PreencherAcao("Ação Valida", "Oque valido", "Matheus Selenium", retornaDataAtual(), retornaDataAtual(), "Onde valido", "Porque valido", "Como valido",
                "Quanto valido");
            registroDeOcorrenciasPage.clicarBotaoSalvarAcao();
            registroDeOcorrenciasPage.sairFrame();
            Thread.Sleep(2000);
            registroDeOcorrenciasPage.aguarda_ElementoPagina("btnconcluirgeral");
            registroDeOcorrenciasPage.clicarBotaoConcluir();

            //Aprovação Plano de Ação
            registroDeOcorrenciasPage.clicarBotaoAprovarPlanoDeAcao();

            //Implementação Plano de Ação
            registroDeOcorrenciasPage.clicarBotaoEditarPlanoDeAcao();
            registroDeOcorrenciasPage.aguardaTelaCadastrarAcao();
            registroDeOcorrenciasPage.preencherEvidenciaAcao("Evidencia valida");
            registroDeOcorrenciasPage.clicarBotaoSalvarAcao();

            registroDeOcorrenciasPage.sairFrame();
            Thread.Sleep(2000);
            registroDeOcorrenciasPage.clicarBotaoEficaciaOcorrenciaSim();
            registroDeOcorrenciasPage.clicarBotaoConcluir();


            //Exclusão
            consultarOcorrenciasPage.AcessarTelaConsultaOcorrencias();
            consultarOcorrenciasPage.ClicarBotaoFiltrar();
            consultarOcorrenciasPage.aguardaOcorrenciaGrid("Ocorrência Acao Corretiva Valido");
            consultarOcorrenciasPage.ExcluirOcorrencia("Ocorrência Acao Corretiva Valido");
            consultarOcorrenciasPage.aguardaJanelaExclusaoOcorrencia();



        }


    }

}


