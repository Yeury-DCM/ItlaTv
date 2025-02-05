
using ItlaTv.Application.Interfaces;
using ItlaTv.Application.ViewModels.GenreVm;
using ItlaTv.Domain.Entities;
using ItlaTv.Persistence.Interfaces;

namespace ItlaTv.Application.Services
{
    public class GenreService : IGenreService
    {
        private IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<List<GenreViewModel>> GetAllViewModel()
        {
            var result = await _genreRepository.GetAll();

            var genresList = (ICollection<Genre>) result.Data!;

            return genresList.Select(genre => new GenreViewModel
            {
                ID = genre.ID,
                Name = genre.Name
            }).ToList();
        }
    }
}
