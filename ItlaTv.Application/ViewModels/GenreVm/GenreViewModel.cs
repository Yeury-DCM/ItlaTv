
using ItlaTv.Application.ViewModels.Base;
using ItlaTv.Domain.Entities;

namespace ItlaTv.Application.ViewModels.GenreVm
{
    public class GenreViewModel : BaseViewModel
    {
        public ICollection<Serie>? Series { get; set; }
    }
}
