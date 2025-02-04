using ItlaTv.Application.ViewModels;

namespace ItlaTv.Application.Interfaces
{
    public interface ISerieService
    {
       Task<List<SerieViewModel>> GetAllViewModel();
    }
}
