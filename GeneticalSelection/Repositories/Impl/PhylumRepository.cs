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
    public class PhylumRepository : RepositoryBase<Phylum>, IPhylumRepository
    {
        public PhylumRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public new IQueryable<Phylum> FindAll(bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Phylums.Include(p => p.Subphylums)
                .ThenInclude(sp => sp.Classes).ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(p => p.Kingdom).AsNoTracking() :
                RepositoryContext.Phylums.Include(p => p.Subphylums)
                .ThenInclude(sp => sp.Classes).ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(p => p.Kingdom);
        public new IQueryable<Phylum> FindByCondition(Expression<Func<Phylum, bool>> expression, bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Phylums.Where(expression).Include(p => p.Subphylums)
                .ThenInclude(sp => sp.Classes).ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(p => p.Kingdom).AsNoTracking() :
                RepositoryContext.Phylums.Where(expression).Include(p => p.Subphylums)
                .ThenInclude(sp => sp.Classes).ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(p => p.Kingdom);
        public PagedList<Phylum> GetAllPhylums(QueryOptions options, bool trackChanges = false) =>
            new PagedList<Phylum>(FindAll(trackChanges)
                .OrderBy(k => k.Name), options);
        public Phylum GetPhylum(long phylumId, bool trackChanges = false) =>
            FindByCondition(k => k.Id.Equals(phylumId), trackChanges)
            .SingleOrDefault();
        public void CreatePhylum(long kingdomId, Phylum phylum) 
        {
            phylum.KingdomId = kingdomId;
            Create(phylum); 
        }
        public void DeletePhylum(Phylum phylum) => Delete(phylum);
    }
}
