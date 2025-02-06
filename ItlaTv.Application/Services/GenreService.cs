
using ItlaTv.Application.Interfaces;
using ItlaTv.Application.ViewModels.GenreVm;
using ItlaTv.Domain.Entities;
using ItlaTv.Domain.Result;
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

        public async Task<List<GenreViewModel>> GetAllViewModels()
        {
            var result = await _genreRepository.GetAll();

            var genresList = (ICollection<Genre>)result.Data!;

            return genresList.Select(genre => new GenreViewModel
            {
                Id = genre.ID,
                Name = genre.Name!
            }).ToList();
        }

        public async Task Add(SaveGenreViewModel vm)
        {
            Genre genre = new Genre();
            genre.Name = vm.Name;

            await _genreRepository.Add(genre);
        }

        public async Task Delete(int id)
        {
            OperationResult result =await  _genreRepository.GetById(id);
            Genre genre = (Genre) result.Data!;

            await _genreRepository.Delete(genre);
        }


        public async Task<GenreViewModel> GetById(int id)
        {
            OperationResult result = await _genreRepository.GetById(id);
            Genre genre = (Genre)result.Data!;
            GenreViewModel genreVm = new() { Id= genre.ID, Name = genre.Name!, Series = genre.Series };

            return genreVm;
        }

        public async Task<SaveGenreViewModel> GetByIdSaveViewModel(int id)
        {
            OperationResult result = await _genreRepository.GetById(id);
            Genre genre = (Genre)result.Data!;

            SaveGenreViewModel vm = new() { Id = genre.ID, Name = genre.Name! };

            return vm;
        }

        public async Task Update(SaveGenreViewModel vm)
        {
            OperationResult result = await _genreRepository.GetById(vm.Id);
            Genre genre = result.Data!;
            genre.Name = vm.Name;
          
            await _genreRepository.Update(genre);
        }
    }
}
