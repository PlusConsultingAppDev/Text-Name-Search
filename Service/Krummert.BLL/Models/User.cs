using Krummert.BLL.Bases;
using Krummert.BLL.Helpers;
using System;
using System.Text;

namespace Krummert.BLL.Models
{
    public class User : _BaseModel<DLL.Models.User>
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        
        public override _BaseModel<DLL.Models.User> Adapt(DLL.Models.User t)
        {
            var key = Encoding.UTF8.GetBytes(t.Salt);

            return new User()
            {
                Id = t.ID,
                EmailAddress = t.EmailAddress,
                Password = t.Password // this gets encrypted at another layer
            };
        }

        public override DLL.Models.User Adapt()
        {
            var salt = Guid.NewGuid().ToString().Replace("-", "");
            var key = Encoding.UTF8.GetBytes(salt);

            return new DLL.Models.User()
            {
                ID = this.Id,
                EmailAddress = this.EmailAddress, 
                Password = this.Password, // this gets encrypted at another layer
                Salt = salt
            };
        }
    }
}
