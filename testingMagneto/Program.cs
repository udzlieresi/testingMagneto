using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

IWebDriver driver = new ChromeDriver();

driver.Navigate().GoToUrl("https://www.google.com");
Console.WriteLine("Title: " + driver.Title);

driver.Quit();