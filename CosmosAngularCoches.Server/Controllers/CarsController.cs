using CosmosAngularCoches.Server.Interface;
using CosmosAngularCoches.Server.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CosmosAngularCoches.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carsService;

        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _carsService.GetMultipleCarsAsync("SELECT * FROM c"));
        }

        [HttpGet("{id}")]
        public async Task<Cars> Get(string id, string make)
        {
            return await _carsService.GetCarAsync(id, make);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cars car)
        {
            car.Id = Guid.NewGuid().ToString();
            await _carsService.AddCarAsync(car);
            return CreatedAtAction("Get", new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(string id, [FromBody] Cars car)
        {
            await _carsService.UpdateCarAsync(id, car);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, string make)
        {
            await _carsService.DeleteCarAsync(id, make);
            return NoContent();
        }
    }
}
