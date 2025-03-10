using OpenQA.Selenium;
using testingMagneto.Base;
using testingMagneto.Pages.AuthenticationPages;

namespace testingMagneto.Pages.AuthenticationPages;

public class AuthenticationPage : BasePage
{
    private By emailField = By.Id("email");
    private By passwordField = By.Id("pass");
    private By loginButton = By.Id("send2");
    private By forgotPasswordButton = By.XPath("//div[@class='secondary']//span[text()='Forgot Your Password?']");
    private By emailErrorMessage = By.Id("email-error");
    private By passwordErrorMessage = By.Id("pass-error");
    private By pageErrorMessage = By.XPath("//div[@class='page messages']");
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

    public string GetEmailErrorMessage()
    {
        return GetText(emailErrorMessage);
    }

    public string GetPasswordErrorMessage()
    {
        return GetText(passwordErrorMessage);
    }

    public string GetPageErrorMessage()
    {
        return GetText(pageErrorMessage);
    }

    public ForgotPasswordPage ClickForgotPasswordButton()
    {
        Click(forgotPasswordButton);
        return new ForgotPasswordPage();
    }
}