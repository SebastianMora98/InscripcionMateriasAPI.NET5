using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Conocimiento_Backend.Models
{
    public class Materia
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string HoraInicio { get; set; }
        [Required]
        public string HoraFinal { get; set; }
        public virtual ICollection<Alumno_Materia> Alumnos { get; set; }
    }
}
