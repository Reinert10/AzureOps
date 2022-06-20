using _8QualiTestes.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QualiTestes.PageObjects.OcorrenciasPage
{
    public class ConsultarOcorrenciasPO : BasePage
    {


        public ConsultarOcorrenciasPO AcessarTelaConsultaOcorrencias()
        {
            acessarTela("https://app.8quali.com.br/GestaoNaoConformidade/ConsultaNaoConformidade");
            return this;
        }

        


        public void ExcluirOcorrencia(string dados)
        {
            obterCelula("Descrição", dados, "Excluir", "nao_conformidade_table").FindElement(By.XPath("./button")).Click();
        }

        public void aguardaJanelaExclusaoOcorrencia()
        {
            aguarda_BotaoVisivel("Confirmar");
        }

        public void aguardaOcorrenciaGrid(string descricaoOcorrencia)
        {
            aguarda_ElementoPagina(By.XPath("//*[@title='" + descricaoOcorrencia + "']"));
        }

        public void ClicarBotaoFiltrar()
        {
            clicarBotao(By.XPath("//*[@class='btn btn-primary'][1]"));
        }
    }
}
