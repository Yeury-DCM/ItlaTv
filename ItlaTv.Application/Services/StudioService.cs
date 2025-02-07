
using ItlaTv.Application.Interfaces;
using ItlaTv.Application.ViewModels.GenreVm;
using ItlaTv.Application.ViewModels.StudioVm;
using ItlaTv.Domain.Entities;
using ItlaTv.Domain.Result;
using ItlaTv.Domain.Repositories.Interfaces ;


namespace ItlaTv.Application.Services
{
    public class StudioService : IStudioService
    {
        private IStudioRepository _studioRepository;

        public StudioService(IStudioRepository studioRepository)
        {
            _studioRepository = studioRepository;
        }

        public async Task<List<StudioViewModel>> GetAllViewModels()
        {
            OperationResult result = await _studioRepository.GetAll();
            var studiosList = (List<Studio>)result.Data!;

            return studiosList.Select(studio => new StudioViewModel()
            {
                Id = studio.ID,
                Name = studio.Name!
            }).ToList();

        }
        
        public async Task Add(SaveStudioViewModel vm)
        {
            Studio studio = new ();
            studio.Name = vm.Name;

            await _studioRepository.Add(studio);
        }

        public async Task Delete(int id)
        {
            OperationResult result = await _studioRepository.GetById(id);
            Studio studio = (Studio)result.Data!;

            await _studioRepository.Delete(studio);
        }


        public async Task<StudioViewModel> GetById(int id)
        {
            OperationResult result = await _studioRepository.GetById(id);
            Studio genre = (Studio)result.Data!;
            StudioViewModel studioVm = new() { Id = genre.ID, Name = genre.Name! };

            return studioVm;
        }

        public async Task<SaveStudioViewModel> GetByIdSaveViewModel(int id)
        {
            OperationResult result = await _studioRepository.GetById(id);
            Studio studio = (Studio)result.Data!;

            SaveStudioViewModel vm = new() { Id = studio.ID, Name = studio.Name! };

            return vm;
        }

        public async Task Update(SaveStudioViewModel vm)
        {
            OperationResult result = await _studioRepository.GetById(vm.Id);
            Studio studio = result.Data!;
            studio.Name = vm.Name;

            await _studioRepository.Update(studio);
        }
    }
}
