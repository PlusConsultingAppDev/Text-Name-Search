using Krummert.BLL.Models;
using Krummert.BLL.Services;
using Krummert.DLL.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Krummert.Api.Controllers
{
    [Route("api/Name"), Authorize(Policy = "CustomPolicy")]
    [ApiController]
    public class NameController : _BaseCrudController<Name, NameService, DLL.Models.Name, NameRepository>
    {
        public NameController(NameService nameService,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _config = config;
            _Service = nameService;
        }
    }
}
