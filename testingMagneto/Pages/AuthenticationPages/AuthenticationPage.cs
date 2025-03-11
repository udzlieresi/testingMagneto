using OpenQA.Selenium;
using testingMagneto.Base;
using testingMagneto.Pages.AuthenticationPages; // ზედმეტი იმპორტი

namespace testingMagneto.Pages.AuthenticationPages;

public class AuthenticationPage : BasePage
{
    // კონსტრუქტორი გინდა აქ რომელიც დრაივერს გადასცემს სუპერ კლასს

    // ესენი უნდა იყოს რიდ ონლყ ფროფერთი
    private By emailField = By.Id("email");
    private By passwordField = By.Id("pass");
    private By loginButton = By.Id("send2");
    private By forgotPasswordButton = By.XPath("//div[@class='secondary']//span[text()='Forgot Your Password?']");
    private By emailErrorMessage = By.Id("email-error");
    private By passwordErrorMessage = By.Id("pass-error");
    private By pageErrorMessage = By.XPath("//div[@class='page messages']");

    // ასეთი პატარა მეთოდები არ გჭირდება პირდაპირ ლოინ მეთოდი გააკეთე რომელიც დაალოგინებს
    public void SetEmail(string email)
    {
        Set(emailField, email);
    }

    // ასეთი პატარა მეთოდები არ გჭირდება პირდაპირ ლოინ მეთოდი გააკეთე რომელიც დაალოგინებს
    public void SetPassword(string password)
    {
        Set(passwordField, password);
    }

    // ასეთი პატარა მეთოდები არ გჭირდება პირდაპირ ლოინ მეთოდი გააკეთე რომელიც დაალოგინებს
    public AccountPage ClickLoginButton()
    {
        Click(loginButton);
        return new AccountPage();
    }

    // დაააფდეითე ეს მეთოდი რომ შეამოწმო წარმატებით გაიარა თუ არა (ვალიდაცია ჩანს თუ არა)
    // თუ არ გაიარა ეს ობჯექტი
    // თუ გაიარა დააბრუნე AccountPage ობჯექი
    public AccountPage LoginInIntoApplication(string email, string password)
    {
        SetEmail(email);
        SetPassword(password);
        return ClickLoginButton();
    }

    // ასეთი პატარა მეთოდები არ გჭირდება პირდაპირ ლოინ მეთოდი გააკეთე რომელიც დაალოგინებს
    public string GetEmailErrorMessage()
    {
        return GetText(emailErrorMessage);
    }

    // ასეთი პატარა მეთოდები არ გჭირდება პირდაპირ ლოინ მეთოდი გააკეთე რომელიც დაალოგინებს
    public string GetPasswordErrorMessage()
    {
        return GetText(passwordErrorMessage);
    }

    // ასეთი პატარა მეთოდები არ გჭირდება პირდაპირ ლოინ მეთოდი გააკეთე რომელიც დაალოგინებს
    public string GetPageErrorMessage()
    {
        return GetText(pageErrorMessage);
    }

    // ასეთი პატარა მეთოდები არ გჭირდება პირდაპირ ლოინ მეთოდი გააკეთე რომელიც დაალოგინებს
    public ForgotPasswordPage ClickForgotPasswordButton()
    {
        Click(forgotPasswordButton);
        return new ForgotPasswordPage();
    }
}