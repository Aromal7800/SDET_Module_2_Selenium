using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELNUnitExamples
{
    internal class Elements : CoreCodes
    {/*
        [Test]
        public void TestCheckBox()
        {
          //  IWebElement elements = driver.FindElement(By.XPath("//h5[text()='Elements'"));
            //elements.Click();
            Thread.Sleep(3000);
            IWebElement cbmenu = driver.FindElement(By.XPath("//*[@id=\"item-1\"]"));
            cbmenu.Click();
            Thread.Sleep(3000);
            List<IWebElement> expandcollapse = driver.FindElements(By.ClassName("rct-icon rct-icon-expand-open")).ToList();//
            foreach(var item in expandcollapse)
            {
                item.Click();
            }
            IWebElement commandscheckbox = driver.FindElement(By.XPath("//span[text()='commands')]"));
            commandscheckbox.Click();
            Assert.True(driver.FindElement(By.XPath("//input[@id,'commands']")).Selected);
        }
        */
        [Test]
        public void TestFormElement()
        {
            IWebElement fristNameFeild = driver.FindElement(By.Id("firstName"));
            fristNameFeild.SendKeys("Aromal");
            Thread.Sleep(3000);
            IWebElement lastNameFeid = driver.FindElement(By.Id("lastName"));
            lastNameFeid.SendKeys("Shaji");
            Thread.Sleep(3000);
            IWebElement email = driver.FindElement(By.Id("userEmail"));
            email.SendKeys("Aromal7800");
            Thread.Sleep(3000);
            IWebElement gender = driver.FindElement(By.XPath("//input[@id='gender-radio-3']//following::label"));
            gender.Click();
            Thread.Sleep(3000);
            IWebElement dobFeild = driver.FindElement(By.Id("dateOfBirthInput"));
            dobFeild.Click();
            Thread.Sleep(2000);
            IWebElement dobMonth = driver.FindElement(By.ClassName("react-datepicker__month-select"));//XPath("//select[@class='react-datepicker__month-select'}"));
            SelectElement selectMonth = new SelectElement(dobMonth);
            selectMonth.SelectByIndex(5);
            Thread.Sleep(5000);
            IWebElement dobYear = driver.FindElement(By.ClassName("react-datepicker__year-select"));
            SelectElement selectYear = new SelectElement(dobYear);
            selectYear.SelectByText("1990");
            Thread.Sleep(5000);
            IWebElement dobDate = driver.FindElement(By.XPath("//*[@id='dateOfBirth']/div[2]/div[2]/div/div/div[2]/div[2]/div[3]/div[6]"));
            dobDate.Click();
            Thread.Sleep(3000);
            IWebElement checkbox = driver.FindElement(By.ClassName("custom-control-label"));
            checkbox.Click();
            Thread.Sleep(3000);
            
            IWebElement subject = driver.FindElement(By.XPath("//*[@id=\"subjectsContainer\"]/div/div[1]//following::label"));
            subject.SendKeys("English");
            subject.SendKeys(Keys.Enter);
            subject.SendKeys("Maths");
            subject.SendKeys(Keys.Enter);
           
        }
        //   [Test]
        public void TestWindow()
        {
            driver.Url = "https://demoqa.com/browser-windows";
            String parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("parent window's handle -> " + parentWindowHandle);
            IWebElement clickElement = driver.FindElement(By.Id("tabButton"));
            for (var i = 0; i < 3; i++)
            {
                clickElement.Click();
                Thread.Sleep(3000);
            }
            List<string> lstWindow = driver.WindowHandles.ToList();
            String lastWindowHandle = "";
            foreach (var handle in lstWindow)
            {
                Console.WriteLine("Switching to window -> " + handle);
                driver.SwitchTo().Window(handle);
                Thread.Sleep(3000);
                Console.WriteLine("Navigating to google.com");
                driver.Navigate().GoToUrl("https://www.google.com/");
                Thread.Sleep(3000);

            }
            driver.SwitchTo().Window(parentWindowHandle);
            driver.Quit();

        }
        //[Test]
        public void TestAlert()
        {
            driver.Url = "https://demoqa.com/alerts";
            Thread.Sleep(3000);

            IWebElement element =driver.FindElement(By.Id("alertButton"));
            Thread.Sleep(3000);
            ((IJavaScriptExecutor)driver).ExecuteScript("argument[0].click()",element);
            IAlert simpleAlert = driver.SwitchTo().Alert();
            string alertText =simpleAlert.Text;
            Console.WriteLine("Alert Text is " + simpleAlert.Text);
            simpleAlert.Accept();
            Thread.Sleep(5000);
            element = driver.FindElement(By.Id("confirmButton"));
            Thread.Sleep(3000);
            element.Click();
            IAlert alert = driver.SwitchTo().Alert();   
            alertText = alert.Text;
            Console.WriteLine("Alert text is "+ alertText);
            alert.Dismiss();
            element = driver.FindElement(By.Id("promtButton"));
            element.Click();
            Thread.Sleep(5000);
            IAlert promtAlert=driver.SwitchTo().Alert();    
            alertText=promtAlert.Text;
            Console.WriteLine("Alert text is "+alertText);
            promtAlert.SendKeys("Accepting the alert");
            Thread.Sleep(5000);
            promtAlert.Accept();

        }


    }
}
