using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Domain.Interfaces;
using Project.Infrastructure.Context;

namespace Project.Infrastructure.Repositories;

public class ProcessoRepository : IProcessoRepository
{
    private readonly ApplicationDbContext _db;
    public ProcessoRepository(ApplicationDbContext db) => _db = db;

    public Task<Processo?> ObterAsync(int id, CancellationToken ct = default) =>
        _db.Processos.FirstOrDefaultAsync(p => p.Id == id, ct);

    public Task<List<Processo>> ListarAsync(CancellationToken ct = default) =>
        _db.Processos.ToListAsync(ct);

    public async Task AdicionarAsync(Processo entity, CancellationToken ct = default)
    {
        await _db.Processos.AddAsync(entity, ct);
        await _db.SaveChangesAsync(ct);
    }

    public async Task AtualizarAsync(Processo entity, CancellationToken ct = default)
    {
        _db.Processos.Update(entity);
        await _db.SaveChangesAsync(ct);
    }

    public async Task RemoverAsync(int id, CancellationToken ct = default)
    {
        var entity = await ObterAsync(id, ct);
        if (entity is null) return;
        _db.Processos.Remove(entity);
        await _db.SaveChangesAsync(ct);
    }
}
