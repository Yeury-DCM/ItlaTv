using ItlaTv.Application.Interfaces;
using ItlaTv.Application.ViewModels.SerieVm;
using ItlaTv.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ItlaTv.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISerieService _serieService;
        private readonly IGenreService _genreService;
        private readonly IStudioService _studioService;

        public HomeController(ISerieService serieService, IStudioService studioService, IGenreService genreService)
        {
            _serieService = serieService;
            _studioService = studioService;
            _genreService = genreService;

        }

        public async Task<IActionResult> Index(FilterSerieViewModel filter)
        {
            ViewBag.Studios = await _studioService.GetAllViewModels();
            ViewBag.Genres = await _genreService.GetAllViewModels();

            return View(await _serieService.GetFilteredViewModels(filter));
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
