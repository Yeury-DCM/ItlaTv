using ItlaTv.Application.Interfaces;
using ItlaTv.Application.ViewModels.SerieVm;
using Microsoft.AspNetCore.Mvc;

namespace ItlaTv.Web.Controllers
{
    public class SerieController : Controller
    {
        private ISerieService _serieService;
        private IGenreService _genreService;
        private IStudioService _studioService;

        public SerieController(ISerieService serieService, IGenreService genreService, IStudioService studioService)
        {
            _serieService = serieService;
            _genreService = genreService;
            _studioService = studioService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _serieService.GetAllViewModels());
        }

        public async Task<IActionResult> Add()
        {
            SaveSerieViewModel saveSerieViewModel = new();
            ViewBag.Genres = await _genreService.GetAllViewModels();
            ViewBag.Studios = await _studioService.GetAllViewModels();

            return View("SaveSerie", saveSerieViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SaveSerieViewModel vm)
        {
            ViewBag.Genres = await _genreService.GetAllViewModels();
            ViewBag.Studios = await _studioService.GetAllViewModels();

            if (!ModelState.IsValid)
            {
                return View("SaveSerie",vm);
            }
            await _serieService.Add(vm);
            return RedirectToRoute(new { controller = "Serie", Action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {


            SaveSerieViewModel saveSerieViewModel = await _serieService.GetByIdSaveViewModel(id);
            ViewBag.Genres = await _genreService.GetAllViewModels();
            ViewBag.Studios = await _studioService.GetAllViewModels();

            return View("SaveSerie", saveSerieViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveSerieViewModel vm)
        {
            ViewBag.Genres = await _genreService.GetAllViewModels();
            ViewBag.Studios = await _studioService.GetAllViewModels();


            if (!ModelState.IsValid)
            {
                return View("SaveSerie", vm);
            }

            await _serieService.Update(vm);
            return RedirectToRoute(new { controller = "Serie", Action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            SaveSerieViewModel saveSerieViewModel = await _serieService.GetByIdSaveViewModel(id);

            return View("DeleteSerie", saveSerieViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _serieService.Delete(id);
            return RedirectToRoute(new { controller = "Serie", Action = "Index" });
        }

        public async Task<IActionResult> Detail(int id)
        {
            SerieViewModel vm = await _serieService.GetById(id);

            return View("SerieDetail", vm); 
        }
    }
}
