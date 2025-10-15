using Computer_Peripheral___Stock_Management.Model;
using Computer_Peripheral___Stock_Management.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Computer_Peripheral___Stock_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeripheralsController : ControllerBase
    {
        private readonly IPeripheralRepository _repo;

        public PeripheralsController(IPeripheralRepository repo)
        {
            _repo = repo;
        }

        // GET: api/peripherals
        [HttpGet]
        public async Task<IActionResult> GetAllPeripherals()
        {
            var peripherals = await _repo.GetAllPeripherals();
            return Ok(peripherals);
        }

        // GET: api/peripherals/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPeripheralById(int id)
        {
            var peripheral = await _repo.GetPeripheral(id);
            if (peripheral == null)
                return NotFound($"Peripheral with ID {id} not found.");

            return Ok(peripheral);
        }

        // POST: api/peripherals
        [HttpPost]
        public async Task<IActionResult> AddPeripheral([FromBody] Peripheral peripheral)
        {
            if (peripheral == null)
                return BadRequest("Peripheral cannot be null.");

            try
            {
                await _repo.AddPeripheral(peripheral);
                return CreatedAtAction(nameof(GetPeripheralById), new { id = peripheral.Id }, peripheral);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message); // 409 Conflict
            }
        }

        // PUT: api/peripherals/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePeripheral(int id, [FromBody] Peripheral peripheral)
        {
            if (id != peripheral.Id)
                return BadRequest("ID mismatch.");

            try
            {
                await _repo.UpdatePeripheral(peripheral);
                return NoContent(); // 204
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE: api/peripherals/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeripheral(int id)
        {
            try
            {
                await _repo.RemovePeripheral(id);
                return NoContent(); // 204
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
