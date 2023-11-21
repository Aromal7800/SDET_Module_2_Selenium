using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelExample
{
    internal class AmazoneTest
    {
        IWebDriver? driver;
        public void initializeEdgeDriver()
        {

            driver = new EdgeDriver();//it will open the browser
            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.Maximize();
        }
        public void initializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.Maximize();
        }
        public void TitleTest()
        {
            Thread.Sleep(3000);

            // Console.WriteLine(driver.Title.Length);
            Console.WriteLine(driver.Title.Length);
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Thread.Sleep(3000);
            Console.WriteLine("Test Pass");
        }
        public void logoClickTest()
        {
            driver.FindElement(By.Id("nav-logo-sprites")).Click();
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Thread.Sleep(3000);
            Console.WriteLine("Logo click Test Pass");
        }
        public void SearchProductTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobiles");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Assert.That(("Amazon.com : mobiles").Equals(driver.Title) && (driver.Url.Contains("mobiles")));
            Console.WriteLine("Search Product Test Pass");
        }
        public void ReloadHomePage()
        {
            driver.Navigate().GoToUrl("https://www.amazon.com");
        }
        public void TodaysDealsTest()
        {
            IWebElement todaysdeals= driver.FindElement(By.LinkText("Today's Deals"));
            if(todaysdeals == null) 
            {
            throw new NoSuchElementException("Not Available");
            }
            Thread.Sleep(3000);
            todaysdeals.Click();
           Assert.That(driver.FindElement(By.TagName("h1")).Text.Equals("Today's Deals"));
            Console.WriteLine("STodays Deals Test Passed");

        }
        public void SignInAccountListTest()
        {
            IWebElement hellosignin = driver.FindElement(By.Id("nav-link-accountList-nav-line-1"));
            if (hellosignin == null)
            {
                throw new NoSuchElementException("Hello ,Signin is not present");
            }
            IWebElement accountsandlist = driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]/span"));
            if (accountsandlist == null)
            {
                throw new NoSuchElementException("Hello Account List is not present");           
            }
           // accountsandlist.
            
            Assert.That(hellosignin.Text.Equals("Hello, sign in"));
            Console.WriteLine("SignInAccountListTest is passed");
            Assert.That(accountsandlist.Text.Equals("Account & Lists"));
            Console.WriteLine("accountsandlist is passed");
        }
        public void SearchAndFilterProductByBrandTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobile Phones");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            IWebElement MotoCheckBox = driver.FindElement(By.XPath("//*[@id='p_89/Motorola']/span/a/div/label/i"));
           
            MotoCheckBox.Click();

            Thread.Sleep(3000);
           // Console.WriteLine("MotoCheckBox.GetAttribute(\"checked\")");
          //  Console.WriteLine(MotoCheckBox);
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Motorola\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("Moto Selected");
            Thread.Sleep(3000);

            driver.FindElement(By.ClassName("a-expander-prompt")).Click();
            IWebElement XiaomiCheckBox=driver.FindElement(By.XPath("//*[@id='p_89/Xiaomi']/span/a/div/label/i"));
            Thread.Sleep(3000);

            XiaomiCheckBox.Click();
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Xiaomi\"]/span/a/div/label/input")).Selected);
            Console.WriteLine("Xiaomi Selected");
            Thread.Sleep(3000);
        }
        public void Destruct()
        {
            Thread.Sleep(3000);
            driver.Close();
        }

    }
}
