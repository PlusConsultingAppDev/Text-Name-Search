using System;
using System.Threading.Tasks;
using App.Logic.Repo;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleRepo articleRepo;

        public ArticleController(ArticleRepo articleRepo)
        {
            this.articleRepo = articleRepo;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var allItems = await this.articleRepo.GetAll();
            return this.Ok(allItems);
        }
    }
}