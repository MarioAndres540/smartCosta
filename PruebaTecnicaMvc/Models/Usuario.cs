using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PruebaTecnicaMvc.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "Email no válido")]
        public string Email { get; set; }

        public ICollection<Publicacion>? Publicaciones { get; set; }
    }
}
