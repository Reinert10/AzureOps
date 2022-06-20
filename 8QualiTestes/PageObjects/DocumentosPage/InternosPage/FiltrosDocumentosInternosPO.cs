using _8QualiTestes.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QualiTestes.PageObjects.DocumentosPage.InternosPage
{
    public class FiltrosDocumentosInternosPO : BaseTest
    {


        public void filtroGeral(string etapa, string codigo, string titulo, string setor, string tipoDocumento)
        {
            selecionarCombo(By.XPath("//*[@name='_filtroStatus']"), etapa);
            escrever(By.XPath("//*[@name='_filtroCodigo']"), codigo);
            escrever(By.XPath("//*[@name='_filtroTitulo']"), titulo);
            escrever(By.XPath("//*[@name='_filtroSetorDescricao']"), setor);
            selecionarCombo(By.XPath("//*[@name='_filtroTipo']"), tipoDocumento);

        }


        public void clica_BotaoFiltrar()
        {
            clicarBotao(By.XPath("//*[@class='btn btn-primary'][1]"));
        }

        public string tituloDocumentoTabela()
        {
            return obterTexto(By.XPath("//*[@title='Documento filtro']"));
        }

        public string codigoDocumentoTabela()
        {
            return obterTexto(By.XPath("//*[@title='123']"));
        }

        public string setorDocumentoTabela()
        {
            return obterTexto(By.XPath("//*[@title='Produção']"));
        }

        public string etapaDocumentoTabela()
        {
            return obterTexto(By.XPath("//*[@title='Elaboração']"));
        }

        public string tipoDocumentoTabela()
        {
            return obterTexto(By.XPath("//*[@title='Documento filtro']"));
        }

        public void aguardaCodigoDocumentoGrid()
        {
            aguarda_ElementoPagina(By.XPath("//*[@title='123']"));
        }

    }
}
