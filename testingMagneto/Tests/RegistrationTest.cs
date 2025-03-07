using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using testingMagneto.Base;
using testingMagneto.Pages;

namespace testingMagneto.Tests;

public class RegistrationTest : BaseTest
{
    [SetUp]
    public override void SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl(urlReg);
        basePage = new BasePage();
        basePage.SetDriver(driver);
        authPage = new AuthenticationPage();
        regPage = new RegistrationPage();
    }
    [Test]
    public void MissingAllFieldsExceptOne()
    {
        string email = "test@gmail.com";
        
        regPage.SetEmail(email);
        regPage.ClickCreateAccountButton();
        Assert.That(regPage.GetFirstNameErrorMessage(), Is.EqualTo("This is a required field."));
        Assert.That(regPage.GetLastNameErrorMessage(), Is.EqualTo("This is a required field."));
        Assert.That(regPage.GetPasswordErrorMessage(), Is.EqualTo("This is a required field."));
        Assert.That(regPage.GetConfirmPasswordErrorMessage(), Is.EqualTo("This is a required field."));
    }

    [Test]
    public void InvalidEmail()
    {
        string email = "test";
        regPage.SetEmail(email);
        regPage.ClickCreateAccountButton();
        Assert.That(regPage.GetEmailErrorMessage(), Does.Contain("Please enter a valid email address"));
    }
    
    //[Test]
    //public void 
}