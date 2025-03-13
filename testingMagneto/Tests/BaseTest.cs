using NUnit.Framework;
using OpenQA.Selenium;
using testingMagneto.Base;
using testingMagneto.Pages.AuthenticationPages;
using testingMagneto.Pages.RegistrationPages;

namespace testingMagneto.Tests;

public class BaseTest
{
    protected IWebDriver driver;
    
    protected string AuthURL = "https://magento.softwaretestingboard.com/customer/account/login/";
    protected string RegURL = "https://magento.softwaretestingboard.com/customer/account/create/";
    
    protected AuthenticationPage authPage;
    protected RegistrationPage regPage;
    
    [SetUp]
    public virtual void SetUp()
    {
        driver = CreateDriver.GetDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl(AuthURL);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

    public RegistrationPage GetRegistrationPage()
    {
        if (regPage == null)
        {
            regPage = new RegistrationPage(driver);
        }
        return regPage;
    }

    public AuthenticationPage GetAuthenticationPage()
    {
        if (authPage == null)
        {
            authPage = new AuthenticationPage(driver);
        }
        return authPage;
    }
}