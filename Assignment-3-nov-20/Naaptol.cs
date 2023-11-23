using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_nov_20
{
    internal class Naaptol : CoreCodes
    {
       
        [Test]
        [Order(0)]
        public void SearchTest()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement SerachElement = fluentWait.Until(dri => dri.FindElement(By.Id("header_search_text")));
            SerachElement.SendKeys("eyewear");
            SerachElement.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
        }
        [Test]
        [Order(1)]  
        public void FIndFifthElement()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement SelectFifthElement = fluentWait.Until(dri => dri.FindElement(By.Id("productItem5")));
            Actions actions = new Actions(driver);
            Action mouseOverAction = () => actions
            .MoveToElement(SelectFifthElement)
            .Build()
            .Perform();

            mouseOverAction.Invoke();


            SelectFifthElement.Click();
            Thread.Sleep(3000);
            List<string> lswindow = driver.WindowHandles.ToList();
            

            driver.SwitchTo().Window(lswindow[1]);
            Assert.IsTrue(lswindow.Count > 0);
            
        }


        [Test]
        [Order(2)]
        public void SelectSize()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement selectSize= fluentWait.Until(dri => dri.FindElement(By.XPath("//a[text()='Black-3.00']")));
            selectSize.Click();
            Thread.Sleep(3000);
            Assert.AreEqual("Buy Reading Glasses with LED Lights (LRG4) Online at Best Price in India on Naaptol.com", driver.Title);
            //driver.FindElement(By.Id("cart-panel-button-0")).Click();
        }
        [Test]
        [Order(3)]
        public void AddToCart()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement addToCart = fluentWait.Until(d => d.FindElement(By.Id("cart-panel-button-0")));
            
            Actions cartActions = new Actions(driver);
            Action cartAction = () =>
            {
                cartActions.MoveToElement(addToCart).
                Click().
                Build().
                Perform();
            };
            cartAction.Invoke();
            Thread.Sleep(3000);
            Assert.That(driver.Url.Contains("reading-glasses-with-led-lights-lrg4/"));
           // addToCart.Click();
        }
        [Test]
        [Order(4)]
        public void closeTest()
        {
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(20);
            fluentwait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element not found!!!";

            IWebElement CloseBtn = fluentwait.Until(d => d.FindElement(By.XPath("//a[@title='Close']")));
            IWebElement CartText = fluentwait.Until(d => d.FindElement(By.XPath("//*[text()='My Shopping Cart: ']")));
            Assert.IsTrue(CartText.Text.Contains("My Shopping Cart: "));
            Actions CloseBtnActions = new Actions(driver);
            Action CloseBtnAction = () =>
            {
                CloseBtnActions.Click(CloseBtn);
            };
            CloseBtnAction.Invoke();
            Thread.Sleep(3000);
        }

    }
}
