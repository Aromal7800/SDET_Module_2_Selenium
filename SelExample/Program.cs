using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SelExample;
AmazoneTest amazoneTest = new AmazoneTest();
List<string> drivers = new List<string>();
drivers.Add("Edge");
drivers.Add("Chrome");
foreach (var driver in drivers)
{
    switch (driver)
    {

        case "Chrome":
            {
                amazoneTest.initializeChromeDriver();

                break;
            }
        case "Edge":
            {
                amazoneTest.initializeEdgeDriver();
                break;
            }
         
    }
    try
    {
        /*
        amazoneTest.TitleTest();
        amazoneTest.logoClickTest();
        amazoneTest.SearchProductTest();
        amazoneTest.ReloadHomePage();
        amazoneTest.TodaysDealsTest();
        */
        //amazoneTest.SignInAccountListTest(); 
        amazoneTest.SearchAndFilterProductByBrandTest();
    }
    catch (AssertionException)
    {
        Console.WriteLine();
    }
    catch(NoSuchElementException nse)
    {
        Console.WriteLine(nse.Message);
    }
    amazoneTest.Destruct();
}

/*
GHPTests  gHPTests = new GHPTests();
List<string> drivers = new List<string>();
drivers.Add("Edge");
drivers.Add("Chrome");
foreach(var driver in drivers)
{
    switch (driver) 
    {
        
        case "Chrome":
            {
                gHPTests.initializeChromeDriver();

                break;
            }
        case "Edge":
            {
                gHPTests.initializeEdgeDriver();
                break;
            }
    }
}

Console.WriteLine("Which driver do you want to initialize \t 1.Chrome \t 2.Edge ");
int ch=Convert.ToInt32(Console.ReadLine());
if (ch == 1)
{
    gHPTests.initializeChromeDriver();
}
else
{
    gHPTests.initializeEdgeDriver();
}

//gHPTests.PageSourceTest();
//gHPTests.GoogleSearchTest();
try
{
    
   gHPTests.TitleTest();
    gHPTests.PageURLTest();
    gHPTests.GoogleSearchTest();
    gHPTests.GmailLinkTest();
    gHPTests.ImagesLinkTest();
    gHPTests.LocalizationTest();
    
    gHPTests.YoutubeTest();
    
}
catch (AssertionException)
{
    Console.WriteLine("Fail");
}
gHPTests.Destruct();
*/