using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseAPI.Data.Repositories;
using WarehouseAPI.Model;

namespace WarehouseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _repo;

        public OrderController(IOrderRepository repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _repo.GetAllOrders());
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrder([FromBody] Order order)
        {
            if (order == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repo.SaveOrder(order);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.CancelOrder(id);

            return NoContent();
        }

    }
}
