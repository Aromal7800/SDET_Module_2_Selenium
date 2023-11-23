using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3_nov_20
{
    internal class FlipkartTest :CoreCodes
    {
        [Test]
        public void SearchTest()
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            IWebElement webElement = fluentWait.Until(driv => driv.FindElement(By.ClassName("Pke_EE")));
           
            webElement.SendKeys("Laptop");
            webElement.SendKeys(Keys.Enter);
            IWebElement SelectLap = fluentWait.Until(driv => driv.FindElement(By.XPath("//a[contains(@class,'_1fQZEK')][1]")));
       List<string> lswindow = driver.WindowHandles.ToList();
            SelectLap.Click();
            driver.SwitchTo().Window(lswindow[0]);
            Thread.Sleep(3000);
        }
    }
}
