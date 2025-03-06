using OpenQA.Selenium;
using testingMagneto.Base;

namespace testingMagneto.Pages;

public class RegistrationPage : BasePage
{
    private By FirstNameField = By.Id("firstName");
    private By LastNameField = By.Id("lastName");
    private By EmailField = By.Id("email_address");
    private By PasswordField = By.Id("password");
    private By ConfirmPasswordField = By.Id("password-confirmation");

    public void SetFirstName(string firstName)
    {
        Set(FirstNameField, firstName);
    }

    public void SetLastName(string lastName)
    {
        Set(LastNameField, lastName);
    }

    public void SetEmail(string email)
    {
        Set(EmailField, email);
    }

    public void SetPassword(string password)
    {
        Set(PasswordField, password);
    }

    public void SetConfirmPassword(string password)
    {
        Set(ConfirmPasswordField, password);
    }
}