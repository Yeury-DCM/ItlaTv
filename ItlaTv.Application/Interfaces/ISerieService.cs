
using ItlaTv.Application.Base;
using ItlaTv.Application.ViewModels.SerieVm;

namespace ItlaTv.Application.Interfaces
{
    public interface ISerieService : IBaseService<SerieViewModel, SaveSerieViewModel>
    {
        Task<List<SerieViewModel>> GetFilteredViewModels(FilterSerieViewModel filter);
    }
}
