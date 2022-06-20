using _8QualiTestes.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QualiTestes.PageObjects.DocumentosPage.RegistrosPage
{
    public class FiltrosRegistroDocumentosPO : BasePage
    {


        public void FiltragemRegistros(string codigo, string titulo)
        {
            escrever(By.XPath("//*[@name='_filtroCodigo']"), codigo);
            escrever(By.XPath("//*[@name='_filtroTitulo']"), titulo);
        }

        public void botaoFiltrar()
        {
            clicarBotao(By.XPath("//*[@class='btn btn-primary'][1]"));
        }

        public void aguardaTituloDocumentoGrid()
        {
            aguarda_ElementoPagina(By.XPath("//*[@title='Registro Filtro']"));
        }

        public string tituloDocumentoTabela()
        {
            return obterTexto(By.XPath("//*[@title='Registro Filtro']"));
        }

        public string codigoDocumentoTabela()
        {
            return obterTexto(By.XPath("//*[@title='123']"));
        }

    }
}
