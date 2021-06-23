using GeneticalSelection.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticalSelection.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders(bool trackChanges = false);
        Order GetOrder(long orderId, bool trackChanges = false);
        void CreateOrder(long classId, Order order);
    }
}
