using Assignment_nov_23.PageObjects;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_nov_23.TestScripts
{
    internal class ProductMgmtTests:CoreCodes
    {
        [Test , Order(1)]
        public void SearchTest()
        {
            var naaptolHomePage = new NaaptolHomePage(driver);
            if (!driver.Url.Equals("https://www.naaptol.com/"))
            {
                driver.Navigate().GoToUrl("https://www.naaptol.com/");
            }
            var selectProductPage=naaptolHomePage.SearechProduct("eyewear");
            Assert.True(selectProductPage.);
            Thread.Sleep(3000);
            var selectedProductPage = selectProductPage.SelectFifthItem();
            Thread.Sleep(3000);
           
            selectedProductPage.SelectSize();
            Thread.Sleep(3000);
            selectedProductPage.AddToCart();
            Thread.Sleep(3000);
            selectedProductPage.Close();
            Thread.Sleep(3000);


        }
    }
}
