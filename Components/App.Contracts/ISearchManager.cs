using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Entities.Search;

namespace App.Contracts
{
    public interface ISearchManager
    {
        Task<IEnumerable<Result>> Search(List<string> nameSequenceArray, string[] contentArray);

        Task<IEnumerable<Search>> GetAll();

        Task<Search> Get(Guid identifier);

        Task<IEnumerable<SearchResultsView>> GetView();

        Task<Guid> Add(Search search);
    }
}
