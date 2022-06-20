
using _8QualiTestes.Helpers;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{

    public class LoginPO : BasePage
    {


        public void EfetuarLoginComCredenciais()
        {

            escrever("UserName", "matheuselenium@gmail.com");
            escrever("Password", "123456");
            clicarBotao("buttonLogin");
        }

    }
}

