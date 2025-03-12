using OpenQA.Selenium;

namespace testingMagneto.Base;

public class BasePage
{
    protected IWebDriver driver;

    public BasePage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void Click(IWebElement webElement)
    {
        webElement.Click();
    }

    public void Set(IWebElement webElement, string value)
    {
        webElement.SendKeys(value);
    }

    public string GetText(IWebElement webElement)
    {
        return webElement.Text;
    }
}