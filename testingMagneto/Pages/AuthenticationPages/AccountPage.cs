using OpenQA.Selenium;

namespace testingMagneto.Pages.AuthenticationPages;

public class AccountPage : AuthenticationPage
{
    public By AccountPageHeader { get; } = By.XPath("//h1/span[@class='base']");
    
    public AccountPage(IWebDriver driver) : base(driver){}
    
    public bool IsAccountPageDisplayed()
    {
        return driver.FindElement(AccountPageHeader).Displayed;
    }
}