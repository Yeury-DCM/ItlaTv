
using ItlaTv.Domain.Base;

namespace ItlaTv.Domain.Entities
{
    public class Genre : BaseEntity
    {
        //Navegation Property
        public ICollection<Serie>? Series { get; set; }
    }
}
