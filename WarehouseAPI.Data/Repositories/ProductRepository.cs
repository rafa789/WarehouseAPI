using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAPI.Model;

namespace WarehouseAPI.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<bool> CancelProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Products>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Products> GetProductById()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveProduct(Products p)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(Products p)
        {
            throw new NotImplementedException();
        }
    }
}
