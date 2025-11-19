namespace RpaSuite.Common.Automations;

public interface IAutomation
{
    string Name { get; }
    Task ExecuteAsync(CancellationToken ct = default);
}
