using OpenQA.Selenium;
using testingMagneto.Base;

namespace testingMagneto.Pages.RegistrationPages;

public class RegistrationPage : BasePage
{
    public By FirstNameField { get; } = By.Id("firstname");
    public By LastNameField { get; } = By.Id("lastname");
    public By EmailField { get; } = By.Id("email_address");
    public By PasswordField { get; } = By.Id("password");
    public By ConfirmPasswordField { get; } = By.Id("password-confirmation");
    public By FirstNameError { get; } = By.Id("firstname-error");
    public By LastNameError { get; } = By.Id("lastname-error");
    public By EmailError { get; } = By.Id("email_address-error");
    public By PasswordError { get; } = By.Id("password-error");
    public By ConfirmPasswordError { get; } = By.Id("password-confirmation-error");
    public By CreateAccountButton { get; } = By.XPath("//span[text()='Create an Account']");
    public By PasswordStrength { get; } = By.Id("password-strength-meter-label");
    public By PageErrorMessage { get; } = By.XPath("//div[@class='page messages']");
    
    public RegistrationPage(IWebDriver driver) : base(driver) { }
    
    public HomePage CreateAccount(string firstName, string lastName, string email, string password, string confirmPassword)
    {
        Set(driver.FindElement(FirstNameField), firstName);
        Set(driver.FindElement(LastNameField), lastName);
        Set(driver.FindElement(EmailField), email);
        Set(driver.FindElement(PasswordField), password);
        Set(driver.FindElement(ConfirmPasswordField), confirmPassword);
        Click(driver.FindElement(CreateAccountButton));
        return new HomePage(driver);
    }
}