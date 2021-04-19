using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI.Model
{
    public class Products
    {
        public int id { get; set; }
        [Required]
        public string sku_number { get; set; }
        [Required]
        public string description { get; set; }
        public DateTime dateTime { get; set; }
        public bool status { get; set; }
        public int quantity { get; set; }
    }
}
