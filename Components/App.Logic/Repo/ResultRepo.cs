using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using App.Logic.Models;
using App.Contracts;

namespace App.Logic.Repo
{
    public class ResultRepo
    {
        private readonly IResultManager resultsManager;

        public ResultRepo(IResultManager resultsManager)
        {
            this.resultsManager = resultsManager;
        }

        public async Task<IEnumerable<ResultModel>> GetAll()
        {
            var allItems = await this.resultsManager.GetAll();
            return allItems.Select(x => new Logic.Models.ResultModel()
            {
                Identifier = x.Identifier,
                ArticleIdentifier = x.ArticleIdentifier,
                Occurrences = x.Occurrences,
                SearchText = x.SearchText,
            }).ToList();
        }

        public async Task<Guid> Add(ResultModel result)
        {
            return await this.resultsManager.Add(new Entities.Search.Result()
            {
                SearchIdentifier = result.SearchIdentifier,
                ArticleIdentifier = result.ArticleIdentifier,
                Identifier = result.Identifier,
                Occurrences = result.Occurrences,
                SearchText = result.SearchText,
            });
        }
    }
}
