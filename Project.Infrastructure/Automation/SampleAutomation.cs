using RpaSuite.Common.Automations;

namespace Project.Infrastructure.Automation.Implementations;

public class SampleAutomation : IAutomation
{
    public string Name => "SampleAutomation";

    public async Task ExecuteAsync(CancellationToken ct = default)
    {
        // exemplo simples: apenas aguarda e registra (substitua pela automação real)
        await Task.Delay(500, ct);
        Console.WriteLine($"[Automation] {Name} executed at {DateTime.UtcNow}");
    }
}
