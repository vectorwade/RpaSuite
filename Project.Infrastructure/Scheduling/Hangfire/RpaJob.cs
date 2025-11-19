using RpaSuite.Application.Interfaces;

namespace RpaSuite.Infrastructure.Scheduling.Hangfire;

public class RpaJob
{
    private readonly IRpaOrquestrador _orquestrador;

    public RpaJob(IRpaOrquestrador orquestrador) => _orquestrador = orquestrador;

    public async Task ExecutarAsync()
    {
        await _orquestrador.ExecutarAsync();
    }
}
