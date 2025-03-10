﻿using OpenQA.Selenium;

namespace testingMagneto.Base;

public class BasePage
{
    public static IWebDriver driver;

    public void SetDriver(IWebDriver driver)
    {
        BasePage.driver = driver;
    }

    protected IWebElement Find(By locator)
    {
        return driver.FindElement(locator);
    }

    public void Click(By locator)
    {
        Find(locator).Click();
    }

    public void Set(By locator, string value)
    {
        Find(locator).SendKeys(value);
    }

    public string GetText(By locator)
    {
        return Find(locator).Text;
    }
}