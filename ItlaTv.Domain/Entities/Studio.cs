
using ItlaTv.Domain.Base;

namespace ItlaTv.Domain.Entities
{
    public class Studio : BaseEntity
    {
        //Navegation Property
        ICollection<Serie>? series;
    }

}
