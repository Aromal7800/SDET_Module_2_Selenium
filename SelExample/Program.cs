using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

IWebDriver driver = new ChromeDriver();//it will open the browser
driver.Url = "https://www.google.com";
Thread.Sleep(1000);
string title = driver.Title;
try
{
    Assert.AreEqual("Google", title);
    Console.WriteLine("Test Pass");
}
catch (AssertionException)
{
    Console.WriteLine("Fail");
}

driver.Close(); 