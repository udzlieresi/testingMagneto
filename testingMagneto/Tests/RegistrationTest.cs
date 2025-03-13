using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace testingMagneto.Tests;

public class RegistrationTest : BaseTest
{
    [SetUp]
    public override void SetUp()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl(RegURL);
    }
    
    [Test]
    public void MissingAllFieldsExceptOne()
    {
        string email = "test@gmail.com";
        string expectedResult = "This is a required field.";
        
        GetRegistrationPage().Set(driver.FindElement(GetRegistrationPage().EmailField), email);
        GetRegistrationPage().Click(driver.FindElement(GetRegistrationPage().CreateAccountButton));
        
        Assert.That(GetRegistrationPage().GetText(driver.FindElement(GetRegistrationPage().FirstNameError)), Is.EqualTo(expectedResult));
        Assert.That(GetRegistrationPage().GetText(driver.FindElement(GetRegistrationPage().LastNameError)), Is.EqualTo(expectedResult));
        Assert.That(GetRegistrationPage().GetText(driver.FindElement(GetRegistrationPage().PasswordError)), Is.EqualTo(expectedResult));
        Assert.That(GetRegistrationPage().GetText(driver.FindElement(GetRegistrationPage().ConfirmPasswordField)), Is.EqualTo(expectedResult));
    }

    [Test]
    public void InvalidEmail()
    {
        string email = "test";
        string expectedResult = "Please enter a valid email address";
        
        GetRegistrationPage().Set(driver.FindElement(GetRegistrationPage().EmailField), email);
        GetRegistrationPage().Click(driver.FindElement(GetRegistrationPage().CreateAccountButton));
       
        Assert.That(GetRegistrationPage().GetText(driver.FindElement(GetRegistrationPage().EmailError)), Does.Contain(expectedResult));
    }

    [Test]
    public void PasswordStrength()
    {
        string password = "test1234@";
        string expectedResult = "Strong";
        
        GetRegistrationPage().Set(driver.FindElement(GetRegistrationPage().PasswordField), password);
        GetRegistrationPage().Click(driver.FindElement(GetRegistrationPage().CreateAccountButton));
        
        Assert.That(GetRegistrationPage().GetText(driver.FindElement(GetRegistrationPage().PasswordStrength)), Does.Contain(expectedResult));
    }

    [Test]
    public void PasswordMismatch()
    {
        string password = "test1234@";
        string confirmPassword = "test1234";
        string expectedResult = "Please enter the same value again.";
        
        GetRegistrationPage().Set(driver.FindElement(GetRegistrationPage().PasswordField), password);
        GetRegistrationPage().Set(driver.FindElement(GetRegistrationPage().ConfirmPasswordField), confirmPassword);
        GetRegistrationPage().Click(driver.FindElement(GetRegistrationPage().CreateAccountButton));
        
        Assert.That(GetRegistrationPage().GetText(driver.FindElement(GetRegistrationPage().ConfirmPasswordError)), Is.EqualTo(expectedResult));
    }

    [Test]
    public void InvalidPassword()
    {
        string password = "test1234";
        string expectedResult = "Minimum of different classes of characters in password is 3.";
        
        GetRegistrationPage().Set(driver.FindElement(GetRegistrationPage().PasswordField), password);
        GetRegistrationPage().Click(driver.FindElement(GetRegistrationPage().CreateAccountButton));
        
        Assert.That(GetRegistrationPage().GetText(driver.FindElement(GetRegistrationPage().PasswordError)), Does.Contain(expectedResult));
    }

    [Test]
    public void MinimumPasswordLength()
    {
        string password = "test";
        string expectedResult = "Minimum length of this field must be equal or greater than 8 symbols.";
   
        GetRegistrationPage().Set(driver.FindElement(GetRegistrationPage().PasswordField), password);
        GetRegistrationPage().Click(driver.FindElement(GetRegistrationPage().CreateAccountButton));
        
        Assert.That(GetRegistrationPage().GetText(driver.FindElement(GetRegistrationPage().PasswordError)), Does.Contain(expectedResult));
    }

    [Test]
    public void PasswordIsHidden()
    {
        string password = "test@1234";
        string expectedResult = "password";

        GetRegistrationPage().Set(driver.FindElement(GetRegistrationPage().PasswordField), password);
        string passwordFieldType = GetRegistrationPage().GetAttribute(driver.FindElement(GetRegistrationPage().PasswordField), "type");
        
        Assert.That(passwordFieldType, Is.EqualTo(expectedResult));
    }

    [Test]
    public void AlreadyRegisteredEmail()
    {
        string firstName = "test";
        string lastName = "test";
        string email = "shalvasologhashvili21@gmail.com";
        string password = "test@1234";
        string confirmPassword = "test@1234";
        string expectedResult = "There is already an account with this email address.";
        
        GetRegistrationPage().CreateAccount(firstName, lastName, email, password, confirmPassword);
        
        Assert.That(GetRegistrationPage().GetText(driver.FindElement(GetRegistrationPage().PageErrorMessage)), Does.Contain(expectedResult));
    }
}