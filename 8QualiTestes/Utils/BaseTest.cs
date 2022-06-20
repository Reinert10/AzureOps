using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8QualiTestes.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;

namespace _8QualiTestes.Helpers
{
    public class BaseTest : BasePage
    {

        private LoginPO loginPage = new LoginPO();


        [OneTimeSetUp]
        public void inicializa()
        {
            loginPage.EfetuarLoginComCredenciais();

        }

        [OneTimeTearDown]
        public void finaliza()
        {


            killDriver();
            driver = null;

        }

    }
}