using Krummert.BLL.Bases;
using Krummert.BLL.Helpers;
using System;
using System.Text;

namespace Krummert.BLL.Models
{
    public class Name : _BaseModel<DLL.Models.Name>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public override _BaseModel<DLL.Models.Name> Adapt(DLL.Models.Name t)
        {
            var key = Encoding.UTF8.GetBytes(t.Salt);

            return new Name()
            {
                Id = t.ID,
                FirstName = Encryption.DecryptStringFromBytes(Convert.FromBase64String(t.FirstName), key),
                MiddleName = Encryption.DecryptStringFromBytes(Convert.FromBase64String(t.MiddleName), key),
                LastName = Encryption.DecryptStringFromBytes(Convert.FromBase64String(t.LastName), key)
            };
        }

        public override DLL.Models.Name Adapt()
        {
            var salt = Guid.NewGuid().ToString().Replace("-", "");
            var key = Encoding.UTF8.GetBytes(salt);

            return new DLL.Models.Name()
            {
                ID = this.Id,
                FirstName = Convert.ToBase64String(Encryption.EncryptStringToBytes(this.FirstName, key)),
                MiddleName = Convert.ToBase64String(Encryption.EncryptStringToBytes(this.MiddleName, key)),
                LastName = Convert.ToBase64String(Encryption.EncryptStringToBytes(this.LastName, key)),
                Salt = salt
            };
        }
    }
}
