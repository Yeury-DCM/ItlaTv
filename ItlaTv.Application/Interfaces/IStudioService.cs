
using ItlaTv.Application.ViewModels.StudioVm;

namespace ItlaTv.Application.Interfaces
{
    public interface IStudioService
    {
        Task<List<StudioViewModel>> GetStudioViewModels();

    }
}
