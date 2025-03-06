using OpenQA.Selenium;
using testingMagneto.Base;

namespace testingMagneto.Pages;

public class AuthenticationPage : BasePage
{
    private By emailField = By.Id("email");
    private By passwordField = By.Id("pass");
    private By loginButton = By.Id("send2");

    public void SetEmail(string email)
    {
        Set(emailField, email);
    }

    public void SetPassword(string password)
    {
        Set(passwordField, password);
    }

    public AccountPage ClickLoginButton()
    {
        Click(loginButton);
        return new AccountPage();
    }

    public AccountPage LoginInIntoApplication(string email, string password)
    {
        SetEmail(email);
        SetPassword(password);
        return ClickLoginButton();
    }

    public string GetErrorMessageFor()
    {
        return 
    }
}