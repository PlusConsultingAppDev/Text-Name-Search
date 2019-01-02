using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Entities.Search;

namespace App.Contracts
{
    public interface ISourceTypeManager
    {
        Task<IEnumerable<SourceType>> GetAll();
    }
}
