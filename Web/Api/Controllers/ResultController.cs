using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Logic.Models;
using App.Logic.Repo;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly ResultRepo resultRepo;

        public ResultController(ResultRepo resultsRepo)
        {
            this.resultRepo = resultsRepo;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var allItems = await this.resultRepo.GetAll();
            return this.Ok(allItems);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody]List<ResultModel> results)
        {
            await this.resultRepo.Add(results);
            return this.Ok();
        }

    }
}