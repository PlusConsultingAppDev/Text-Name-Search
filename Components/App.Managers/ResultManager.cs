using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Contracts;
using App.Core.Contracts;
using App.Entities.Search;
using App.Managers.Base;
using App.Store.Contracts;

namespace App.Managers
{
    public class ResultManager : Manager, IResultManager
    {
        public ResultManager(
            IDataStore store,
            IConfigurationStore config)
           : base(store)
        {
            this.Timeout = config.GetConfiguration<int>("SQLTimeout");
        }

        public async Task<IEnumerable<Result>> GetAll()
        {
            var query = await this.GetQueryAsync();
            var items = await this.Store.GetListAsync<Result>(query);
            return items;
        }

        public async Task<Guid> Add(Result result)
        {
            var query = await this.GetQueryAsync();
            return await this.Store.ExecuteScalerAsync<Guid>(query, new
            {
                result.SearchIdentifier,
                result.ArticleIdentifier,
                result.SearchText,
                result.Occurrences,
                result.CreatedBy,
            });
        }
    }
}
