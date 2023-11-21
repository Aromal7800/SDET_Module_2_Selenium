using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELNUnitExamples
{
    [TestFixture]//this acts as an indepentent test group it can contain more than one test inside 
    internal class GHPTests : CoreCodes
    {
        [Ignore("other")]
        [Test]
        [Order(10)]
        public void TitleTest()
        {

            // Console.WriteLine(driver.Title.Length);
            Console.WriteLine(driver.Title.Length);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Test Pass");
        }
        [Ignore("other")]

        [Test]
        [Order(20)]
        public void GoogleSearchTest()
        {
            IWebElement SearchInputBox = driver.FindElement(By.Id("APjFqb"));

            SearchInputBox.SendKeys("hp laptop");
            Thread.Sleep(5000);
            IWebElement SubmitButton = driver.FindElement(By.ClassName("gNO89b"));//Name("btnK"));
            SubmitButton.Click();
            Assert.AreEqual("hp laptop - Google Search", driver.Title);

            Console.WriteLine("Google Search - Pass");
            // Thread.Sleep(3000);

        }
        [Ignore("other")]

        [Test]
        public void CheckAllLinksStatus()
        {
            List<IWebElement> allLinks=driver.FindElements(By.TagName("a")).ToList();
           foreach (var link in allLinks) 
            {
                string url=link.GetAttribute("href");
                if (url == null)
                {
                    Console.WriteLine("URL is null");
                    continue;
                }
                else
                {
                    bool isworking = CheckLinkStatus(url);
                    if (isworking)
                    {
                        Console.WriteLine(url + "is Working");
                    }
                    else
                    {
                        Console.WriteLine(url +"is not working");
                    }
                    


                }

            }
        }
    }
}
