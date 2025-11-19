using System.Text;

namespace RpaSuite.Common.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string? texto) => string.IsNullOrEmpty(texto);
    public static string RemoverAcentos(this string texto)
    {
        var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(texto);
        return Encoding.ASCII.GetString(bytes);
    }
}
