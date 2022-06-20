using _8QualiTestes.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace _8QualiTestes.PageObjects.OcorrenciasPage
{
    public class RegistroDeOcorrenciasPO : BasePage
    {

        public RegistroDeOcorrenciasPO acessarTelaOcorrencias()
        {
            acessarTela("https://app.8quali.com.br/GestaoNaoConformidade");
            return this;
        }

        public void ClicarBotaoAdicionarNovo()
        {
            clicarBotao("novoocorrencia");
        }

        public void PreencherRegistroOcorrencia(string tipoOcorrencia, string tratativa, string descricaoOcorrencia, string origem, string custo, string setorOrigem,
            string setorDestino, string unidade, string processo, string risco, string produto, string fornecedor, string cliente)
        {

            aguarda_ElementoPagina("TipoDeOcorrenciaId");

            selecionarCombo("TipoDeOcorrenciaId", tipoOcorrencia);
            clicarBotao(By.XPath("//*[@value='" + tratativa + "']"));
            escrever("DescricaoDaNaoConformidade", descricaoOcorrencia);
            selecionarCombo("OrigemNaoConformidadeId", origem);
            escrever("Custo", custo);
            selecionarCombo("SetorEmitenteId", setorOrigem);
            selecionarCombo("SetorDestinoId", setorDestino);
            selecionarCombo("EmpresaAuditadaId", unidade);
            selecionarCombo("ProcessoId", processo);
            selecionarCombo("GerirRiscoId", risco);
            selecionarCombo("ProdutoId", produto);
            selecionarCombo("FornecedorId", fornecedor);
            selecionarCombo("ClienteId", cliente);


        }

        public void preencherDiagramaDeEspinhaDePeixe(string meioAmbiente, string medida, string maquina, string metodo, string maoDeObra, string materiaPrima)
        {
            //Meio Ambiente
            aguarda_ElementoPagina(By.XPath("//*[@id='divMasterView']//a[.='Diagrama de espinha de peixe (Ishikawa)']"));
            clicarLink("Diagrama de espinha de peixe (Ishikawa)");
            aguarda_ElementoPagina("MeioAmbiente");
            escrever("MeioAmbiente", meioAmbiente);
            clicarBotao(By.XPath("//*[@id='tablemeioambiente']//button"));
            aguarda_BotaoClicavel(By.XPath("//*[@id='tablemeioambiente']//input[@type='checkbox']"));
           

            //Medida
            escrever("Medida", medida);
            clicarBotao(By.XPath("//*[@id='tablemedida']//button"));
            aguarda_BotaoClicavel(By.XPath("//*[@id='tablemedida']//input[@type='checkbox']"));


            //Maquina
            escrever("Maquina", maquina);
            clicarBotao(By.XPath("//*[@id='tablemaquina']//button"));
            aguarda_BotaoClicavel(By.XPath("//*[@id='tablemaquina']//input[@type='checkbox']"));
            

            //Metodo
            escrever("Metodo", metodo);
            clicarBotao(By.XPath("//*[@id='tablemetodo']//button"));
            aguarda_BotaoClicavel(By.XPath("//*[@id='tablemetodo']//input[@type='checkbox']"));
           

            //Mao de Obra
            escrever("MaoDeObra", maoDeObra);
            clicarBotao(By.XPath("//*[@id='tablemaodeobra']//button"));
            aguarda_BotaoClicavel(By.XPath("//*[@id='tablemaodeobra']//input[@type='checkbox']"));
          

            //Materia Prima
            escrever("MateriaPrima", materiaPrima);
            clicarBotao(By.XPath("//*[@id='tablemateriaprima']//button"));
            aguarda_BotaoClicavel(By.XPath("//*[@id='tablemateriaprima']//input[@type='checkbox']"));
            
        }

        public void preencher5Porques(string primeiroPorque, string segundoPorque, string terceiroPorque, string quartoPorque, string quintoPorque)
        {
            
            clicarLink("5 Porquês");

            //Primeiro porque
            aguarda_EscreveInputPagina("PrimeiroPorque", primeiroPorque);
            clicarBotao("btnSubmit5Porque");
            aguarda_BotaoClicavel(By.XPath("//*[@id='CincoPorque_1__Causa']"));

            //Segundo porque
            aguarda_EscreveInputPagina("PrimeiroPorque", segundoPorque);
            clicarBotao("btnSubmit5Porque");
            aguarda_BotaoClicavel(By.XPath("//*[@id='CincoPorque_2__Causa']"));

            //Terceiro porque
            aguarda_EscreveInputPagina("PrimeiroPorque", terceiroPorque);
            clicarBotao("btnSubmit5Porque");
            aguarda_BotaoClicavel(By.XPath("//*[@id='CincoPorque_3__Causa']"));

            //Quarto porque
            aguarda_EscreveInputPagina("PrimeiroPorque", quartoPorque);
            clicarBotao("btnSubmit5Porque");
            aguarda_BotaoClicavel(By.XPath("//*[@id='CincoPorque_4__Causa']"));

            //Quinto porque
            aguarda_EscreveInputPagina("PrimeiroPorque", quintoPorque);
            clicarBotao("btnSubmit5Porque");
            aguarda_BotaoClicavel(By.XPath("//*[@id='CincoPorque_5__Causa']"));


            

        }

        public void preencherBrainstorm(string nome, string ideia)
        {
            clicarLink("Brainstorm");
            aguarda_EscreveInputPagina("Nome", nome);
            escrever("Ideia", ideia);
            clicarBotao("btnSubmitParticipante");

        }

        public void PreencherAcao(string nomeDoPlano, string oquePlano, string quemPlano, string quandoDePlano, string quandoAtePlano, string ondePlano, string porquePlano, string comoPlano, string quantoPlano)
        {
            aguarda_EscreveInputPagina("NomeDoPlano", nomeDoPlano);
            escrever("OQue", oquePlano);
            selecionarCombo("UsuarioQuemId", quemPlano);
            escrever("Quando", quandoDePlano);
            escrever("QuandoAte", quandoAtePlano);
            escrever("Onde", ondePlano);
            escrever("Porque", porquePlano);
            escrever("Como", comoPlano);
            escrever("Quanto", quantoPlano);
        }

        public void preencherEvidenciaAcao(string valor)
        {
            rodarMouse("Evidencia");
            aguarda_EscreveInputPagina("Evidencia", valor);
        }

        public void clicarBotaoSalvarAcao()
        {
            clicarBotao("botao-salvar-modal");
        }

        public void clicarBotaoConcluirCadastroOcorrencia()
        {
            aguarda_BotaoClicavel("btnconcluir");
        }

        public void clicarBotaoConcluir()
        {
            clicarBotao("btnconcluirgeral");
        }

        public void clicarBotaoAprovarPlanoDeAcao()
        {
            aguarda_ElementoPagina("btnaprovar");
            clicarBotao("btnaprovar");
        }

        public void clicarBotaoEditarPlanoDeAcao()
        {
            aguarda_ElementoPagina(By.XPath("//*[@id='div_acoes_implementacao']/div[1]/div/div/button"));

            clicarBotao(By.XPath("//*[@id='div_acoes_implementacao']//table//tr[2]/td[14]/button"));
        }

        public void clicarBotaoEficaciaOcorrenciaSim()
        {
            aguarda_BotaoVisivel("botaosim");
        }

        public void SelecaoResponsaveisEtapasOcorrenciaPlanoDeAcao(string responsavelPlanoDeAcao, string responsavelValidacaoPlanoDeAcao,
            string responsavelEficacia)
        {
            rodarMouse("UsuarioResponsavelPlanoDeAcaoId");
            aguarda_ElementoPagina("UsuarioResponsavelPlanoDeAcaoId");
            //selecionarCombo("UsuarioResponsavelAnaliseCausaRaizId", responsavelCausaRaiz);
            selecionarCombo("UsuarioResponsavelPlanoDeAcaoId", responsavelPlanoDeAcao);
            selecionarCombo("UsuarioResponsavelAprovacaoPlanoDeAcaoId", responsavelValidacaoPlanoDeAcao);
            selecionarCombo("UsuarioEficaciaId", responsavelEficacia);

        }

        public void SelecaoResponsaveisEtapasOcorrenciaAcaoCorretiva(string responsavelCausaRaiz, string responsavelPlanoDeAcao, string responsavelValidacaoPlanoDeAcao,
            string responsavelEficacia)
        {
            rodarMouse("UsuarioResponsavelPlanoDeAcaoId");
            aguarda_ElementoPagina("UsuarioResponsavelPlanoDeAcaoId");
            selecionarCombo("UsuarioResponsavelAnaliseCausaRaizId", responsavelCausaRaiz);
            selecionarCombo("UsuarioResponsavelPlanoDeAcaoId", responsavelPlanoDeAcao);
            selecionarCombo("UsuarioResponsavelAprovacaoPlanoDeAcaoId", responsavelValidacaoPlanoDeAcao);
            selecionarCombo("UsuarioEficaciaId", responsavelEficacia);

        }

        public void aguardaBotaoFiltrar()
        {
            aguarda_ElementoPagina(By.XPath("//*[@class='btn btn-inverse btn-8-ideia-padrao-azul btn-8-ideia-filtrar']"));
        }

        public void clicarBotaoFiltrar()
        {
            aguarda_BotaoClicavel(By.XPath("//*[@class='btn btn-inverse btn-8-ideia-padrao-azul btn-8-ideia-filtrar']"));
        }

        public void aguardaOcorrenciaTabela(string descricao)
        {
            
            aguarda_ElementoPagina(By.XPath("//*[@title='" + descricao + "']"));

        }

        public void clicarOcorrenciaTabela(string descricao)
        {

            clicarBotao(By.XPath("//*[@title='" + descricao + "']"));

        }

        public void ClicarBotaoNovaAcao()
        {
            aguarda_BotaoClicavel("btninseriracaoabaplanoacao");
        }

        public void LocalizarCadastroOcorrencia()
        {
            rodarMouse(By.XPath("//*[@title='Ocorrência Plano de Acao Valido']"));
        }

        public void aguardaTelaCadastrarAcao()
        {

            entrarFrame(".cboxIframe");

        }

        public void aguardaCampoNomePlanoDeAcao()
        {
            aguarda_ElementoPagina("NomeDoPlano");
        }
    }
}
