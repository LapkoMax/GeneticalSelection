using GeneticalSelection.Models;
using GeneticalSelection.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories.Impl
{
    public class KingdomRepository : RepositoryBase<Kingdom>, IKingdomRepository
    {
        public KingdomRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public IEnumerable<Kingdom> GetAllKingdoms(bool trackChanges = false) =>
            FindAll(trackChanges)
            .OrderBy(k => k.Name)
            .ToList();
        public void CreateKingdom(Kingdom kingdom) => Create(kingdom);
    }
}
