using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAPI.Model;

namespace WarehouseAPI.Data.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        public Task<bool> AdjustInventory(InventoryAdjust adjust)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetProductInventory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
