using Rediff.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediff.TestScripts
{
    [TestFixture]
    internal class UserMgmtTests :CoreCodes
    {
        //Asserts
       // [Test,Order(1)]
        
      public void CreateAccountLinkTest()
        {

         var homepage=new RediffHomePage(driver);//will invoke all the properties

            driver.Navigate().GoToUrl("https://m.rediff.com/");
            homepage.CreateAccountLinkClick();
            Thread.Sleep(3000);
            Assert.True(driver.Url.Contains("register"));
           

        }
      //  [Test]
        [Order(2)]  
        public void SignInLinkTest()
        {

            driver.Navigate().GoToUrl("https://m.rediff.com/");
            var homepage = new RediffHomePage(driver);//will invoke all the properties

            homepage.SignInLinkClick(); 
            Thread.Sleep(3000);
            Assert.True(driver.Url.Contains("login"));


        }
       // [Test, Order(1)]
        public void CreateAccountTest()
        {

            var homepage = new RediffHomePage(driver);//will invoke all the properties
            if (!driver.Url.Equals(("https://m.rediff.com/"))){
                driver.Navigate().GoToUrl("https://m.rediff.com/");
            }
            
            var createaccountpage=homepage.CreateAccountClick();
            Thread.Sleep(3000);
            createaccountpage.fullNameType("xxx");
            createaccountpage.RediffmailType("xxx");
            createaccountpage.CheckAvailabilityBtn.Click();
            Thread.Sleep(3000);
            createaccountpage.CreateAccountBtnClick();


        }
        [Test, Order(2)]
        public void SignInTest()
        {

            var homepage = new RediffHomePage(driver);//will invoke all the properties
            if (!driver.Url.Equals(("https://m.rediff.com/")))
            {
                driver.Navigate().GoToUrl("https://m.rediff.com/");
            }

            var signinpage = homepage.SignInClick();
            Thread.Sleep(3000);
            signinpage.TypeUserName("AAA");
            signinpage.TypePassword("password");
            signinpage.ClickRememberMeChkBx();
            Assert.False(signinpage.RememberMeCheckBox.Selected);
            
            Thread.Sleep(3000);
            signinpage.ClickSignInBtn();
            Assert.True(true);

        }

    }

}


