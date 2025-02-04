
using ItlaTv.Domain.Entities;

namespace ItlaTv.Application.ViewModels
{
    public class SerieViewModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public string? VideoPath { get; set; }
        public Studio? studio { get; set; }
        public ICollection<Genre>? Genres { get; set; }
    }
}
