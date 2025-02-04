using ItlaTv.Application.Interfaces;
using ItlaTv.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ItlaTv.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISerieService _serieService;
        public HomeController(ISerieService serieService)
        {
            _serieService = serieService;

        }

        public async Task<IActionResult> Index()
        {
            return View(await _serieService.GetAllViewModel());
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
