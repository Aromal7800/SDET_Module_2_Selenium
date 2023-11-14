using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SelExample;

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
/*
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
*/
//gHPTests.PageSourceTest();
//gHPTests.GoogleSearchTest();
try
{
    /*
   gHPTests.TitleTest();
    gHPTests.PageURLTest();
    gHPTests.GoogleSearchTest();
    gHPTests.GmailLinkTest();
    gHPTests.ImagesLinkTest();
    gHPTests.LocalizationTest();
    */
    gHPTests.YoutubeTest();
    
}
catch (AssertionException)
{
    Console.WriteLine("Fail");
}
gHPTests.Destruct();
