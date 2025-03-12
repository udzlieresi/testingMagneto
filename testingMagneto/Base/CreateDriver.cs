using OpenQA.Selenium.Chrome;

namespace testingMagneto.Base;

public class CreateDriver
{
    private static ChromeDriver createDriver;
    private CreateDriver(){}

    public static ChromeDriver GetDriver()
    {
        if (createDriver == null)
        {
            createDriver = new ChromeDriver();
        }
        return createDriver;
    }
}