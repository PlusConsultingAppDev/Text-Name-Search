using Krummert.Api.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Krummert.Api.Controllers
{
    public class _BaseCrudController<BllModel, BllService, DllModel, DllService> : Controller
        where DllModel : DLL.Bases._BaseModel
        where DllService : DLL.Bases._BaseRepository<DllModel>
        where BllModel : BLL.Bases._BaseModel<DllModel>
        where BllService : BLL.Bases._BaseCrud<BllModel, DllService, DllModel>
    {
        protected BllService _Service;
        protected IHttpContextAccessor _httpContextAccessor;
        protected IConfiguration _config;
    
        [HttpGet]
        public virtual ActionResult<IEnumerable<BllModel>> Get(Guid id, string key)
        {
            ResetUser.Reset(_httpContextAccessor, _config);
            return (string.IsNullOrEmpty(key)) ? _Service.Read() : _Service.Read(key, id);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public virtual ActionResult<BllModel> Get(Guid id)
        {
            ResetUser.Reset(_httpContextAccessor, _config);
            return _Service.Read(id);
        }

        // POST api/values
        [HttpPost]
        public virtual BllModel Post()
        {
            ResetUser.Reset(_httpContextAccessor, _config);
            var value = "";
            using (StreamReader reader = new StreamReader(_httpContextAccessor.HttpContext.Request.Body, Encoding.UTF8, true, 1024, true))
            {
                value = reader.ReadToEnd();
            }

            return _Service.Save(JsonConvert.DeserializeObject<BllModel>(value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public virtual void Delete(Guid id)
        {
            ResetUser.Reset(_httpContextAccessor, _config);
            _Service.Delete(id);
        }
    }
}