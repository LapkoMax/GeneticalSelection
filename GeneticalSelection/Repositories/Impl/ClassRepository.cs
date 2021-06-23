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
    public class ClassRepository : RepositoryBase<Class>, IClassRepository
    {
        public ClassRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public new IQueryable<Class> FindAll(bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Classes.Include(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).AsNoTracking() :
                RepositoryContext.Classes.Include(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species);
        public new IQueryable<Class> FindByCondition(Expression<Func<Class, bool>> expression, bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Classes.Where(expression).Include(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).AsNoTracking() :
                RepositoryContext.Classes.Where(expression).Include(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species);
        public IEnumerable<Class> GetAllClasses(bool trackChanges = false) =>
            FindAll(trackChanges)
            .OrderBy(k => k.Name)
            .ToList();
        public Class GetClass(long classId, bool trackChanges = false) =>
            FindByCondition(k => k.Id.Equals(classId), trackChanges)
            .SingleOrDefault();
        public void CreateClass(long subphylumId, Class cl) 
        {
            cl.SubphylumId = subphylumId;
            Create(cl); 
        }
    }
}
