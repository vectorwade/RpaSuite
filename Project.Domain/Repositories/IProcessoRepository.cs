public interface IProcessoRepository
{
    Task<Processo?> ObterAsync(int id, CancellationToken ct = default);
    Task<List<Processo>> ListarAsync(CancellationToken ct = default);
    Task AdicionarAsync(Processo entity, CancellationToken ct = default);
    Task AtualizarAsync(Processo entity, CancellationToken ct = default);
    Task RemoverAsync(int id, CancellationToken ct = default);
}
