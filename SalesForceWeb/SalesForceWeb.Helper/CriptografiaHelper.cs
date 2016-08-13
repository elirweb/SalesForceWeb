using System.Security.Cryptography;
using System.Text;

namespace SalesForceWeb.Helper
{
    public class CriptografiaHelper
    {
        public static string CriptografarSenha(string senha)
        {
            return Criptografar(senha, "suluyds-swewgjgrfhjg-wedjgfnwjvn-3542");
        }

        public static string Criptografar(string texto, string salt)
        {
            while (salt.Length < 6)
            {
                salt += salt + "Z";
            }
            using (var sha = SHA512.Create())
            {
                salt = Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes(salt.Substring(salt.Length - 4))));
                return sha.ComputeHash(Encoding.UTF8.GetBytes(texto + salt)).ToString();
            }
        }
    }
}
