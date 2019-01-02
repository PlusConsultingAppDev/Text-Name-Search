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
    public class ArticleManager : Manager, IArticleManager
    {
        public ArticleManager(
            IDataStore store,
            IConfigurationStore config)
           : base(store)
        {
            this.Timeout = config.GetConfiguration<int>("SQLTimeout");
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            var query = await this.GetQueryAsync();
            var items = await this.Store.GetListAsync<Article>(query);
            return items;
        }
    }
}
