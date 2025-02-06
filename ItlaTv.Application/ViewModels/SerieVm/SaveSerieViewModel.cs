using ItlaTv.Application.ViewModels.Base;
using ItlaTv.Application.ViewModels.GenreVm;
using ItlaTv.Application.ViewModels.StudioVm;
using ItlaTv.Domain.Base;
using ItlaTv.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ItlaTv.Application.ViewModels.SerieVm
{
    public class SaveSerieViewModel : BaseViewModel
    {

        public string? Description { get; set; }

        [Required(ErrorMessage = "La imagen es requerida")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "El video es requerido")]
        public string VideoPath { get; set; }

        [Required(ErrorMessage = "Los géneros son requeridos")]
        public List<int> SelectedGenres { get; set; }

        [Required(ErrorMessage = "La productora es requerida")]
        public int StudioID { get; set; }
        

    }

}
