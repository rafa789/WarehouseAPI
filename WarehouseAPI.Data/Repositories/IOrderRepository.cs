using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAPI.Model;

namespace WarehouseAPI.Data.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderVM>> GetAllOrders();
        Task<OrderVM> GetOrderById(int id);
        Task<bool> SaveOrder(Order o);
       
        Task<bool> CancelOrder(int id);
        Task<bool> CompleteOrder(int id);
    }
}
