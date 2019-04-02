using Krummert.DLL.Bases;

namespace Krummert.DLL.Models
{
    public class Name : _BaseModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}