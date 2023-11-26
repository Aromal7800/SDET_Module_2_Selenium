using Assignment_nov_23.PageObjects;
using BunnyCart.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_nov_23.TestScripts
{
    internal class ProductMgmtTests : CoreCodes
    {
        [Test, Order(1)]
        public void SearchTest()
        {
            var naaptolHomePage = new NaaptolHomePage(driver);
            if (!driver.Url.Equals("https://www.naaptol.com/"))
            {
                driver.Navigate().GoToUrl("https://www.naaptol.com/");
            }
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "SearchInput";

            List<SearchData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {

                string? SerchText = excelData?.SearchText;



                var selectProductPage = naaptolHomePage.SearechProduct(SerchText);


                Thread.Sleep(3000);
                try
                {
                    Assert.That(driver.Url.Contains("eyewear"));
                    test = extent.CreateTest("Search Test - Pass");
                    test.Pass("Search eyewear success");
                    Console.WriteLine("ERCP");
                }
                catch (AssertionException)
                {
                    test = extent.CreateTest("Search Test - Fail");
                    test.Fail("Search eyewear failed");
                    Console.WriteLine("ERCF");
                }

                var selectedProductPage = selectProductPage.SelectFifthItem();
                Thread.Sleep(3000);


                selectedProductPage.SelectSize();
                Thread.Sleep(3000);
                selectedProductPage.AddToCart();
                Thread.Sleep(3000);
                selectedProductPage.IncreseQantityMethod("2");
                Thread.Sleep(3000);
                selectedProductPage.RemoveBtn();
                selectedProductPage.Close();
                Thread.Sleep(3000);


            }
        }
    }
}
