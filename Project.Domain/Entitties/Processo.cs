public class Processo
{
    public int Id { get; set; }
    public string Numero { get; set; } = "";
    public string Status { get; private set; } = "Pendente";
    public DateTime CriadoEm { get; private set; } = DateTime.UtcNow;

    public void MarcarSincronizado() => Status = "Sincronizado";
    public void MarcarErro() => Status = "Erro";
}
