
using ItlaTv.Application.Interfaces;
using ItlaTv.Application.ViewModels;
using ItlaTv.Domain.Entities;
using ItlaTv.Domain.Result;
using ItlaTv.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ItlaTv.Application.Services
{
    public class SerieService : ISerieService
    {
        ISerieRepository _serieRepository;

        public SerieService(ISerieRepository serieRepository) 
        {
            _serieRepository = serieRepository;
        }

        public async Task<List<SerieViewModel>> GetAllViewModel()
        {
            var result = await _serieRepository.GetAll();

            var seriesList =(ICollection<Serie>) result.Data!;

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
    }
}
