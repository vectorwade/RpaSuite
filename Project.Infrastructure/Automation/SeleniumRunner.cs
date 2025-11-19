using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RpaSuite.Infrastructure.Automation.Selenium;

public class SeleniumRunner : ISeleniumRunner
{
    private ChromeOptions CreateOptions()
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless=new");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        return options;
    }

    public void Navigate(string url)
    {
        using var driver = new ChromeDriver(CreateOptions());
        driver.Navigate().GoToUrl(url);
    }

    public object InjectJs(string script, params object[] args)
    {
        using var driver = new ChromeDriver(CreateOptions());
        if (driver is IJavaScriptExecutor js)
        {
            return js.ExecuteScript(script, args);
        }
        return null!;
    }
}

