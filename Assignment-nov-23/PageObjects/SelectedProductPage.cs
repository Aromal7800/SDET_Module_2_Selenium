using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_nov_23.PageObjects
{
    internal class SelectedProductPage
    {
        IWebDriver driver;
        public SelectedProductPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));    
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How=How.XPath,Using = "//a[text()='Black-3.00']")]
        IWebElement SelectGlassSize { get; set; }
        [FindsBy(How=How.Id,Using = "cart-panel-button-0")]
        IWebElement AddToCartBtn { get; set; }
        [FindsBy(How=How.XPath,Using = "//a[@title='Close']")]
        IWebElement CloseBtn { get; set;}
        public void SelectSize()
        {
            Actions actions = new Actions(driver);
            Action action = () =>
            {
                actions.MoveToElement(SelectGlassSize).
                Click().
                Build().
                Perform();
            };
            action.Invoke();
            SelectGlassSize.Click();

        }
        public void Close()
        {
            CloseBtn.Click();
        }
        public void AddToCart()
        {
            AddToCartBtn.Click();
        }
    }
}
