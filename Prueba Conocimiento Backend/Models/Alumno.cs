using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Conocimiento_Backend.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        [Required]
        public string Identificacion { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        public virtual ICollection<Alumno_Materia> Materias { get; set; }
    }
}
