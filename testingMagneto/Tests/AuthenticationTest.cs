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
    public void MissedFields()
    {
        authPage.LoginInIntoApplication("", "");
        
    }
}