using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI.Model
{
    public class InventoryAdjust
    {
        public int product_id { get; set; }
        public int adjust_quantity { get; set; }
    }
}
