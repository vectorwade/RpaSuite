namespace RpaSuite.Common.Automations;

public interface IAutomationOrchestrator
{
    Task RunAllAsync(CancellationToken ct = default);
}
