using NUnit.Framework;
using testingMagneto.Pages;

namespace testingMagneto.Tests;

public class AuthenticationTest : BaseTest
{
    [Test]
    public void SuccessfulLogIn()
    {
        string email = "shalvasologhashvili21@gmail.com";
        string password = "test@1234";
        
        var accountPage = authPage.LoginInIntoApplication(email, password);
        Assert.That(accountPage.IsAccountPageDisplayed(), Is.True);
    }

    [Test]
    public void MissingFields()
    {
        authPage.LoginInIntoApplication("", "");
        string expectedResult = "This is a required field.";
        Thread.Sleep(4000);
        string emailErrorMessage = authPage.GetEmailErrorMessage();
        string passwordErrorMessage = authPage.GetPasswordErrorMessage();
        Assert.That(expectedResult, Is.EqualTo(emailErrorMessage));
        Assert.That(expectedResult, Is.EqualTo(passwordErrorMessage));
    }

    [Test]
    public void InvalidEmail()
    {
        string email = "test";
        string password = "test1234@";
        
        authPage.LoginInIntoApplication(email, password);
        string actualResult = "Please enter a valid email address (Ex: johndoe@domain.com).";
        string emailErrorMessage = authPage.GetEmailErrorMessage();
        Assert.That(actualResult, Is.EqualTo(emailErrorMessage));
    }

    [Test]
    public void IncorrectPassword()
    {
        string email = "shalvasologhashvili21@gmail.com";
        string password = "testtt@1234";
        
        authPage.LoginInIntoApplication(email, password);
        string expectedResult = "The account sign-in was incorrect";
        string actualResult = authPage.GetPageErrorMessage();
        
        Assert.That(actualResult, Does.Contain(expectedResult));
    }
    
    [Test]
    public void forgot
}