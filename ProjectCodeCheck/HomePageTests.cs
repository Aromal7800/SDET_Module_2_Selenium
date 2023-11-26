using BunnyCart;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCodeCheck
{
    internal class HomePageTests :CoreCodes
    {
        [Test]
        public void HPTests()
        {
            IWebElement SearchBar = driver.FindElement(By.ClassName("c-input__field"));//@class,'c-input__field')]"));
           // SearchBar.SendKeys("Kerala");
            //SearchBar.SendKeys(Keys.Enter);
            driver.FindElement(By.XPath("//a[contains(@title,'Become a supplier')]")).Click();
            Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//a[contains(@class,'js-navigation-link-cart')]")).Click();
        }
        
    }
}
