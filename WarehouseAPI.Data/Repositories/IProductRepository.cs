using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAPI.Model;

namespace WarehouseAPI.Data.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetAllProducts();
        Task<Products> GetProductById(int id);
        Task<Products> GetProductBySku(string sku);
        Task<bool> SaveProduct(Products p);
        Task<bool> UpdateProduct(Products p);
        Task<bool> CancelProduct(int id);
        
    }
}
