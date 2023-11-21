using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_nov_14
{
    internal class GoogleHPTests
    {
        IWebDriver driver;
        public void initialize()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
        }
        public void navigator()
        {
            driver.Navigate().GoToUrl("https://www.yahoo.com/");
          //  Thread.Sleep(1000);
            driver.Navigate().Back();
            Thread.Sleep(1000);
            driver.Navigate().Forward();
            Thread.Sleep(1000); 
            driver.Navigate().Back();
            Thread.Sleep(1000);
            IWebElement SearchInputBox = driver.FindElement(By.Id("APjFqb"));
            SearchInputBox.SendKeys("What is new for Diwali?");
            
            Thread.Sleep(5000);
            IWebElement SubmitButton = driver.FindElement(By.ClassName("gNO89b"));//Name("btnK"));
            SubmitButton.Click();
            Console.WriteLine(SubmitButton.GetCssValue + "GetCssValue");
           // Console.WriteLine(SubmitButton.Text+ "Text");
           // Console.WriteLine(SubmitButton.TagName+ "TagName");
            //Console.WriteLine(SubmitButton.Submit+ "Submit");
           // Console.WriteLine(SubmitButton.Size+"Size");

            Assert.That(driver.Title.Contains("Diwali"));
            Console.WriteLine("Diwali is present");
            driver.Navigate().Refresh();
            
        }
        public void Destruct()
        {
            driver.Close();
        }
    }
}
