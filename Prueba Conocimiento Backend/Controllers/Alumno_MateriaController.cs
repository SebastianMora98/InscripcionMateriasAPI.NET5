using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Prueba_Conocimiento_Backend.Models;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba_Conocimiento_Backend.Controllers
{
 

    [Route("api/[controller]")]
    [ApiController]
    public class Alumno_MateriaController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public Alumno_MateriaController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<Alumno_MateriaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listAlumnosMaterias = await _context.Alumno_Materias.Include(am => am.Alumno).Include(am => am.Materia).OrderByDescending(am => am.fechaActualizacion).ToListAsync();
                return Ok(listAlumnosMaterias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET api/<Alumno_MateriaController>/5
        [HttpGet("byIds")]
        public async Task<IActionResult> Get(int AlumnoId, int MateriaId)
        {
            try
            {
                var alumnosMaterias = await _context.Alumno_Materias
                    .Include(am => am.Alumno)
                    .Include(am => am.Materia)
                    .FirstOrDefaultAsync(am => am.AlumnoId== AlumnoId && am.MateriaId  == MateriaId);

                if (alumnosMaterias == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(alumnosMaterias);
                }
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<Alumno_MateriaController>
        [HttpPost]
        public async Task<IActionResult> Post(int AlumnoId, int MateriaId)
        {
            try
            {
                //Verifica si existe la inscripcion
                var alumnosMaterias = _context.Alumno_Materias
                    .FirstOrDefault(am => am.AlumnoId == AlumnoId && am.MateriaId == MateriaId);

                if (alumnosMaterias != null)
                {
                    return NotFound("Ya existe la inscripcion");
                }

                // Verifica que los id existan
                var alumno = await _context.Alumnos.FindAsync(AlumnoId);
                var materia = await _context.Materias.FindAsync(MateriaId);

                if (alumno == null || materia == null)
                {
                    string mensaje = "No se encontraron: " + (alumno == null ? "alumno" :"") + (materia == null ? ", materia" : "");
                    return NotFound(mensaje);
                }
                else
                {
                    // Crea la Inscripcion
                    Alumno_Materia alumno_materia = new Alumno_Materia();
                    alumno_materia.AlumnoId = AlumnoId;
                    alumno_materia.MateriaId = MateriaId;
                    alumno_materia.fechaCreacion = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
                    alumno_materia.fechaActualizacion = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
                    _context.Alumno_Materias.Add(alumno_materia);
                    _context.SaveChanges();
                    return Ok(alumno_materia);
                }

               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<Alumno_MateriaController>/5
        [HttpPut("{AlumnoId}/{MateriaId}")]
        public async Task<IActionResult> Put(int AlumnoId, int MateriaId, [FromBody] Alumno_Materia alumnoMateria)
        {
            try
            {
                // Verifica si existe la inscripcion
                var inscripcion =  _context.Alumno_Materias.FirstOrDefault(am => am.AlumnoId == alumnoMateria.Alumno.Id && am.MateriaId == alumnoMateria.Materia.Id);
                if (inscripcion != null)
                {
                    return Problem("Ya existe la inscripción");
                }
                else
                {
                    try
                    {
                        // eliminar inscripcion
                        var alumno_materia_anterior =  await _context.Alumno_Materias
                            .FirstOrDefaultAsync(am => am.AlumnoId == AlumnoId && am.MateriaId == MateriaId);

                        if (alumno_materia_anterior == null)
                        {
                            return NotFound();
                        }
                        else
                        {
                            _context.Alumno_Materias.Remove(alumno_materia_anterior);
                            await _context.SaveChangesAsync();
                        }

                        // crear nueva
                        Alumno_Materia alumno_materia = new Alumno_Materia();
                        alumno_materia.AlumnoId = alumnoMateria.Alumno.Id;
                        alumno_materia.MateriaId = alumnoMateria.Materia.Id;
                        alumno_materia.fechaCreacion = alumnoMateria.fechaCreacion;
                        alumno_materia.fechaActualizacion = DateTime.UtcNow.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
                        _context.Alumno_Materias.Add(alumno_materia);
                        _context.SaveChanges();
                        return Ok(new { message = "Inscripcion actualizada con exito" });
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<Alumno_MateriaController>/5
        [HttpDelete("{AlumnoId}/{MateriaId}")]
        public async Task<IActionResult> Delete(int AlumnoId, int MateriaId)
        {
            try
            {

                var alumno_materia = await _context.Alumno_Materias
                    .FirstOrDefaultAsync(am => am.AlumnoId == AlumnoId && am.MateriaId == MateriaId); 

                if (alumno_materia == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Alumno_Materias.Remove(alumno_materia);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Inscripción eliminada con exito" });

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}
