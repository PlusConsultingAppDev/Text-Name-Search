using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Nest;
using SearchAPI.Models;

namespace SearchAPI
{
    public class ElasticSearchServiceImpl : ISearchService
    {
        private readonly string _elasticSearchServiceUrl;


        public ElasticSearchServiceImpl(IConfiguration config)
        {
            _elasticSearchServiceUrl = config["ElasticSearchServiceUrl"];
        }

        public List<string> AutoComplete(string searchQuery)
        {
            // TODO: Needs to be implemented
            return null;
        }

        public async Task<DocumentSearchResult> SearchAsync(SearchParam searchQuery)
        {
            // Search the elasticsearch cluster
            var local = new Uri(_elasticSearchServiceUrl);
            var settings = new ConnectionSettings(local).DefaultIndex(Resource.ElasticSearchIndexName);
            var elasticClient = new ElasticClient(settings);

            var queryValue = $"{searchQuery.FirstName} {searchQuery.LastName}";
            try
            {
                var result = await elasticClient
                    .SearchAsync<DocumentEntry>(x =>
                        x.Query(q => q.MatchPhrase(m => m.Field(f => f.Content).Query(queryValue).Slop(3))));

                var returnValue = new DocumentSearchResult {SearchQuery = searchQuery, ContentList = new List<string>()};

                foreach (var item in result.Documents)
                {
                    returnValue.ContentList.Add(item.Content);
                }

                return returnValue;
            }
            catch (Exception ex)
            {
                // TODO: Exception needs to be logged
                var ss = ex.Message;
            }
            return null;
        }
    }
}
