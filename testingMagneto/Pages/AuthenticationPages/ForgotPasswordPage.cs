using OpenQA.Selenium;
using testingMagneto.Pages.AuthenticationPages;

namespace testingMagneto.Pages.AuthenticationPages;

public class ForgotPasswordPage : AuthenticationPage
{
    private By forgotPasswordPageHeader = By.XPath("//h1/span[text()='Forgot Your Password?']");

    public bool IsAccountPageDisplayed()
    {
        return Find(forgotPasswordPageHeader).Displayed;
    }
}