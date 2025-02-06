
using System.ComponentModel.DataAnnotations;

namespace ItlaTv.Application.ViewModels.Base
{
    public class BaseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }
    }
}
