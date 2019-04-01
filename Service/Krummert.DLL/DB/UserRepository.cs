using Krummert.DLL.Bases;
using Krummert.DLL.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Krummert.DLL.DB
{
    public class UserRepository : _BaseRepository<User>
    {
        public override User Save(User t)
        {
            t.Password = Encrypt(t.Password, t.Salt);

            return base.Save(t);
        }
        public User Read(string emailAddress, string password)
        {
            foreach (var user in base.Read().Where(m => m.EmailAddress.ToLower() == emailAddress.ToLower()))
            {
                if(user.Password == Encrypt(password, user.Salt))
                {
                    return user;
                }
            }

            return null;
        }

        private string Encrypt(string decryptedPassword, string token)
        {
            using (var algorithm = SHA256.Create())
            {
                return Encoding.ASCII.GetString(algorithm.ComputeHash(Encoding.ASCII.GetBytes(decryptedPassword + token)));
            }
        }
    }
}
