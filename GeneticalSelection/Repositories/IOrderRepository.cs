using GeneticalSelection.Models.Entities;
using GeneticalSelection.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface IOrderRepository
    {
        PagedList<Order> GetAllOrders(QueryOptions options, bool trackChanges = false);
        Order GetOrder(long orderId, bool trackChanges = false);
        void CreateOrder(long classId, Order order);
        void DeleteOrder(Order order);
    }
}
