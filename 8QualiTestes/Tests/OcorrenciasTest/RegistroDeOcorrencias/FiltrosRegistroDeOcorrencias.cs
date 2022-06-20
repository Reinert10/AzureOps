using _8QualiTestes.Helpers;
using _8QualiTestes.PageObjects.OcorrenciasPage;
using _8QualiTestes.PageObjects.OcorrenciasPage.RegistroDeOcorrenciasPage;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _8QualiTestes.Tests.OcorrenciasTest
{
    public class FiltrosRegistroDeOcorrencias : BaseTest
    {

        private FiltrosRegistroDeOcorrenciasPO filtrosRegistroDeOcorrenciasPage = new FiltrosRegistroDeOcorrenciasPO();
        private RegistroDeOcorrenciasPO registroDeOcorrenciasPage = new RegistroDeOcorrenciasPO();

        [Test]
        
        public void FiltrarRegistroDeOcorrencias()
        {
            //Filtro Status
            registroDeOcorrenciasPage.acessarTelaOcorrencias();
            filtrosRegistroDeOcorrenciasPage.selecionarFiltroStatus("Plano de ação");
            filtrosRegistroDeOcorrenciasPage.clicarBotaoFiltrar();
            Assert.AreEqual("Plano de ação", filtrosRegistroDeOcorrenciasPage.obterEtapaOcorrenciaGrid());
            Assert.AreEqual("2022/6-142", filtrosRegistroDeOcorrenciasPage.obterCodigoOcorrenciaGrid());

            registroDeOcorrenciasPage.acessarTelaOcorrencias();
            filtrosRegistroDeOcorrenciasPage.preencherCampoResponsavel("Matheus Selenium");
            filtrosRegistroDeOcorrenciasPage.clicarBotaoFiltrar();
            Assert.AreEqual("Matheus Selenium", filtrosRegistroDeOcorrenciasPage.obterResponsavelOcorrenciaGrid());
            Assert.AreEqual("2022/6-142", filtrosRegistroDeOcorrenciasPage.obterCodigoOcorrenciaGrid());

            registroDeOcorrenciasPage.acessarTelaOcorrencias();
            filtrosRegistroDeOcorrenciasPage.preencherCampoCodigo("2022/6-142");
            filtrosRegistroDeOcorrenciasPage.clicarBotaoFiltrar();
            Assert.AreEqual("2022/6-142", filtrosRegistroDeOcorrenciasPage.obterCodigoOcorrenciaGrid());
            Assert.AreEqual("Ocorrencia filtro", filtrosRegistroDeOcorrenciasPage.obterDescricaoOcorrenciaGrid());

            registroDeOcorrenciasPage.acessarTelaOcorrencias();
            filtrosRegistroDeOcorrenciasPage.preencherSetorOrigem("2022/6-9");
            filtrosRegistroDeOcorrenciasPage.clicarBotaoFiltrar();
            Assert.AreEqual("2022/6-142", filtrosRegistroDeOcorrenciasPage.obterCodigoOcorrenciaGrid());
            Assert.AreEqual("asdasd", filtrosRegistroDeOcorrenciasPage.obterDescricaoOcorrenciaGrid());



        }

    }
}

