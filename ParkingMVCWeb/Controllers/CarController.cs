using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetCars();
            return View(cars);
        }
    }
}
