using ItlaTv.Application.Interfaces;
using ItlaTv.Application.Services;
using ItlaTv.Application.ViewModels.GenreVm;
using ItlaTv.Application.ViewModels.SerieVm;
using Microsoft.AspNetCore.Mvc;

namespace ItlaTv.Web.Controllers
{
    public class GenreController : Controller
    {
        IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _genreService.GetAllViewModels());
        }

        public async Task<IActionResult> Add()
        {
            SaveGenreViewModel vm = new();

            return View("SaveGenre", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SaveGenreViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGenre", vm);
            }
            await _genreService.Add(vm);
            return RedirectToRoute(new { controller = "Genre", Action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            SaveGenreViewModel vm = await _genreService.GetByIdSaveViewModel(id);

            return View("SaveGenre", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveGenreViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View("SaveGenre", vm);
            }

            await _genreService.Update(vm);
            return RedirectToRoute(new { controller = "Genre", Action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            SaveGenreViewModel vm = await _genreService.GetByIdSaveViewModel(id);

            return View("DeleteGenre", vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _genreService.Delete(id);
            return RedirectToRoute(new { controller = "Genre", Action = "Index" });
        }

    }
}
