using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using testingMagneto.Base;
using testingMagneto.Pages.AuthenticationPages;
using testingMagneto.Pages.RegistrationPages;

namespace testingMagneto.Tests;

public class BaseTest
{
    protected IWebDriver driver;
    protected BasePage basePage;
    private string urlAuth =
        "https://magento.softwaretestingboard.com/customer/account/login/";
    protected string urlReg =
        "https://magento.softwaretestingboard.com/customer/account/create/";
    protected AuthenticationPage authPage;
    protected RegistrationPage regPage;
    
    [SetUp]
    public virtual void SetUp()
    {
        driver = CreateDriver.GetDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl(urlAuth);
        basePage = new BasePage();
        authPage = new AuthenticationPage();
        regPage = new RegistrationPage(driver);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}