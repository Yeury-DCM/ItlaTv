
using ItlaTv.Application.Interfaces;
using ItlaTv.Application.ViewModels.StudioVm;
using ItlaTv.Domain.Entities;
using ItlaTv.Domain.Result;
using ItlaTv.Persistence.Interfaces;

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
    }
}
