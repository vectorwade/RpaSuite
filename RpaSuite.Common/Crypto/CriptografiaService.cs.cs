using System.Security.Cryptography;
using System.Text;

namespace RpaSuite.Common.Crypto;

public static class CriptografiaService
{
    public static string Sha256(string texto)
    {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(texto);
        var hash = sha.ComputeHash(bytes);
        return Convert.ToHexString(hash);
    }
}
