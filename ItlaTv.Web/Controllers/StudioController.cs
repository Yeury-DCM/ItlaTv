using ItlaTv.Application.Interfaces;
using ItlaTv.Application.ViewModels.GenreVm;
using ItlaTv.Application.ViewModels.StudioVm;
using Microsoft.AspNetCore.Mvc;

namespace ItlaTv.Web.Controllers
{
    public class StudioController : Controller
    {
        IStudioService _studioService;

        public StudioController(IStudioService studioService)
        {
            _studioService = studioService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _studioService.GetAllViewModels());
        }

        public async Task<IActionResult> Add()
        {
            SaveStudioViewModel vm = new();

            return View("SaveStudio", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SaveStudioViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveStudio", vm);
            }
            await _studioService.Add(vm);
            return RedirectToRoute(new { controller = "Studio", Action = "Index" });
        }
        public async Task<IActionResult> Edit(int id)
        {
            SaveStudioViewModel vm = await _studioService.GetByIdSaveViewModel(id);

            return View("SaveStudio", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveStudioViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View("SaveGenre", vm);
            }

            await _studioService.Update(vm);
            return RedirectToRoute(new { controller = "Studio", Action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            SaveStudioViewModel vm = await _studioService.GetByIdSaveViewModel(id);

            return View("DeleteStudio", vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _studioService.Delete(id);
            return RedirectToRoute(new { controller = "Studio", Action = "Index" });
        }
    }
}
