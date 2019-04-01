using Krummert.BLL.Bases;
using Krummert.BLL.Models;
using Krummert.DLL.DB;

namespace Krummert.BLL.Services
{
    public class UserService : _BaseCrud<User, UserRepository, DLL.Models.User>
    {
        public UserService() : base()
        {
            if(base.Read().Count == 0)
            {
                base.Save(new User()
                {
                    EmailAddress = "testEmail",
                    Password = "testPassword"
                });
            }
        }

        public User Read(string emailAddress, string password)
        {
            return (User)_Instance.Adapt(_Repo.Read(emailAddress, password));
        }
    }
}