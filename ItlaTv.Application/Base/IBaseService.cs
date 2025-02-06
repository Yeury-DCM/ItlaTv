using ItlaTv.Application.ViewModels.SerieVm;

namespace ItlaTv.Application.Base
{
    public interface IBaseService <TViewModel, TSaveViewModel> 
    {
        Task<List<TViewModel>> GetAllViewModel();
        Task<TViewModel> GetById(int id);
        Task<TSaveViewModel> GetByIdSaveViewModel(int id);
        Task Delete(int id);
        Task Update(TSaveViewModel vm);
        Task Add(TSaveViewModel vm);
    }
}
