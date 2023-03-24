using Microsoft.AspNetCore.Mvc;
using ParkingMVC.Application.Interfaces;

namespace ParkingMVCWeb.Controllers
{
    public class ParkingSpaceController : Controller
    {
        private readonly IParkingSpaceService _parkingService;

        public ParkingSpaceController(IParkingSpaceService parkingService)
        {
            _parkingService = parkingService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var parkings = await _parkingService.GetParkingsSpaces();
            return View(parkings);
        }
    }
}
