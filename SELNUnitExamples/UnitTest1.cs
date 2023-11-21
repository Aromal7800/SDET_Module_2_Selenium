using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace SELNUnitExamples
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();//it will open the browser
            driver.Url = "https://www.google.com";
        }
        [Ignore("other")]

        [Test]
        public void CheckForTitle()
        {
          
            Thread.Sleep(2000);
            string title=driver.Title;
            Assert.AreEqual("Google",title);
            
        }
        [TearDown] 
        public void TearDown()
        {
            driver.Close();
        }
    }
}