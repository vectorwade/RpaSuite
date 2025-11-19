namespace RpaSuite.Common.Results;

public class Result
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; } = "";
    public static Result Ok(string msg = "") => new() { Sucesso = true, Mensagem = msg };
    public static Result Erro(string msg) => new() { Sucesso = false, Mensagem = msg };
}
