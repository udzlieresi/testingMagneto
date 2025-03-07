using OpenQA.Selenium;

namespace testingMagneto.Pages;

public class ForgotPasswordPage : AuthenticationPage
{
    private By forgotPasswordPageHeader = By.XPath("//h1/span[text()='Forgot Your Password?']");

    public bool IsAccountPageDisplayed()
    {
        return Find(forgotPasswordPageHeader).Displayed;
    }
}