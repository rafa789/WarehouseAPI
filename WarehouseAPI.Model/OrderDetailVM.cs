using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI.Model
{
    public class OrderDetailVM
    {
        public int product_id { get; set; }
        public int quantity { get; set; }
        public string SKuCode { get; set; }
        public string description { get; set; }
    }
}
