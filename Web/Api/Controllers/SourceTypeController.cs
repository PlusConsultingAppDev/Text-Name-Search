using System;
using System.Threading.Tasks;
using App.Logic.Repo;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceTypeController : ControllerBase
    {
        private readonly SourceTypeRepo sourceTypeRepo;

        public SourceTypeController(SourceTypeRepo sourceTypeRepo)
        {
            this.sourceTypeRepo = sourceTypeRepo;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var allItems = await this.sourceTypeRepo.GetAll();
            return this.Ok(allItems);
        }
    }
}