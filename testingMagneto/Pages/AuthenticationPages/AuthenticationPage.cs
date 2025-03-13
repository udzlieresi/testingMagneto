using OpenQA.Selenium;
using testingMagneto.Base;

namespace testingMagneto.Pages.AuthenticationPages;

public class AuthenticationPage : BasePage
{
    public By EmailField { get; } = By.Id("email");
    public By PasswordField { get; } = By.Id("pass");
    public By LoginButton { get; } = By.Id("send2");
    public By ForgotPasswordButton { get; } = By.XPath("//div[@class='secondary']//span[text()='Forgot Your Password?']");
    public By EmailErrorMessage { get; } = By.Id("email-error");
    public By PasswordErrorMessage { get; } = By.Id("pass-error");
    public By PageErrorMessage { get; } = By.XPath("//div[@class='page messages']");
    
    
    public AuthenticationPage(IWebDriver driver) : base(driver){}
    
    public AccountPage LoginInIntoApplication(string email, string password)
    {
        Set(driver.FindElement(EmailField), email);
        Set(driver.FindElement(PasswordField), password);
        Click(driver.FindElement(LoginButton));
        return new AccountPage(driver);
    }

    public ForgotPasswordPage ClickForgotPasswordButton()
    {
        Click(driver.FindElement(ForgotPasswordButton));
        return new ForgotPasswordPage(driver);
    }
}