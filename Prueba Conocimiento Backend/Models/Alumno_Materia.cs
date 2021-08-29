using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Prueba_Conocimiento_Backend.Models
{
    public class Alumno_Materia
    {
        [Key]
        [Column(Order=0)]
        public int AlumnoId { get; set; }
        [Key]
        [Column(Order=1)]
        public int MateriaId { get; set; }

        public virtual Alumno Alumno { get; set; }

        public virtual Materia Materia { get; set; }

        public string? fechaCreacion { get; set; }
        public string? fechaActualizacion{ get; set; }


    }
}
