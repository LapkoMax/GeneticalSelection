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
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public new IQueryable<Order> FindAll(bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Orders.Include(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(o => o.Class).AsNoTracking() :
                RepositoryContext.Orders.Include(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(o => o.Class);
        public new IQueryable<Order> FindByCondition(Expression<Func<Order, bool>> expression, bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Orders.Where(expression).Include(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(o => o.Class).AsNoTracking() :
                RepositoryContext.Orders.Where(expression).Include(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).Include(o => o.Class);
        public PagedList<Order> GetAllOrders(QueryOptions options, bool trackChanges = false) =>
            new PagedList<Order>(FindAll(trackChanges)
                .OrderBy(k => k.Name), options);
        public Order GetOrder(long orderId, bool trackChanges = false) =>
            FindByCondition(k => k.Id.Equals(orderId), trackChanges)
            .SingleOrDefault();
        public void CreateOrder(long classId, Order order) 
        {
            order.ClassId = classId;
            Create(order); 
        }
        public void DeleteOrder(Order order) => Delete(order);
    }
}
