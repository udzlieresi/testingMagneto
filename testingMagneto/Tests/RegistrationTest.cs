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
        Thread.Sleep(2000);
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

    [Test]
    public void PasswordStrength()
    {
        string password = "test1234@";
        regPage.SetPassword(password);
        Thread.Sleep(2000);
        regPage.ClickCreateAccountButton();
        Assert.That(regPage.GetPasswordStrength(), Does.Contain("Strong"));
    }

    [Test]
    public void PasswordMismatch()
    {
        string password = "test1234@";
        string confirmPassword = "test1234";
        
        regPage.SetPassword(password);
        regPage.SetConfirmPassword(confirmPassword);
        Thread.Sleep(2000);
        regPage.ClickCreateAccountButton();
        Assert.That(regPage.GetConfirmPasswordErrorMessage(), Is.EqualTo("Please enter the same value again."));
    }

    [Test]
    public void InvalidPassword()
    {
        string password = "test1234";
        regPage.SetPassword(password);
        Thread.Sleep(2000);
        regPage.ClickCreateAccountButton();
        Assert.That(regPage.GetPasswordErrorMessage(), Does.Contain("Minimum length of this field must be equal or greater than 8 symbols."));
    }
}