using BunnyCart.PageObjects;
using BunnyCart.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart.TestScripts
{
    [TestFixture]
    internal class BCTests : CoreCodes
    {
        string currdir = Directory.GetParent(@"../../../").FullName;
        [Test]
        public void SignUPTest()
        {
           
            string logfilepath = currdir + "/Logs/log_" + DateTime.Now.ToString("yyyymmdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
          
            var homepage = new BunnyCartHomePage(driver);

            Log.Information("Create Account Test Started");
            homepage.ClickCreateAccount();
            Log.Information("Create Account Test Clicked");
            Thread.Sleep(1000);

          //  homepage.ClickCreateAccount();
           // Thread.Sleep(2000);
            try
            {
                Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]")).Text.Contains("Create"));
              //  LogTestResult("Create Account Link Test","Create Account Link sucess");
                Log.Information("Test passed for Create Account");

                test = extent.CreateTest("Create Account Link Test - Pass");
                test.Pass("Create Account Link success");
                Console.WriteLine("ERCP");
            }
            catch(AssertionException ex)
            {
               Log.Error($"Test failed for Create Account. \n Exception : {ex.Message}");

             //   LogTestResult("Create Account Link Test","Create Account Link failed");


                test = extent.CreateTest("Create Account Link Test - Fail");
                test.Fail("Create Account Link failed");
                Console.WriteLine("ERCF");
            }



            
            string? excelFilePath = currdir + "/TestData/InputData.xlsx";
            string? sheetName = "CreateAccount";

            List<SignUp> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {

                string? firstName = excelData?.FirstName;
                string? lastName = excelData?.LastName;
                string? email = excelData?.Email;
                string? pwd = excelData?.Password;
                string? conpwd = excelData?.ConfirmPassword;
                string? mbno = excelData?.MobileNumber;

                Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");

              //  homepage.SignUp(firstName, lastName, email, pwd, conpwd, mbno);

                // Assert.That(""."")
                try
                {
                    Assert.That(driver.FindElement(By.XPath("//div[@class='modal-inner-wrap']//following::h1[2]")).Text, Is.EqualTo("Create an Account"));
                   // homepage.SignUp("AA", "BB", "CC", "DD", "EE", "FF");
                    homepage.SignUp(firstName, lastName, email, pwd, conpwd, mbno);

                }
                catch (AssertionException ex)
                {
                    Console.WriteLine("Create Account Modal Not Present");
                }
                Log.CloseAndFlush();

            }
        }
    }
}
