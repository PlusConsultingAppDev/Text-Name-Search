using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Entities.Search;

namespace App.Contracts
{
    public interface IResultManager
    {
        Task<IEnumerable<Result>> GetAll();

        Task<Guid> Add(Result result);
    }
}
