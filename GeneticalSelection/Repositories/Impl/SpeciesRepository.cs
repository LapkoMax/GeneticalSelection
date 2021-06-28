using GeneticalSelection.Models;
using GeneticalSelection.Models.Entities;
using GeneticalSelection.Models.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories.Impl
{
    public class SpeciesRepository : RepositoryBase<Species>, ISpeciesRepository
    {
        public SpeciesRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public new IQueryable<Species> FindAll(bool trackChanges = false) =>
           !trackChanges ? RepositoryContext.Species.Include(s => s.Genus).AsNoTracking() :
               RepositoryContext.Species.Include(s => s.Genus);
        public new IQueryable<Species> FindByCondition(Expression<Func<Species, bool>> expression, bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Species.Where(expression).Include(s => s.Genus).AsNoTracking() :
                RepositoryContext.Species.Where(expression).Include(s => s.Genus);
        public PagedList<Species> GetAllSpecies(QueryOptions options, bool trackChanges = false) =>
            new PagedList<Species>(FindAll(trackChanges)
                .OrderBy(k => k.Name), options);
        public Species GetSpecies(long speciesId, bool trackChanges = false) =>
            FindByCondition(k => k.Id.Equals(speciesId), trackChanges)
            .SingleOrDefault();
        public void CreateSpecies(long genusId, Species species)
        {
            species.GenusId = genusId;
            Create(species); 
        }
        public void DeleteSpecies(Species species) => Delete(species);
    }
}
