using OpenQA.Selenium;
using testingMagneto.Pages.AuthenticationPages;

namespace testingMagneto.Pages.AuthenticationPages;

public class ForgotPasswordPage : AuthenticationPage
{
    public By ForgotPasswordPageHeader { get; } = By.XPath("//h1/span[text()='Forgot Your Password?']");
    
    public ForgotPasswordPage(IWebDriver driver) : base(driver) {}
    
    public bool IsAccountPageDisplayed()
    {
        return driver.FindElement(ForgotPasswordPageHeader).Displayed;
    }
}