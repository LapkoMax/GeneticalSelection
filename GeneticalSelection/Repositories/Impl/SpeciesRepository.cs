using GeneticalSelection.Models;
using GeneticalSelection.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories.Impl
{
    public class SpeciesRepository : RepositoryBase<Species>, ISpeciesRepository
    {
        public SpeciesRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public IEnumerable<Species> GetAllSpecies(bool trackChanges = false) =>
            FindAll(trackChanges)
            .OrderBy(k => k.Name)
            .ToList();
        public Species GetSpecies(long speciesId, bool trackChanges = false) =>
            FindByCondition(k => k.Id.Equals(speciesId), trackChanges)
            .SingleOrDefault();
        public void CreateSpecies(long genusId, Species species)
        {
            species.GenusId = genusId;
            Create(species); 
        }
    }
}
