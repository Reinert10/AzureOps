using _8QualiTestes.Helpers;
using _8QualiTestes.PageObjects.Documentos.Externo;
using _8QualiTestes.PageObjects.DocumentosPage.ExternoPage;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _8QualiTestes.Testes.Documentos.Externo
{
    public class FiltrosDocumentosExternos : BaseTest
    {

        private FiltrosDocumentosExternosPO filtrosDocumentosExternosPage = new FiltrosDocumentosExternosPO();
        private DocumentoExternoPO documentoExternoPage = new DocumentoExternoPO();

        [Test]
        [TestCase("123", "", "")]
        [TestCase("", "Documento externo filtro", "")]
        [TestCase("", "", "Origem filtro")]
        public void FiltrarDocumentosExternos(string codigo, string titulo, string origem)
        {
            documentoExternoPage.acessarTelaDocumentoExterno();
            filtrosDocumentosExternosPage.filtrosGerais(codigo, titulo, origem);
            filtrosDocumentosExternosPage.clica_BotaoFiltrar();
            documentoExternoPage.aguardaTituloDocumentoGrid("Documento externo filtro");


            Assert.AreEqual("Documento externo filtro", filtrosDocumentosExternosPage.tituloDocumentoTabela());
            Assert.AreEqual("123", filtrosDocumentosExternosPage.codigoDocumentoTabela());
            Assert.AreEqual("Origem filtro", filtrosDocumentosExternosPage.origemDocumentoTabela());
        }

    }

}
