using _8QualiTestes.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QualiTestes.PageObjects.DocumentosPage.ExternoPage
{
    public class FiltrosDocumentosExternosPO : BasePage
    {

        public void filtrosGerais(string codigo, string titulo, string origem)
        {
            escrever(By.XPath("//*[@name='_filtroCodigo']"), codigo);
            escrever(By.XPath("//*[@name='_filtroTitulo']"), titulo);
            escrever(By.XPath("//*[@name='_filtroOrigem']"), origem);
        }

        public void clica_BotaoFiltrar()
        {
            clicarBotao(By.XPath("//*[@class='btn btn-primary'][1]"));
        }

        public string tituloDocumentoTabela()
        {
            return obterTexto(By.XPath("//*[@title='Documento externo filtro']"));
        }

        public string codigoDocumentoTabela()
        {
            return obterTexto(By.XPath("//*[@title='123']"));
        }

        public string origemDocumentoTabela()
        {
            return obterTexto(By.XPath("//*[@title='Origem filtro']"));
        }

    }
}
