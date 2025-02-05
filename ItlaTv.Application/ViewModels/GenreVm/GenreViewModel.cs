
using ItlaTv.Domain.Entities;

namespace ItlaTv.Application.ViewModels.GenreVm
{
    public class GenreViewModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public ICollection<Serie>? Series { get; set; }
    }
}
