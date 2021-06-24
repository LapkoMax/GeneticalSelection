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
    public class FamilyRepository : RepositoryBase<Family>, IFamilyRepository
    {
        public FamilyRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public new IQueryable<Family> FindAll(bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Families.Include(f => f.Genuses).ThenInclude(g => g.Species).AsNoTracking() :
                RepositoryContext.Families.Include(f => f.Genuses).ThenInclude(g => g.Species);
        public new IQueryable<Family> FindByCondition(Expression<Func<Family, bool>> expression, bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Families.Where(expression).Include(f => f.Genuses).ThenInclude(g => g.Species).AsNoTracking() :
                RepositoryContext.Families.Where(expression).Include(f => f.Genuses).ThenInclude(g => g.Species);
        public IEnumerable<Family> GetAllFamilies(bool trackChanges = false) =>
            FindAll(trackChanges)
            .OrderBy(k => k.Name)
            .ToList();
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
