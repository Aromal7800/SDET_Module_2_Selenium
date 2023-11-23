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
    internal class SelectProductPage
    {
        IWebDriver driver;
        public SelectProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
       
        [FindsBy(How=How.Id,Using="productItem5")]
        IWebElement SelectFifthElement { get; set; }
        public SelectedProductPage SelectFifthItem()
        {
            Actions actions = new Actions(driver);
            Action action = () =>
            {
                actions.MoveToElement(SelectFifthElement).
                Click().
                Build().
                Perform();
            };
            action.Invoke();
            SelectFifthElement.Click();
            List<string>Windows=driver.WindowHandles.ToList();
            driver.SwitchTo().Window(Windows[1]);
            return new SelectedProductPage(driver);

        }
    }
}
