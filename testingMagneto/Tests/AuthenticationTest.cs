using NUnit.Framework;

namespace testingMagneto.Tests;

public class AuthenticationTest : BaseTest
{
    [Test]
    public void SuccessfulLogIn()
    {
        string email = "shalvasologhashvili21@gmail.com";
        string password = "test@1234";
        
        var accountPage = GetAuthenticationPage().LoginInIntoApplication(email, password);
        
        Assert.That(accountPage.IsAccountPageDisplayed(), Is.True);
    }

    [Test]
    public void MissingFields()
    {
        string expectedResult = "This is a required field.";
        
        GetAuthenticationPage().Click(driver.FindElement(GetAuthenticationPage().LoginButton));
        
        string emailErrorMessage = GetAuthenticationPage().GetText(driver.FindElement(GetAuthenticationPage().EmailErrorMessage));
        string passwordErrorMessage = GetAuthenticationPage().GetText(driver.FindElement(GetAuthenticationPage().PasswordErrorMessage));
        
        Assert.That(emailErrorMessage, Is.EqualTo(expectedResult));
        Assert.That(passwordErrorMessage, Is.EqualTo(expectedResult));
    }

    [Test]
    public void InvalidEmail()
    {
        string email = "test";
        string password = "test1234@";
        string expectedResult = "Please enter a valid email address (Ex: johndoe@domain.com).";
        
        GetAuthenticationPage().LoginInIntoApplication(email, password);
        string emailErrorMessage = GetAuthenticationPage().GetText(driver.FindElement(GetAuthenticationPage().EmailErrorMessage));
        
        Assert.That(emailErrorMessage, Is.EqualTo(expectedResult));
    }

    [Test]
    public void IncorrectPassword()
    {
        string email = "shalvasologhashvili21@gmail.com";
        string password = "testtt@1234";
        string expectedResult = "The account sign-in was incorrect";

        GetAuthenticationPage().LoginInIntoApplication(email, password);
        string passwordErrorMessage = GetAuthenticationPage().GetText(driver.FindElement(GetAuthenticationPage().PasswordErrorMessage));
        
        Assert.That(passwordErrorMessage, Does.Contain(expectedResult));
    }

    [Test]
    public void ForgotPassword()
    {
        var forgotPasswordPage = GetAuthenticationPage().ClickForgotPasswordButton();
        forgotPasswordPage.IsAccountPageDisplayed();
        Assert.That(forgotPasswordPage.IsAccountPageDisplayed(), Is.True);
    }
}