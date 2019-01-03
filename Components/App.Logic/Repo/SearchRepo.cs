using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using App.Logic.Models;
using App.Contracts;

namespace App.Logic.Repo
{
    public class SearchRepo
    {
        private readonly IResultManager resultsManager;
        private readonly IArticleManager articleManager;
        private readonly ISourceTypeManager sourceTypeManager;
        private readonly ISearchManager searchManager;

        public SearchRepo(
            IResultManager resultsManager,
            IArticleManager articleManager,
            ISourceTypeManager sourceTypeManager,
            ISearchManager searchManager)
        {
            this.resultsManager = resultsManager;
            this.articleManager = articleManager;
            this.sourceTypeManager = sourceTypeManager;
            this.searchManager = searchManager;
        }

        public async Task<IEnumerable<SearchModel>> GetAll()
        {
            var searchItems = await this.searchManager.GetAll();
            return searchItems.Select(x => new SearchModel()
            {
                Identifier = x.Identifier,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
            });
        }

        public async Task<IEnumerable<SearchResultView>> GetView()
        {
            var searchItems = await this.searchManager.GetView();
            return searchItems.Select(x => new SearchResultView()
            {
                ArticleIdentifier = x.ArticleIdentifier,
                ArticleName = x.ArticleName,
                Occurrences = x.Occurrences,
                ResultIdentifier = x.ResultIdentifier,
                SearchDate = x.SearchDate,
                SearchIdentifier = x.SearchIdentifier,
                SearchText = x.SearchText,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
            });
        }

        public async Task<IEnumerable<SearchAggregationModel>> GetAggregatedResults()
        {
            var viewData = await this.searchManager.GetView();
            var articles = await this.articleManager.GetAll();
            var searchData = await this.searchManager.GetAll();

            return searchData.Select(x => new SearchAggregationModel()
            {
                SearchDate = x.Created,
                SearchIdentifier = x.Identifier,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
                TotalOccurrences = viewData.Where(i => i.SearchIdentifier == x.Identifier).Sum(i => i.Occurrences),
                Results = articles
                .Select(i => new SearchResultsModel()
                {
                    ArticleIdentifier = i.Identifier,
                    ArticleName = i.Name,
                    Data = viewData
                    .Where(s =>
                        s.FirstName.ToLower() == x.FirstName.ToLower() &&
                        s.LastName.ToLower() == x.LastName.ToLower() &&
                        s.MiddleName.ToLower() == x.MiddleName.ToLower())
                    .Select(s => new SearchDataModel()
                    {
                        Occurrences = s.Occurrences,
                        SearchText = s.SearchText,
                    }),
                }),
            });
        }

        public async Task<SearchModel> Get(Guid identifier)
        {
            var searchItem = await this.searchManager.Get(identifier);
            return new SearchModel()
            {
                Identifier = searchItem.Identifier,
                FirstName = searchItem.FirstName,
                LastName = searchItem.LastName,
                MiddleName = searchItem.MiddleName,
            };
        }

        public async Task<SearchModel> Search(string firstName, string lastName, string middleName)
        {
            List<string> searchVariations = new List<string>();
            var searchModel = new SearchModel();

            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(firstName))
            {
                searchVariations.Add($"{firstName.ToLower()} {lastName.ToLower()}");
                if (!string.IsNullOrWhiteSpace(middleName))
                {
                    searchVariations.Add($"{firstName.ToLower()} {middleName.Substring(0, 1).ToLower()} {lastName.ToLower()}");
                    searchVariations.Add($"{firstName.ToLower()} {middleName.Substring(0, 1).ToLower()}. {lastName.ToLower()}");
                    searchVariations.Add($"{firstName.ToLower()} {middleName.ToLower()} {lastName.ToLower()}");
                }

                var articles = await this.articleManager.GetAll();
                List<Entities.Search.Result> results = new List<Entities.Search.Result>();
                var searchIdentifier = await this.searchManager.Add(new Entities.Search.Search()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    CreatedBy = 1,
                });

                foreach (var article in articles)
                {
                    var searchedItems = await this.searchManager.Search(searchVariations, articles.Select(x => x.Content.ToLower()).ToArray());
                    results.AddRange(searchedItems.Select(x => new Entities.Search.Result()
                    {
                        SearchIdentifier = searchIdentifier,
                        ArticleIdentifier = article.Identifier,
                        SearchText = x.SearchText,
                        Occurrences = x.Occurrences,
                        Created = x.Created,
                        CreatedBy = x.CreatedBy,
                    }));
                }

                var returnedItems = new List<Logic.Models.ResultModel>();
                foreach (var item in results)
                {
                    returnedItems.Add(new Logic.Models.ResultModel()
                    {
                        SearchIdentifier = item.SearchIdentifier,
                        ArticleIdentifier = item.ArticleIdentifier,
                        Occurrences = item.Occurrences,
                        SearchText = item.SearchText,
                    });
                }

                searchModel.Identifier = searchIdentifier;
                searchModel.FirstName = firstName;
                searchModel.LastName = lastName;
                searchModel.MiddleName = middleName;
                searchModel.Results = returnedItems;
            }

            return searchModel;
        }
    }
}
