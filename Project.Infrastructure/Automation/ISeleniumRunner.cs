namespace RpaSuite.Infrastructure.Automation.Selenium;

public interface ISeleniumRunner
{
    void Navigate(string url);
    object InjectJs(string script, params object[] args);
}
