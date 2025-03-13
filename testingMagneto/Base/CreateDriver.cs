using OpenQA.Selenium.Chrome;

namespace testingMagneto.Base;

public class CreateDriver
{
    private static ChromeDriver driver;
    private CreateDriver(){}

    public static ChromeDriver GetDriver()
    {
        if (driver == null)
        {
            driver = new ChromeDriver();
        }
        return driver;
    }
}