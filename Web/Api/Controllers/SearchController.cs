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
        [Route("first/{firstName}/last/{lastName}/middle/{middleName}")]
        public async Task<IActionResult> Search([FromRoute]string firstName, [FromRoute]string lastName, [FromRoute]string middleName)
        {
            var searchIdentifier = await this.searchRepo.Search(firstName, lastName, middleName);
            return this.Ok(searchIdentifier);
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Search([FromRoute]Guid identifier)
        {
            var allItems = await this.searchRepo.Get(identifier);
            return this.Ok(allItems);
        }

        [HttpGet]
        [Route("results")]
        public async Task<IActionResult> GetAll()
        {
            var allItems = await this.searchRepo.GetAll();
            return this.Ok(allItems);
        }

        [HttpGet]
        [Route("view")]
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