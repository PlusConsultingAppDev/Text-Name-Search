using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Entities.Search;

namespace App.Contracts
{
    public interface ISearchManager
    {
        Task<IEnumerable<Result>> Search(string[] nameSequenceArray, string[] contentArray);

        Task<IEnumerable<Search>> GetAll();

        Task<IEnumerable<SearchResultsView>> GetView();

        Task<Guid> Add(Search search);
    }
}
