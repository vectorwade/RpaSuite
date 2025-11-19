using RpaSuite.Common.Automations;

namespace Project.Infrastructure.Automation;

public class AutomationOrchestrator : IAutomationOrchestrator
{
    private readonly IEnumerable<IAutomation> _automations;

    public AutomationOrchestrator(IEnumerable<IAutomation> automations) => _automations = automations;

    public async Task RunAllAsync(CancellationToken ct = default)
    {
        foreach (var a in _automations)
        {
            try
            {
                Console.WriteLine($"[Orchestrator] Executing {a.Name}");
                await a.ExecuteAsync(ct);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Orchestrator] Automation {a.Name} failed: {ex.Message}");
            }
        }
    }
}
