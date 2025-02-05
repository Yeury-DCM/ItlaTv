using ItlaTv.Application.ViewModels.GenreVm;


namespace ItlaTv.Application.Interfaces
{
    public interface IGenreService
    {
        Task<List<GenreViewModel>> GetAllViewModel();

    }
}
