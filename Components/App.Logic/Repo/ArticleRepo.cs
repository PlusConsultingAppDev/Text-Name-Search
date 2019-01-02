using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using App.Logic.Models;
using App.Contracts;

namespace App.Logic.Repo
{
    public class ArticleRepo
    {
        private readonly IArticleManager articleManager;

        public ArticleRepo(IArticleManager articleManager)
        {
            this.articleManager = articleManager;
        }

        public async Task<IEnumerable<ArticleModel>> GetAll()
        {
            var allItems = await this.articleManager.GetAll();
            return allItems.Select(x => new Logic.Models.ArticleModel()
            {
                Identifier = x.Identifier,
                Name = x.Name,
                Content = x.Content,
                SourceType = x.SourceType,
                IsDeleted = x.IsDeleted,
            }).ToList();
        }
    }
}
