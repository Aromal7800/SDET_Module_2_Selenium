using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Edge;

namespace SelExample
{
    internal class GHPTests
    {
        IWebDriver? driver;
        public void initializeEdgeDriver()
        {

            driver = new EdgeDriver();//it will open the browser
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }
        public void initializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }
        public void TitleTest()
        {
            Thread.Sleep(1000);

            // Console.WriteLine(driver.Title.Length);
            Console.WriteLine(driver.Title.Length);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Test Pass");
        }
        public void PageSourceTest()
        {
            //  Console.WriteLine("Page Source :\n"+driver.PageSource);
            //   Console.WriteLine("Page Source Length : \n"+driver.PageSource.Length);
            Console.WriteLine("Title Test Pass");

        }
        public void PageURLTest()
        {
            //  Console.WriteLine(driver.Url);
            //Console.WriteLine(driver.Url.Length);
            Assert.AreEqual(driver.Url, "https://www.google.com/");
            Console.WriteLine("URL - Test Pass");
        }
        
        public void GoogleSearchTest()
        {
            IWebElement SearchInputBox = driver.FindElement(By.Id("APjFqb"));

            SearchInputBox.SendKeys("hp laptop");
            Thread.Sleep(5000);
            IWebElement SubmitButton = driver.FindElement(By.ClassName("gNO89b"));//Name("btnK"));
            SubmitButton.Click();
            Assert.AreEqual("hp laptop - Google Search",driver.Title);

            Console.WriteLine("Google Search - Pass");
           // Thread.Sleep(3000);
           
        }
        
        public void GmailLinkTest()
        {
            driver.Navigate().Back();

            Thread.Sleep(3000);

            driver.FindElement(By.LinkText("Gmail")).Click();
            // driver.FindElement(By.PartialLinkText("ma")).Click();

            Assert.That(driver.Url.Contains("gmail"));
            Thread.Sleep(3000);
            //  Assert.AreEqual(driver.Title, "Gmail");
            Console.WriteLine("GmailLinkTest Passed");

        }
        public void LocalizationTest()
        {
            driver.Navigate().Back();

            string loc = driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;
            Thread.Sleep(2000);
           Assert.That(loc.Equals("India"));
            Console.WriteLine("LocalizationTest Passed");
        }
        public void ImagesLinkTest()
        {
            driver.Navigate().Back();
            Thread.Sleep(3000);

            driver.FindElement(By.PartialLinkText("mag")).Click();
            // driver.FindElement(By.PartialLinkText("ma")).Click();

            Assert.That(driver.Title.Contains("Images"));
            Thread.Sleep(3000);
            //  Assert.AreEqual(driver.Title, "Gmail");
            Console.WriteLine("ImagesLinkTest Passed");

        }
        public void YoutubeTest()
        {
           
            driver.FindElement(By.XPath("//*[@id='gbwa']/div/a")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div/c-wiz/div/div/div[2]/div[2]/div[1]/ul/li[4]/a/div/span")).Click();
            Assert.That("Youtube".Equals(driver.Title));
        }
        public void Destruct()
        {
            driver.Close();
        }
    }
}
