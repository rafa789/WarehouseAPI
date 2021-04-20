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
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _repo;

        public InventoryController(IInventoryRepository repository)
        {
            _repo = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryById(int id)
        {
            return Ok(await _repo.GetProductInventory(id));
        }

        [HttpPut]
        public async Task<IActionResult> AdjustInventory([FromBody] InventoryAdjust adjust)
        {
            if (adjust == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repo.AdjustInventory(adjust);

            return Ok();
        }
    }
}
