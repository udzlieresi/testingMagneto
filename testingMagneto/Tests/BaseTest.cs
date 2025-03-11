using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using testingMagneto.Base;
using testingMagneto.Pages;
using testingMagneto.Pages.AuthenticationPages;

namespace testingMagneto.Tests;

public class BaseTest
{
    protected IWebDriver driver;
    protected BasePage basePage;

    // ესენი ორი უნდა გაიტანო კონფიგურაციის ფაილში
    private string urlAuth =
        "https://magento.softwaretestingboard.com/customer/account/login/";
    protected string urlReg =
        "https://magento.softwaretestingboard.com/customer/account/create/";

    protected AuthenticationPage authPage;
    protected RegistrationPage regPage;

    [SetUp]
    public virtual void SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl(urlAuth);
        basePage = new BasePage();
        basePage.SetDriver(driver);
        authPage = new AuthenticationPage();
        regPage = new RegistrationPage();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}

/*
    დრაივერის შექმნის და დახურვის ლოგიკები გაიტანე ცალკე კლასში;
    გამოიყენე სინგლტონი რომ ერთი ინსტენცი იყოს დრაივერის და პრევენცია მოხდეს დამატებიტი დრაივერების შექმნის;
    ასევე შეგიძლია ამავე კლასში დაამატო ქასტომ ვეითები (implicite, explicite);

    ფეიჟების ობჯექტების შექმნა აქ არ გჭრდება, შეიძება ზოგიერთ ტესტებს საერთოდ არ ჭირდებოდეს. შეგიძლია ვაფშე ფეიჯ კლასებშიც გაიტანო (მერე აგიხსნი რას ვგულისხმობ);
    გარდა მისა პროექტი კონფიგურაცია შეგიძლია გაიტანო json ფაილში და იქიდან აკონტროლო როგორ დრაივერს შექმნი.
    მოცდის დრო რა იქნება, მაქს ვინდოუზე გაუშვებ თუ არა, და ა.შ (ჩახედე Microsoft.Extensions.Configuration პაკეტს).

    რაც შეეხება ტესტ დათას, გირჩევ უთილიტი კლასი შექმნა, რომელიც ტესტ დათას დაგიგენერირებს ან გამოიყენე უკვე არსებული პაკეტები მაგ: Bogus

*/