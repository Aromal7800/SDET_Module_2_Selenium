using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.WebAuthn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_nov_14
{
    internal class Amazone
    {
        IWebDriver driver;
        public void initialize()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.amazon.com/";
        }
        public void TitleCheck()
        {
            Console.WriteLine(driver.Title) ;
            Assert.AreEqual("Amazon.com. Spend less. Smile more.",driver.Title) ;
            Console.WriteLine("correct TItle");

        }
        public void UrlCheck()
        {
            Assert.That(driver.Url.Contains(".com"));
            Console.WriteLine("Correct url");
        }
        public void Destruct()
        {
            driver.Close() ;
        }
    }
}
