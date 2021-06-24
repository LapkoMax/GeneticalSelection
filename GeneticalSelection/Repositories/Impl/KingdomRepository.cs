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
    public class KingdomRepository : RepositoryBase<Kingdom>, IKingdomRepository
    {
        public KingdomRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public new IQueryable<Kingdom> FindAll(bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Kingdoms.Include(k => k.Phylums).ThenInclude(p => p.Subphylums)
                .ThenInclude(sp => sp.Classes).ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).AsNoTracking() :
                RepositoryContext.Kingdoms.Include(k => k.Phylums).ThenInclude(p => p.Subphylums)
                .ThenInclude(sp => sp.Classes).ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species);
        public new IQueryable<Kingdom> FindByCondition(Expression<Func<Kingdom, bool>> expression, bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Kingdoms.Where(expression).Include(k => k.Phylums).ThenInclude(p => p.Subphylums)
                .ThenInclude(sp => sp.Classes).ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).AsNoTracking() :
                RepositoryContext.Kingdoms.Where(expression).Include(k => k.Phylums).ThenInclude(p => p.Subphylums)
                .ThenInclude(sp => sp.Classes).ThenInclude(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species);
        public IEnumerable<Kingdom> GetAllKingdoms(bool trackChanges = false) =>
            FindAll(trackChanges)
            .OrderBy(k => k.Name)
            .ToList();
        public Kingdom GetKingdom(long kingdomId, bool trackChanges = false) =>
            FindByCondition(k => k.Id.Equals(kingdomId), trackChanges)
            .SingleOrDefault();
        public void CreateKingdom(Kingdom kingdom) => Create(kingdom);
        public void DeleteKingdom(Kingdom kingdom) => Delete(kingdom);
    }
}
