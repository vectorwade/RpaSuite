using RpaSuite.Common.Automations;

namespace RpaSuite.Infrastructure.Scheduling.Hangfire;

public class RpaJob
{
    private readonly IAutomationOrchestrator _orchestrator;

    public RpaJob(IAutomationOrchestrator orchestrator) => _orchestrator = orchestrator;

    public async Task ExecutarAsync()
    {
        await _orchestrator.RunAllAsync();
    }
}
