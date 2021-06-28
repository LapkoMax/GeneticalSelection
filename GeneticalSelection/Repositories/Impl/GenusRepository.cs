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
    public class GenusRepository : RepositoryBase<Genus>, IGenusRepository
    {
        public GenusRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public new IQueryable<Genus> FindAll(bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Genuses.Include(g => g.Species).Include(g => g.Family).AsNoTracking() :
                RepositoryContext.Genuses.Include(g => g.Species).Include(g => g.Family);
        public new IQueryable<Genus> FindByCondition(Expression<Func<Genus, bool>> expression, bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Genuses.Where(expression).Include(g => g.Species).Include(g => g.Family).AsNoTracking() :
                RepositoryContext.Genuses.Where(expression).Include(g => g.Species).Include(g => g.Family);
        public PagedList<Genus> GetAllGenuses(QueryOptions options, bool trackChanges = false) =>
            new PagedList<Genus>(FindAll(trackChanges)
                .OrderBy(k => k.Name), options);
        public Genus GetGenus(long genusId, bool trackChanges = false) =>
            FindByCondition(k => k.Id.Equals(genusId), trackChanges)
            .SingleOrDefault();
        public void CreateGenus(long familyId, Genus genus)
        {
            genus.FamilyId = familyId;
            Create(genus);
        }
        public void DeleteGenus(Genus genus) => Delete(genus);
    }
}
