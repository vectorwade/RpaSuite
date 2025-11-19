using RpaSuite.Common.Automations;
using Project.Infrastructure.Automation;
using RpaSuite.Infrastructure.Automation.Selenium;

namespace Project.Infrastructure.Automation.Implementations;

public class SeleniumAutomation : IAutomation
{
    private readonly ISeleniumRunner _selenium;

    public SeleniumAutomation(ISeleniumRunner selenium) => _selenium = selenium;

    public string Name => "Selenium.Sample";

    public async Task ExecuteAsync(CancellationToken ct = default)
    {
        // Example: navigate to a page and execute a small script
        _selenium.Navigate("https://example.com");
        // Inject a console log (non-blocking). In real automations, perform DOM interactions.
        _selenium.InjectJs("console.log('Automation executed: Selenium.Sample');");
        await Task.Delay(200, ct);
    }
}
