using System;
using System.Threading.Tasks;
using App.Logic.Repo;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SearchRepo searchRepo;

        public SearchController(SearchRepo searchRepo)
        {
            this.searchRepo = searchRepo;
        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search(string firstName, string middleName, string lastName)
        {
            var allItems = await this.searchRepo.Search(firstName, middleName, lastName);
            return this.Ok(allItems);
        }

        [HttpGet]
        [Route("search/results")]
        public async Task<IActionResult> GetAll()
        {
            var allItems = await this.searchRepo.GetAll();
            return this.Ok(allItems);
        }

        [HttpGet]
        [Route("search/view")]
        public async Task<IActionResult> GetView()
        {
            var allItems = await this.searchRepo.GetView();
            return this.Ok(allItems);
        }

        [HttpGet]
        [Route("search/aggregate")]
        public async Task<IActionResult> GetAggregatedResults()
        {
            var allItems = await this.searchRepo.GetAggregatedResults();
            return this.Ok(allItems);
        }
    }
}