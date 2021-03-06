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
    public class ClassRepository : RepositoryBase<Class>, IClassRepository
    {
        public ClassRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public new IQueryable<Class> FindAll(bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Classes.Include(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(c => c.Subphylum).AsNoTracking() :
                RepositoryContext.Classes.Include(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(c => c.Subphylum);
        public new IQueryable<Class> FindByCondition(Expression<Func<Class, bool>> expression, bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Classes.Where(expression).Include(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(c => c.Subphylum).AsNoTracking() :
                RepositoryContext.Classes.Where(expression).Include(c => c.Orders).ThenInclude(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(c => c.Subphylum);
        public PagedList<Class> GetAllClasses(QueryOptions options, bool trackChanges = false) =>
            new PagedList<Class>(FindAll(trackChanges)
                .OrderBy(k => k.Name), options);
        public Class GetClass(long classId, bool trackChanges = false) =>
            FindByCondition(k => k.Id.Equals(classId), trackChanges)
            .SingleOrDefault();
        public void CreateClass(long subphylumId, Class cl) 
        {
            cl.SubphylumId = subphylumId;
            Create(cl); 
        }
        public void DeleteClass(Class cl) => Delete(cl);
    }
}
