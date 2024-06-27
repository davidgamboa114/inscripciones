using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inscripciones.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        [Display(Name = "Año carrera")]
        public int AnioCarreraId { get; set; }
        [Display(Name = "Año carrera")]
        public AnioCarrera? AnioCarrera { get; set; }
        [NotMapped]
        public string NombreAñoYCarrera
        {
            get
            {
                return $"{Nombre} {AnioCarrera?.AñoYCarrera}" ?? string.Empty;
            }
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
