using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAPI.Model;

namespace WarehouseAPI.Data.Repositories
{
    public interface IInventoryRepository
    {
        Task<bool> AdjustInventory(InventoryAdjust adjust);
        Task<int> GetProductInventory(int id);
    }
}
