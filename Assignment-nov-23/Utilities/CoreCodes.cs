using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_nov_23
{
    public class CoreCodes
    {
        public Dictionary<string, string>? properties;
        public IWebDriver driver;
        public ExtentReports extent;
        ExtentSparkReporter sparkReporter;
        public ExtentTest test;

        public void ReadConfigSettings()
        {
            String currDir = Directory.GetParent(@"../../../").FullName;
            properties = new Dictionary<string, string>();
            string fileName = currDir + "/configsettings/config.properties";
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }
        }
        public static void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        [OneTimeSetUp]
        public void InitializeBrowser()
        {

            String currdir = Directory.GetParent(@"../../../").FullName;
            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currdir + "/ExtentReports/extent-report"
                + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");
            extent.AttachReporter(sparkReporter);
            ReadConfigSettings();
            if (properties["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }
            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();
        }
        public bool CheckLinkStatus(string url)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)//System is the start point
                    System.Net.WebRequest.Create(url);
                request.Method = "HEAD";
                using (var response = request.GetResponse())
                {

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();
            extent.Flush();
        }

    }
}