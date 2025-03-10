using System.Diagnostics;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using testingMagneto.Base;
using testingMagneto.Pages;
using testingMagneto.Pages.AuthenticationPages;

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

    [Test]
    public void PasswordStrength()
    {
        string password = "test1234@";
        regPage.SetPassword(password);
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
        regPage.ClickCreateAccountButton();
        Assert.That(regPage.GetConfirmPasswordErrorMessage(), Is.EqualTo("Please enter the same value again."));
    }

    [Test]
    public void InvalidPassword()
    {
        string password = "test1234";
        regPage.SetPassword(password);
        regPage.ClickCreateAccountButton();
        Assert.That(regPage.GetPasswordErrorMessage(), Does.Contain("Minimum of different classes of characters in password is 3."));
    }

    [Test]
    public void MinimumPasswordLength()
    {
        string password = "test";
        regPage.SetPassword(password);
        regPage.ClickCreateAccountButton();
        Assert.That(regPage.GetPasswordErrorMessage(), Does.Contain("Minimum length of this field must be equal or greater than 8 symbols."));
    }

    [Test]
    public void PasswordIsHidden()
    {
        string password = "test@1234";
        regPage.SetPassword(password);
        var passwordField = regPage.GetPasswordField();
        string passwordFieldType = passwordField.GetAttribute("type");
        Assert.That(passwordFieldType, Is.EqualTo("password"));
    }

    [Test]
    public void AlreadyRegisteredEmail()
    {
        regPage.CreateAccount(
            "test", "test", "shalvasologhashvili21@gmail.com",
            "test@1234", "test@1234");
        Assert.That(regPage.GetPageErrorMessage(), Does.Contain("There is already an account with this email address."));
    }
}