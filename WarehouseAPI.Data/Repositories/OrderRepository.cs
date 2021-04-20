using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAPI.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace WarehouseAPI.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private MySqlConnection _connection;

        public OrderRepository(MySqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> CancelOrder(int id)
        {
            var query = @"Update orders set `status` = @orderstatus, cancel_date = NOW() where id = @orderId";

            var result = await _connection.ExecuteAsync(query, new { orderstatus = (int)OrderStatus.Cancelada, orderId = id });

            return result > 0;
        }

        public async Task<bool> CompleteOrder(int id)
        {
            var query = "CALL sp_completeOrder(@OrderId)";

            var result = await _connection.ExecuteAsync(query, new { OrderId = id });

            return result > 0;
        }

        public async Task<IEnumerable<OrderVM>> GetAllOrders()
        {
            List<OrderVM> orders = new List<OrderVM>();
            List<OrderDetailVM> orderDetails;
            OrderVM o;
            OrderDetailVM od;

            var query = "select id,creation_date,`status`, complete_date,cancel_date from orders";
            var query2 = "select id, id_order, product_id, quantity from order_detail where id_order = @OrderId";
            var query3 = "select id,sku_number,description,creation_date,status, fn_getInventory(id) as quantity from products where id = @ProductId";

            var objOrderstmp = await _connection.QueryAsync<Order>(query);

            foreach (var objorder in objOrderstmp)
            {
                orderDetails = new List<OrderDetailVM>();
                o = new OrderVM();
                o.OrderId = objorder.id;
                o.status_code = objorder.status;
                o.creation_date = objorder.creation_date;
                o.complete_date = objorder.complete_date;
                o.cancel_date = objorder.cancel_date;

                var details = await _connection.QueryAsync<OrderDetailVM>(query2, new { OrderId = o.OrderId });

                foreach (var item in details)
                {
                    od = new OrderDetailVM();
                    
                    od.product_id = item.product_id;
                    od.quantity = item.quantity;

                   var products = await _connection.QueryFirstOrDefaultAsync<Products>(query3, new { ProductId = od.product_id });

                    od.SKuCode = products.sku_number;
                    od.description = products.description;

                    orderDetails.Add(od);

                }
                o.order_items = orderDetails;
                orders.Add(o);
            }

            return orders;
        }

        public async Task<OrderVM> GetOrderById(int id)
        {
            List<OrderDetailVM> orderDetails = new List<OrderDetailVM>();
            OrderVM o  = new OrderVM(); ;
            OrderDetailVM od;

            var query = "select id,creation_date,`status`, complete_date,calcel_date from orders where id = @OrderId";
            var query2 = "select id, id_order, product_id, quantity from order_detail where id_order = @OrderId";
            var query3 = "select id,sku_number,description from products where id = @ProductId";

            var objtmp = await _connection.QueryFirstOrDefaultAsync<Order>(query, new { OrderId = id});
                          
            o.OrderId = objtmp.id;
            o.status_code = objtmp.status;
            o.creation_date = objtmp.creation_date;
            o.complete_date = objtmp.complete_date;
            o.cancel_date = objtmp.cancel_date;

            var details = await _connection.QueryAsync<OrderDetail>(query2, new { OrderId = o.OrderId });

            foreach (var item in details)
            {
                od = new OrderDetailVM();
                
                od.product_id = item.product_id;
                od.quantity = item.quantity;

                var products = await _connection.QueryFirstOrDefaultAsync<Products>(query3, new { ProductId = od.product_id });

                od.SKuCode = products.sku_number;
                od.description = products.description;

                orderDetails.Add(od);

            }
            o.order_items = orderDetails;
                
            return o;
        }

        public async Task<bool> SaveOrder(Order o)
        {
            var queryorden = @"insert into orders(creation_date,`status`) values (@CreationDate, @StatusOrder); 
                               select @@identity;";

            var queryItems = "insert into order_detail(id_order,product_id,quantity,created_date) values(@OrderId,@ProductId,@Quantity,@CreatedDate)";

            var orderid = await _connection.ExecuteScalarAsync<int>(queryorden,new { CreationDate = DateTime.Now, StatusOrder = (int)OrderStatus.Pendiente});

            foreach (var item in o.items)
            {
                await _connection.ExecuteAsync(queryItems,new { OrderId = orderid, ProductId = item.product_id, Quantity = item.quantity, CreatedDate = DateTime.Now});
            }

            return orderid > 0;
        }

       
    }
}
