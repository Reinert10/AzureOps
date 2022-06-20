using _8QualiTestes.Helpers;
using _8QualiTestes.PageObjects.Documentos.Registros;
using _8QualiTestes.PageObjects.DocumentosPage.RegistrosPage;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _8QualiTestes.Tests.Documentos.Registros
{
    public class RegistroDocumentosFiltros : BaseTest
    {

        private RegistrosPO registrosPage = new RegistrosPO();
        private FiltrosRegistroDocumentosPO filtrosRegistro = new FiltrosRegistroDocumentosPO();

        [Test]
        [TestCase("123", "")]
        [TestCase("", "Registro Filtro")]

        public void FiltragemRegistros(string codigo, string titulo)
        {
            registrosPage.acessarTelaRegistro();
            filtrosRegistro.FiltragemRegistros(codigo, titulo);
            filtrosRegistro.botaoFiltrar();
            filtrosRegistro.aguardaTituloDocumentoGrid();

            Assert.AreEqual("Registro Filtro", filtrosRegistro.tituloDocumentoTabela());
            Assert.AreEqual("123", filtrosRegistro.codigoDocumentoTabela());


        }

    }
}
