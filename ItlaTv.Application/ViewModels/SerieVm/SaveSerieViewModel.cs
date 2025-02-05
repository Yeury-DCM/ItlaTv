using ItlaTv.Application.ViewModels.GenreVm;
using ItlaTv.Application.ViewModels.StudioVm;
using ItlaTv.Domain.Base;
using ItlaTv.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ItlaTv.Application.ViewModels.SerieVm
{
    public class SaveSerieViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="El nombre es requerido")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? ImagePath { get; set; }


        public string? VideoPath { get; set; }

        public List<GenreViewModel>? AvailableGenres { get; set; }

        [Required(ErrorMessage = "Los géneros son requeridos")]
        public List<int>? SelectedGenres { get; set; }

        public List<StudioViewModel>? AvailableStudios { get; set; }

        [Required(ErrorMessage = "La productora es requerida")]
        public int StudioID { get; set; }
        

    }

}
