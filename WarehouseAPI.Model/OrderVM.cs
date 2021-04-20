using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI.Model
{
    public class OrderVM
    {
        public int OrderId { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime complete_date { get; set; }
        public DateTime cancel_date { get; set; }
        public OrderStatus status_code { get; set; }
        public string status_name => status_code.ToString();
        public IEnumerable<OrderDetailVM> order_items { get; set; }
    }
}
