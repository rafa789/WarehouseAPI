using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAPI.Model;

namespace WarehouseAPI.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Task<bool> CancelOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveOrder(Order o)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrder(Order o)
        {
            throw new NotImplementedException();
        }
    }
}
