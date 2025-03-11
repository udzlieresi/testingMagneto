using OpenQA.Selenium;

namespace testingMagneto.Base;

public class BasePage
{
    public static IWebDriver driver; // ეს სტატიკური არ უნდა იყოს და არც პაბლიკი 
    // კონსტრუქტორი უნდა გქონდეს რომლიდანაც გადასცემ დრაივერს შვილი კლასებიდან

    public void SetDriver(IWebDriver driver)
    {
        BasePage.driver = driver;
    }

    // ამას აქ არ გირჩევდი, შეიძლება რომელირაც ელემენტს მოცდა მოუწიოს სანამ ჩაიტვირთება და ჯობს პეიჯ კლასებში გქონდეს.
    // დიდ პროექტებში შეიძლება ცალკე ცლასები გქონდეს თითოეული ელემენტის ტიპისთვის ამ ეტაპზე არაა საჭირო.
    // უბრალოდ ლოკატორის გადაცემა არ მომწინს :)
    protected IWebElement Find(By locator)
    {
        return driver.FindElement(locator);
    }

    // აქ ლოკატორის ნაცვლად IWebelement გამოიყენე
    public void Click(By locator)
    {
        Find(locator).Click();
    }
    // აქ ლოკატორის ნაცვლად IWebelement გამოიყენე
    public void Set(By locator, string value)
    {
        Find(locator).SendKeys(value);
    }
    // აქ ლოკატორის ნაცვლად IWebelement გამოიყენე
    public string GetText(By locator)
    {
        return Find(locator).Text;
    }
}