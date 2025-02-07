
using ItlaTv.Application.Interfaces;

using ItlaTv.Application.ViewModels.SerieVm;
using ItlaTv.Domain.Entities;
using ItlaTv.Domain.Result;
using ItlaTv.Domain.Repositories.Interfaces;


namespace ItlaTv.Application.Services
{
    public class SerieService : ISerieService
    {
        ISerieRepository _serieRepository;
        IStudioRepository _studioRepository;
        IGenreRepository _genreRepository;


        public SerieService(ISerieRepository serieRepository, IStudioRepository studioRepository, IGenreRepository genreRepository)
        {
            _serieRepository = serieRepository;
            _studioRepository = studioRepository;
            _genreRepository = genreRepository;

        }

        public async Task<List<SerieViewModel>> GetAllViewModels()
        {
            var result = await _serieRepository.GetAll();

            var seriesList = (ICollection<Serie>)result.Data!;

            return seriesList.Select(serie => new SerieViewModel
            {
                ID = serie.ID,
                Name = serie.Name,
                Description = serie.Description,
                Genres = serie.Genres,
                studio = serie.Studio,
                ImagePath = serie.ImagePath,
                VideoPath = serie.VideoPath,

            }).ToList();


        }

        public async Task Add(SaveSerieViewModel vm)
        {
            OperationResult genreResult = await _genreRepository.GetAll();
            List<Genre> availableGenres = genreResult.Data!;
            List<int> genresSelected = new List<int>();

            genresSelected.Add(vm.PrimaryGenre);

            if (vm.SecondaryGenre > 0)
                genresSelected.Add(vm.SecondaryGenre);

            List<Genre> genres = availableGenres.Where(ge => genresSelected.Contains(ge.ID)).ToList();


            Serie serie = new()
            {
                Name = vm.Name,
                Description = vm.Description,
                ImagePath = vm.ImagePath,
                VideoPath = vm.VideoPath,
                StudioID = vm.StudioID,
                Genres = genres
            };

            OperationResult result = await _serieRepository.Add(serie);

        }

        public async Task Update(SaveSerieViewModel vm)
        {
            OperationResult genreResult = await _genreRepository.GetAll();
            List<Genre> availableGenres = genreResult.Data!;


            Genre primaryGenre = availableGenres.FirstOrDefault(ge => ge.ID == vm.PrimaryGenre)!;

            List<Genre> genres = new() { primaryGenre };

            if (vm.SecondaryGenre > 0)
                genres.Add(availableGenres.FirstOrDefault(ge => ge.ID == vm.SecondaryGenre)!);

            Serie serie = new()
            {
                Name = vm.Name,
                Description = vm.Description,
                ImagePath = vm.ImagePath,
                VideoPath = vm.VideoPath,
                StudioID = vm.StudioID,
                Genres = genres,
                ID = vm.Id,
            };

            OperationResult result = await _serieRepository.Update(serie);

        }


        public async Task<SaveSerieViewModel> GetByIdSaveViewModel(int id)
        {
            var result = await _serieRepository.GetById(id);
            Serie serie = result.Data!;
            SaveSerieViewModel vm = new SaveSerieViewModel
            {
                Id = serie.ID,
                Name = serie.Name,
                Description = serie.Description,
                ImagePath = serie.ImagePath,
                VideoPath = serie.VideoPath,
                StudioID = serie.StudioID,
                PrimaryGenre = serie.Genres.ToList()[0].ID,
                SecondaryGenre = serie.Genres.ToArray().Length > 1 ? serie.Genres.ToList()[1].ID : 0

            };

            return vm;

        }

        public async Task Delete(int id)
        {
            var result = await _serieRepository.GetById(id);
            Serie serie = result.Data!;

            await _serieRepository.Delete(serie);
        }

        public async Task<SerieViewModel> GetById(int id)
        {
            var result = await _serieRepository.GetById(id);
            Serie serie = result.Data!;
            SerieViewModel vm = new SerieViewModel
            {
                Name = serie.Name,
                Description = serie.Description,
                ImagePath = serie.ImagePath,
                VideoPath = serie.VideoPath,
                studio = serie.Studio,
                Genres = serie.Genres

            };

            return vm;
        }

        public async Task<List<SerieViewModel>> GetFilteredViewModels(FilterSerieViewModel filter)
        {
            List<SerieViewModel> listViewModels = await GetAllViewModels();

            if (filter == null)
            {
                return listViewModels;
            }

            //Name filter


            if (!string.IsNullOrEmpty(filter.Name))
            {
                listViewModels = listViewModels.Where(serie => serie.Name.ToLower()!.Contains(filter.Name.ToLower()!)).ToList();
            }

            //Studio Filter


            if (filter.StudioId > 0)
            {
                listViewModels = listViewModels.Where(serie => serie.studio!.ID == filter.StudioId).ToList();
            }


            //Genre filter

            if (filter.GenresIds != null && filter.GenresIds.Count > 0)
            {
              
                listViewModels = listViewModels
                    .Where(serie => serie.Genres!.Any(genre => filter.GenresIds!.Contains(genre.ID)))
                    .ToList();
            }

            return listViewModels;

        }
    }
}
