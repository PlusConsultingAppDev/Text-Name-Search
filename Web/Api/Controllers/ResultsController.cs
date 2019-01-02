using System;
using System.Threading.Tasks;
using App.Logic.Repo;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly ResultRepo resultsRepo;

        public ResultsController(ResultRepo resultsRepo)
        {
            this.resultsRepo = resultsRepo;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var allItems = await this.resultsRepo.GetAll();
            return this.Ok(allItems);
        }
    }
}