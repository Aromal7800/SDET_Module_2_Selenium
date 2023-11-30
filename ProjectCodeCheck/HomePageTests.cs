using BunnyCart;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCodeCheck
{
    internal class HomePageTests :CoreCodes
    {
        [Test]
        public void HPTests()

        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Eement Not Found";

            Thread.Sleep(4000);
            IWebElement webElement = fluentWait.Until(d => d.FindElement(By.XPath("/html/body/div[2]/div/div/main/div/div/div[1]/div/div[8]/div[1]/section/div[1]/article/div/a")));//"//section[contains(@id,'content grid')]/div[1]/article/div/a/div[1]/div[1]/div[1]")));
            ScrollIntoView(driver, webElement);
            Thread.Sleep(4000);
            webElement.Click();
        
            
            /*
            IWebElement ProfileClick = driver.FindElement(By.XPath("//a[@data-test-id='header-login-nav']"));
            ProfileClick.Click();
            Thread.Sleep(4000);
            IWebElement LogInOrSignUp = driver.FindElement(By.XPath("//a[@data-test-id='header-login-link']"));
            LogInOrSignUp.Click();
            Thread.Sleep(4000);
            IWebElement EmailTextBar = driver.FindElement(By.Id("lookupEmail"));
            EmailTextBar.SendKeys("abcpoi@gmail.com");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//button[@data-test-id='submit']")).Click();
            Thread.Sleep(3000);
            IWebElement FullName = driver.FindElement(By.XPath("//input[@data-test-id='fullName']"));
            FullName.SendKeys("abcd ef");
            Thread.Sleep(3000);
            IWebElement Password = driver.FindElement(By.XPath("//input[@data-test-id='password']"));
            Password.SendKeys("Abcd@1234");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("label-checkout-newsletter-opt-in")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//button[@data-test-id='signup-submit']")).Click();
            Thread.Sleep(3000);
            /*
            IWebElement CoupleChkBox = driver.FindElement(By.XPath("//input[@id='review-filters-traveler-couple' and @type='checkbox']"));

            ScrollIntoView(driver, CoupleChkBox);
            CoupleChkBox.Click();
            IWebElement FIveStarChkBox = driver.FindElement(By.XPath("//input[@id='review-filters-rating-5' and @type='checkbox']"));

            ScrollIntoView(driver, FIveStarChkBox);
            FIveStarChkBox.Click();
            Thread.Sleep(3000);

            IWebElement ReviewsSearch = driver.FindElement(By.ClassName("c-input__field"));
            ScrollIntoView(driver, ReviewsSearch);
            ReviewsSearch.SendKeys("It wasn't exactly clear where the tour");
            ReviewsSearch.SendKeys(Keys.Enter);
            Thread.Sleep(3000);
           
            
            Thread.Sleep(5000);
          //  IWebElement SearchBa = driver.FindElement(By.XPath("//div[contains(@class,'photo-gallery__wishlist--icon')]\r\n"));
          //  SearchBa.Click();
            Thread.Sleep(5000);
             */
            //div[contains(@class,'photo-gallery__wishlist--icon')]
            //IWebElement SearchBar = driver.FindElement(By.ClassName("participants-picker__input"));//@class,'c-input__field')]"));
            //SearchBar.SendKeys("2");                                                                // SearchBar.SendKeys("Kerala");
            //SearchBar.SendKeys(Keys.Enter);
            /*
                        IWebElement SearchBa= driver.FindElement(By.XPath("//input[@value='Select date']"));
                        ScrollIntoView(driver, SearchBa);   
                        SearchBa.Click();


                        Thread.Sleep(4000);
                        //action.Invoke();
                        Thread.Sleep(4000);
                        IWebElement SearchBar = driver.FindElement(By.ClassName("flatpickr-next-month"));
                        ScrollIntoView(driver, SearchBar);
                        SearchBar.Click();
                        //  SearchBar.Click();
                        Thread.Sleep(4000);

                        IWebElement DateSelect = driver.FindElement(By.XPath("//span[@data-date-value='2023-12-31']"));
                        DateSelect.Click();
                        IWebElement CheckAvailabilityBtn = driver.FindElement(By.XPath("//button[contains(@class,'gtm-trigger__adp-check-availability-btn')]"));
                        CheckAvailabilityBtn.Click();
                        Thread.Sleep(7000);
                       // driver.FindElement(By.XPath("//button[@data-test-id='buy-now-button']")).Click();

                        //button[@data-test-id='buy-now-button'][1]

                        IWebElement AddToCart = driver.FindElement(By.XPath("//button[contains(@data-test-id,'add-to-cart-button')]"));
                        ScrollIntoView(driver, AddToCart);
                        Thread.Sleep(4000);
                        //@class,'c-input__field')]"));
                        //  SearchBar.Clear();
                        // SearchBar.SendKeys("2");

                        driver.FindElement(By.XPath("//button[contains(@data-test-id,'added-item-cart-expiration')]")).Click();

                        Thread.Sleep(3000);
                        //driver.FindElement(By.XPath("//a[contains(@class,'js-navigation-link-cart')]")).Click();
                      */
        }

    }
}
