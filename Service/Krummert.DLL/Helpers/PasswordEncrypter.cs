using System.Security.Cryptography;
using System.Text;

namespace Krummert.DLL.Helpers
{
    internal class PasswordEncrypter
    {
        public static string Encrypt(string decryptedPassword, string token)
        {
            using (var algorithm = SHA256.Create())
            {
                return Encoding.ASCII.GetString(algorithm.ComputeHash(Encoding.ASCII.GetBytes(decryptedPassword + token)));
            }
        }
    }
}
