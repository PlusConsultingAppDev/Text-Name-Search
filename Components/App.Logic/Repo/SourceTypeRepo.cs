using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using App.Logic.Models;
using App.Contracts;

namespace App.Logic.Repo
{
    public class SourceTypeRepo
    {
        private readonly ISourceTypeManager sourceTypeManager;

        public SourceTypeRepo(ISourceTypeManager sourceTypeManager)
        {
            this.sourceTypeManager = sourceTypeManager;
        }

        public async Task<IEnumerable<SourceTypeModel>> GetAll()
        {
            var allItems = await this.sourceTypeManager.GetAll();
            return allItems.Select(x => new Logic.Models.SourceTypeModel()
            {
                Id = x.Id,
                Name = x.Name,
                URI = x.URI,
            }).ToList();
        }
    }
}
