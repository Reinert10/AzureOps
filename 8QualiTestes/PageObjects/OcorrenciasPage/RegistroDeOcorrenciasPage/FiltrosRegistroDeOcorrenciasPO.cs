using _8QualiTestes.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace _8QualiTestes.PageObjects.OcorrenciasPage.RegistroDeOcorrenciasPage
{
    public class FiltrosRegistroDeOcorrenciasPO : BasePage
    {

        public void selecionarFiltroStatus(string opcao)
        {
            selecionarCombo("SearchStatus", opcao);
        }

        public void preencherCampoResponsavel(string valor)
        {
            escrever("SearchResponsavel", valor);
        }

        public void preencherCampoCodigo(string codigo)
        {
            escrever("SearchNumeroDocumentoFilter", codigo);
        }

        public void preencherSetorOrigem(string valor)
        {
            escrever("SearchSetor", valor);
        }
       


        public void clicarBotaoFiltrar()
        {
            clicarBotao(By.XPath("//*[@id='frm_consultaocorrencia']//button[@class='btn btn-inverse btn-8-ideia-padrao-azul btn-8-ideia-filtrar']"));
            aguarda_ElementoPagina(By.XPath("//*[@title='Plano de ação']"));
        }

        public string obterEtapaOcorrenciaGrid()
        {
            return obterTexto(By.XPath("//*[@title='Plano de ação']"));
        }

        public string obterDescricaoOcorrenciaGrid()
        {
            return obterTexto(By.XPath("//*[@title='asdasd']"));
        }

        public string obterResponsavelOcorrenciaGrid()
        {
            return obterTexto(By.XPath("//*[@title='Matheus Selenium']"));
        }

        public string obterCodigoOcorrenciaGrid()
        {
            return obterTexto(By.XPath("//*[@title='2022/6-9']"));
        }
    }
}
