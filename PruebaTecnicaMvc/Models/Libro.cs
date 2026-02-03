using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaMvc.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [Display(Name = "Título del Libro")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio")]
        [Display(Name = "Autor")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "La fecha de publicación es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Publicación")]
        public DateTime FechaPublicacion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 99999999.99, ErrorMessage = "El precio debe ser mayor a 0 y válido")]
        public decimal Precio { get; set; }
    }
}
