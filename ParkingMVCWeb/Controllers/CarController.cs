using Microsoft.AspNetCore.Mvc;
using ParkingMVC.Application.DTOs;
using ParkingMVC.Application.Interfaces;

namespace ParkingMVCWeb.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("api/cars")]
        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetCars();
            return Ok(cars);
        }

        [HttpGet("api/cars/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var car = await _carService.GetCarById(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost("api/cars")]
        public async Task<IActionResult> Create([FromBody] CarDTO carDTO)
        {
            if (carDTO == null)
            {
                return BadRequest();
            }

            await _carService.Add(carDTO);

            return CreatedAtAction(nameof(Details), new { id = carDTO.Id }, carDTO);
        }

        [HttpPut("api/cars/{id}")]
        public async Task<IActionResult> Edit(int? id, [FromBody] CarDTO carDTO)
        {
            if (id == null || carDTO == null || id != carDTO.Id)
            {
                return BadRequest();
            }

            try
            {
                await _carService.Update(carDTO);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("api/cars/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                await _carService.Remove(id.Value);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
