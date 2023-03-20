using Microsoft.AspNetCore.Mvc;
using SD_330_Demos.Data;
using SD_330_Demos.Models;
using System.Diagnostics;

namespace SD_330_Demos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SD_330_DemosContext _context;

        public HomeController(ILogger<HomeController> logger, SD_330_DemosContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            Animal newAnimal = new Animal();
            Plant newPlant = new Plant();

            _context.Plant.Add(newPlant);
            _context.Animal.Add(newAnimal);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}