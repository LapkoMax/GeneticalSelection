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
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
        public new IQueryable<Order> FindAll(bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Orders.Include(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).AsNoTracking() :
                RepositoryContext.Orders.Include(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species);
        public new IQueryable<Order> FindByCondition(Expression<Func<Order, bool>> expression, bool trackChanges = false) =>
            !trackChanges ? RepositoryContext.Orders.Where(expression).Include(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species).AsNoTracking() :
                RepositoryContext.Orders.Where(expression).Include(o => o.Families)
                .ThenInclude(f => f.Genuses).ThenInclude(g => g.Species);
        public IEnumerable<Order> GetAllOrders(bool trackChanges = false) =>
            FindAll(trackChanges)
            .OrderBy(k => k.Name)
            .ToList();
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
