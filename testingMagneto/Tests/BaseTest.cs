using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using testingMagneto.Base;
using testingMagneto.Pages;

namespace testingMagneto.Tests;

public class BaseTest
{
    private IWebDriver driver;
    private BasePage basePage;
    private string url =
        "https://magento.softwaretestingboard.com/customer/account/login/referer/aHR0cHM6Ly9tYWdlbnRvLnNvZnR3YXJldGVzdGluZ2JvYXJkLmNvbS9jdXN0b21lci9hY2NvdW50L2NyZWF0ZS8%2C/";
    protected AuthenticationPage authPage;
    
    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl(url);
        basePage = new BasePage();
        basePage.SetDriver(driver);
        authPage = new AuthenticationPage();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}