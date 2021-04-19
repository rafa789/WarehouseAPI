using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI.Model
{
    public class Order
    {
        public int id { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime complete_date { get; set; }
        public OrderStatus status { get; set; }
        public IEnumerable<OrderDetail> order_items { get; set; }
    }
}
