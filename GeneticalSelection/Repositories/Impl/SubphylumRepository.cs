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
    public class SubphylumRepository : RepositoryBase<Subphylum>, ISubphylumRepository
    {
        public SubphylumRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public new IQueryable<Subphylum> FindAll(bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Subphylums.Include(sp => sp.Classes).
                ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(sp => sp.Phylum).AsNoTracking() :
                RepositoryContext.Subphylums.Include(sp => sp.Classes)
                .ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(sp => sp.Phylum);
        public new IQueryable<Subphylum> FindByCondition(Expression<Func<Subphylum, bool>> expression, bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Subphylums.Where(expression).Include(sp => sp.Classes).
                ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(sp => sp.Phylum).AsNoTracking() :
                RepositoryContext.Subphylums.Where(expression).Include(sp => sp.Classes).
                ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(sp => sp.Phylum);
        public PagedList<Subphylum> GetAllSubphylums(QueryOptions options, bool trackChanges = false) =>
            new PagedList<Subphylum>(FindAll(trackChanges)
                .OrderBy(k => k.Name), options);
        public Subphylum GetSubphylum(long subphylumId, bool trackChanges = false) =>
            FindByCondition(k => k.Id.Equals(subphylumId), trackChanges)
            .SingleOrDefault();
        public void CreateSubphylum(long phylumId, Subphylum subphylum) 
        {
            subphylum.PhylumId = phylumId;
            Create(subphylum); 
        }
        public void DeleteSubphylum(Subphylum subphylum) => Delete(subphylum);
    }
}
