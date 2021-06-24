using GeneticalSelection.Models;
using GeneticalSelection.Models.Entities;
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
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).AsNoTracking() :
                RepositoryContext.Subphylums.Include(sp => sp.Classes)
                .ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species);
        public new IQueryable<Subphylum> FindByCondition(Expression<Func<Subphylum, bool>> expression, bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Subphylums.Where(expression).Include(sp => sp.Classes).
                ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).AsNoTracking() :
                RepositoryContext.Subphylums.Where(expression).Include(sp => sp.Classes).
                ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species);
        public IEnumerable<Subphylum> GetAllSubphylums(bool trackChanges = false) =>
            FindAll(trackChanges)
            .OrderBy(k => k.Name)
            .ToList();
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
