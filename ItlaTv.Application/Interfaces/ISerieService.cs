
using ItlaTv.Application.ViewModels.SerieVm;

namespace ItlaTv.Application.Interfaces
{
    public interface ISerieService
    {
        Task<List<SerieViewModel>> GetAllViewModel();

        Task<SaveSerieViewModel> GetById(int id);
        Task<SaveSerieViewModel> GetByIdSaveViewModel(int id);

        Task Delete(int id);

        Task Update(SaveSerieViewModel vm);
        Task Add(SaveSerieViewModel vm);


    }
}
