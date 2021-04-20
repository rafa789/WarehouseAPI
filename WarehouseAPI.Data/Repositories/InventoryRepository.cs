using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAPI.Model;
using Dapper;

namespace WarehouseAPI.Data.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private MySqlConnection _connection;

        public InventoryRepository(MySqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> AdjustInventory(InventoryAdjust adjust)
        {
               var query = @"update inventory set quantity = @ajuste where product_id = @ProductId";

               var resp = await _connection.ExecuteAsync(query, new { ajuste = adjust.adjust_quantity, ProductId = adjust.product_id });

                return resp > 0;
                      
        }

        public async Task<int> GetProductInventory(int id)
        {
            var sql = "select fn_getInventory(@ProductId)";

            return await _connection.ExecuteScalarAsync<int>(sql, new { ProductId = id });
        }
    }
}
