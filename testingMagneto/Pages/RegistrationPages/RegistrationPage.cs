﻿using OpenQA.Selenium;
using testingMagneto.Base;
using testingMagneto.Pages.RegistrationPages;

namespace testingMagneto.Pages;

public class RegistrationPage : BasePage
{
    private By firstNameField = By.Id("firstName");
    private By lastNameField = By.Id("lastName");
    private By emailField = By.Id("email_address");
    private By passwordField = By.Id("password");
    private By confirmPasswordField = By.Id("password-confirmation");
    private By firstNameError = By.Id("firstname-error");
    private By lastNameError = By.Id("lastname-error");
    private By emailError = By.Id("email_address-error");
    private By passwordError = By.Id("password-error");
    private By confirmPasswordError = By.Id("password-confirmation-error");
    private By createAccountButton = By.XPath("//span[text()='Create an Account']");
    private By passwordStrength = By.Id("password-strength-meter-label");
    private By pageErrorMessage = By.Id("//div[@class='page messages']");
    public void SetFirstName(string firstName)
    {
        Set(firstNameField, firstName);
    }

    public void SetLastName(string lastName)
    {
        Set(lastNameField, lastName);
    }

    public void SetEmail(string email)
    {
        Set(emailField, email);
    }

    public void SetPassword(string password)
    {
        Set(passwordField, password);
    }

    public void SetConfirmPassword(string password)
    {
        Set(confirmPasswordField, password);
    }

    public HomePage ClickCreateAccountButton()
    {
        Click(createAccountButton);
        return new HomePage();
    }

    public HomePage CreateAccount(string firstName, string lastName, string email, string password, string confirmPassword)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
        SetEmail(email);
        SetPassword(password);
        SetConfirmPassword(password);
        return ClickCreateAccountButton();
    }

    public string GetFirstNameErrorMessage()
    {
        return GetText(firstNameError);
    }

    public string GetLastNameErrorMessage()
    {
        return GetText(lastNameError);
    }
    
    public string GetEmailErrorMessage()
    {
        return GetText(emailError);
    }

    public string GetPasswordErrorMessage()
    {
        return GetText(passwordError);
    }
    public string GetConfirmPasswordErrorMessage()
    {
        return GetText(confirmPasswordError);
    } 
    
    public string GetPasswordStrength()
    {
        return GetText(passwordStrength);
    }

    public IWebElement GetPasswordField()
    {
        return Find(passwordField);
    }

    public string GetPageErrorMessage()
    {
        return GetText(pageErrorMessage);
    }
}