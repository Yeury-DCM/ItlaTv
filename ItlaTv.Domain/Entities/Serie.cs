
using ItlaTv.Domain.Base;

namespace ItlaTv.Domain.Entities
{
    public class Serie : BaseEntity
    {
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public string? VideoPath { get; set; }
        public int StudioID { get; set; } //FK

        // Navegation Property (Hace un Join)
        public Studio? studio { get; set; }
        public ICollection<Genre>? Genres { get; set; }


    }
}
