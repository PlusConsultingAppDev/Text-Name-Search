using Krummert.DLL.Bases;

namespace Krummert.DLL.Models
{
    public class User : _BaseModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}