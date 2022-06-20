using _8QualiTestes.Helpers;
using _8QualiTestes.PageObjects.Documentos.Internos;
using _8QualiTestes.PageObjects.DocumentosPage.InternosPage;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace _8QualiTestes.Testes.Documentos.Internos
{


    public class FiltrosDocumentosInternos : BaseTest
    {

        private FiltrosDocumentosInternosPO filtrosInternosPage = new FiltrosDocumentosInternosPO();
        private DocumentosInternosPO documentosInternosPage = new DocumentosInternosPO();

        [Test]
        [TestCase("Elaboração", "", "", "", "")]
        [TestCase("", "123", "", "", "")]
        [TestCase("", "", "Documento filtro", "", "")]
        [TestCase("", "", "", "Produção", "")]
        [TestCase("", "", "", "", "Tipo documento interno")]
        public void FiltrarDocumentosInternos(string etapa, string codigo, string titulo, string setor, string tipoDocumento)
        {

            documentosInternosPage.acessarTelaDocumentosInternos();
            filtrosInternosPage.filtroGeral(etapa, codigo, titulo, setor, tipoDocumento);
            filtrosInternosPage.clica_BotaoFiltrar();
            filtrosInternosPage.aguardaCodigoDocumentoGrid();

            Assert.AreEqual("Elaboração", filtrosInternosPage.etapaDocumentoTabela());
            Assert.AreEqual("123", filtrosInternosPage.codigoDocumentoTabela());
            Assert.AreEqual("Documento filtro", filtrosInternosPage.tituloDocumentoTabela());
            Assert.AreEqual("Produção", filtrosInternosPage.setorDocumentoTabela());
            Assert.AreEqual("123", filtrosInternosPage.codigoDocumentoTabela());
        }
    }

}
