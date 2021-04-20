using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseAPI.Data.Repositories;
using WarehouseAPI.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WarehouseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repository)
        {
            _repo = repository;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            return Ok( await _repo.GetAllProducts());
        }

       
        [HttpGet("{sku}")]
        public async Task<IActionResult> GetBySku(string sku)
        {
            return Ok(await _repo.GetProductBySku(sku));
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] Products products)
        {
            if (products == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repo.SaveProduct(products);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Products products)
        {
            if (products == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repo.UpdateProduct(products);

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.CancelProduct(id);

            return NoContent();
        }
    }
}
