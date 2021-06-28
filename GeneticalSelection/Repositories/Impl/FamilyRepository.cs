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
    public class FamilyRepository : RepositoryBase<Family>, IFamilyRepository
    {
        public FamilyRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public new IQueryable<Family> FindAll(bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Families.Include(f => f.Genuses).ThenInclude(g => g.Species).Include(f => f.Order).AsNoTracking() :
                RepositoryContext.Families.Include(f => f.Genuses).ThenInclude(g => g.Species).Include(f => f.Order);
        public new IQueryable<Family> FindByCondition(Expression<Func<Family, bool>> expression, bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Families.Where(expression).Include(f => f.Genuses).ThenInclude(g => g.Species).Include(f => f.Order).AsNoTracking() :
                RepositoryContext.Families.Where(expression).Include(f => f.Genuses).ThenInclude(g => g.Species).Include(f => f.Order);
        public PagedList<Family> GetAllFamilies(QueryOptions options, bool trackChanges = false) =>
            new PagedList<Family>(FindAll(trackChanges)
                .OrderBy(k => k.Name), options);
        public Family GetFamily(long familyId, bool trackChanges = false) =>
            FindByCondition(k => k.Id.Equals(familyId), trackChanges)
            .SingleOrDefault();
        public void CreateFamily(long orderId, Family family) 
        {
            family.OrderId = orderId;
            Create(family);
        }
        public void DeleteFamily(Family family) => Delete(family);
    }
}
