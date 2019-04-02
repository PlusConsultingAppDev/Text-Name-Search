using Krummert.BLL.Bases;
using Krummert.BLL.Models;
using Krummert.DLL.DB;

namespace Krummert.BLL.Services
{
    public class NameService : _BaseCrud<Name, NameRepository, DLL.Models.Name> { }
}
