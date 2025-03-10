using OpenQA.Selenium;

namespace testingMagneto.Pages.AuthenticationPages;

public class AccountPage : AuthenticationPage
{
    private By accountPageHeader = By.XPath("//h1/span[@class='base']");

    public bool IsAccountPageDisplayed()
    {
        return Find(accountPageHeader).Displayed;
    }
}