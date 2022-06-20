using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace _8QualiTestes.Helpers
{
    public class DriverFactory
    {

        protected static IWebDriver driver;

        public DriverFactory()
        {

        }


        public static IWebDriver getDriver()
        {
            if (driver == null)
            {
                
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Url = "https://app.8quali.com.br/";


            }
            return driver;
        }


        public static void killDriver()
        {


            driver.Quit();



        }

    }

}
