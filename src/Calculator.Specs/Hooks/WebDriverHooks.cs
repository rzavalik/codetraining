using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace Calculator.Specs.Hooks;

[Binding]
public class WebDriverHooks
{
    public static IWebDriver? Driver { get; private set; }

    [BeforeScenario]
    public void BeforeScenario()
    {
        var options = new ChromeOptions();
        Driver = new ChromeDriver(options);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        Driver?.Quit();
        Driver?.Dispose();
    }
}