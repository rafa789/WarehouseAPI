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
    public class ProductRepository : IProductRepository
    {
        private  MySqlConnection _connection;

        public ProductRepository(MySqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<bool> CancelProduct(int id)
        {
            var query = "update products set `status` = 0 where id =@productid";

            var result = await _connection.ExecuteAsync(query, new { productid = id });

            return result > 0;
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            var query = "select id, sku_number, description, creation_date, status, fn_getInventory(id) as quantity from products";

            return await _connection.QueryAsync<Products>(query);             
        }

        public async Task<Products> GetProductById(int id)
        {
            var query = "select id, sku_number, description, creation_date, status, fn_getInventory(id) as quantity from products where id = @productid";
            return await _connection.QueryFirstOrDefaultAsync<Products>(query,new {productid = id });
        }

        public async Task<Products> GetProductBySku(string sku)
        {
            var query = "select id, sku_number, description, creation_date, status, fn_getInventory(id) as quantity from products where sku_number = @Sku";
            return await _connection.QueryFirstOrDefaultAsync<Products>(query, new { Sku = sku });
        }

        public async Task<bool> SaveProduct(Products p)
        {
            var query = @"CALL sp_InsertProduct(@Sku,@Description,@ProductStatus,@Quantity);";

            var result = await _connection.ExecuteAsync(query, new { Sku = p.sku_number, Description = p.description, ProductStatus = 1, Quantity =p.quantity});

            return result > 0;
        }

        public async Task<bool> UpdateProduct(Products p)
        {
            var query = @"update products set sku_number = @sku_number, description = @description, status =  @status
                          where id = @id";

            var result = await _connection.ExecuteAsync(query, new { sku_number = p.sku_number, description = p.description, status = p.status, id =p.id  });

            return result > 0;
        }
    }
}
