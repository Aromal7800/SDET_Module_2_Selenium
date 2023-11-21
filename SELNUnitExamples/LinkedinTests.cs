using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELNUnitExamples
{
    [TestFixture]
    internal class LinkedinTests :CoreCodes
    {
        [Test]
        [Author("Aromal", "Aromal7800@gmail.com")]
        [Description("check for valid Login")]
        [Category("Reggretion Testing")]
        public void LoginTest()
        {
            WebDriverWait wait=new WebDriverWait(driver,TimeSpan.FromSeconds(3));//Explicit Wait
          // IWebElement emailInput = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("session_key")));//Explicit Wait untill the element is visible
          //  IWebElement emailInput=wait.Until(driv=>driv.FindElement(By.Id("session_key")))  ;
           // IWebElement passwordInput = wait.Until(driv => driv.FindElement(By.Id("session_password")));
            //IWebElement passwordInput = driver.FindElement(By.Id("session_password"));
            DefaultWait<IWebDriver> fluentWait=new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout=TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
             IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));
            fluentWait.Message = "Element Not Found";
            emailInput.SendKeys("1234@gmail.com");
            passwordInput.SendKeys("1234");

          //  driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(3);//

        }
      //  [Test]
        [Author("Aromal", "Aromal7800@gmail.com")]
        [Description("check for invalid Login")]
        [Category("Smoke Testing")]
        public void LoginTestWithInvalidcred()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));
            fluentWait.Message = "Element Not Found";
            emailInput.SendKeys("1234@gmail.com");
            passwordInput.SendKeys("1234");
            ClearForm(emailInput);
            ClearForm(passwordInput);
            Thread.Sleep(3000);
            emailInput.SendKeys("456@gmail.com");
            passwordInput.SendKeys("456");
            ClearForm(emailInput);
            ClearForm(passwordInput);
            Thread.Sleep(3000);
            emailInput.SendKeys("678@gmail.com");
            passwordInput.SendKeys("1234");
            ClearForm(emailInput);
            ClearForm(passwordInput);
            Thread.Sleep(3000);
        }
        void ClearForm(IWebElement element)
        {
            element.Clear();
        }
        /*
        [Test]
        [Author("AAA", "AAA@gmail.com")]
        [Category("Smoke Testing"),Description("LoginTestInvlid")]
        [TestCase("Aromal@gmail.com","1234567")]
        [TestCase("Aro@gmail.com", "1234")]
        [TestCase("Arun@gmail.com", "0987")]
        public void LoginTestWithInvalidcred1(string email,string password)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));
            emailInput.SendKeys(email); passwordInput.SendKeys(password);
            ClearForm(emailInput);
            ClearForm(passwordInput);
            Thread.Sleep(3000);
        }
        */
       // [Test]
        [Author("AAA", "AAA@gmail.com")]
        [Category("Smoke Testing"), Description("LoginTestInvlid")]
        [TestCaseSource(nameof(InvalidLoginData))]
        public void LoginTestWithInvalidcred1(string email, string password)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement emailInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_key")));
            IWebElement passwordInput = fluentWait.Until(driv => driv.FindElement(By.Id("session_password")));
            emailInput.SendKeys(email); passwordInput.SendKeys(password);
            ClearForm(emailInput);
            ClearForm(passwordInput);
            Thread.Sleep(3000);
        }
        static object[] InvalidLoginData()
        {
            return new object[]
            {
                new object[] {"abc@xyz.com","1234"},
                new object[] {"tyu@xyz.com","1234"},
                 new object[] {"abc@xyz.com","1234"},
                new object[] {"tyu@xyz.com","1234"}

            };
        }
    }
}
