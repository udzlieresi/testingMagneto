using OpenQA.Selenium;

namespace testingMagneto.Pages.AuthenticationPages;

public class AccountPage : AuthenticationPage
{
    // კონსტრუქტორი გინდა აქ რომელიც დრაივერს გადასცემს სუპერ კლასს

    // ეს უნდა იყოს რიდ ონლყ ფროფერთი 
    // public By Element
    // {
    //     get => By.XPath("//h1/span[@class='base']");
    // }
    private By accountPageHeader = By.XPath("//h1/span[@class='base']");

    // ის არასტაბილური იქნება როცა ინტერნეტი ნელია 
    // ნახე პაკეჟი Selenium.Support
    public bool IsAccountPageDisplayed()
    {
        return Find(accountPageHeader).Displayed;
    }
}