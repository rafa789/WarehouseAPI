﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAPI.Model
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int id_order { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
    }
}
