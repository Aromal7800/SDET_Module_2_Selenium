// See https://aka.ms/new-console-template for more information
using Assignment_1_nov_14;
using NUnit.Framework;

Amazone amazone = new Amazone();
amazone.initialize();
try
{
    amazone.TitleCheck();
    amazone.UrlCheck();
}
catch (AssertionException)
{
    Console.WriteLine("Fail");
}
amazone.Destruct();