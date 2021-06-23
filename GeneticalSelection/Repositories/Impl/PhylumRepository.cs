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
    public class PhylumRepository : RepositoryBase<Phylum>, IPhylumRepository
    {
        public PhylumRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public new IQueryable<Phylum> FindAll(bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Phylums.Include(p => p.Subphylums)
                .ThenInclude(sp => sp.Classes).ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).AsNoTracking() :
                RepositoryContext.Phylums.Include(p => p.Subphylums)
                .ThenInclude(sp => sp.Classes).ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species);
        public new IQueryable<Phylum> FindByCondition(Expression<Func<Phylum, bool>> expression, bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Phylums.Where(expression).Include(p => p.Subphylums)
                .ThenInclude(sp => sp.Classes).ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).AsNoTracking() :
                RepositoryContext.Phylums.Where(expression).Include(p => p.Subphylums)
                .ThenInclude(sp => sp.Classes).ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species);
        public IEnumerable<Phylum> GetAllPhylums(bool trackChanges = false) =>
            FindAll(trackChanges)
            .OrderBy(k => k.Name)
            .ToList();
        public Phylum GetPhylum(long phylumId, bool trackChanges = false) =>
            FindByCondition(k => k.Id.Equals(phylumId), trackChanges)
            .SingleOrDefault();
        public void CreatePhylum(long kingdomId, Phylum phylum) 
        {
            phylum.KingdomId = kingdomId;
            Create(phylum); 
        }
    }
}
