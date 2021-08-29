using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_Conocimiento_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba_Conocimiento_Backend.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AlumnosController(ApplicationDbContext context) {
            _context = context;
        }

        // GET: api/<AlumnosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listAlumnos = await _context.Alumnos.Include(a => a.Materias).ToListAsync();
                return Ok(listAlumnos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        // GET api/<AlumnosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var alumno = await _context.Alumnos.Include(m => m.Materias).ThenInclude(a => a.Materia).FirstOrDefaultAsync(m => m.Id == id);
                if (alumno == null) {
                    return NotFound();
                }
                else {
                return Ok(alumno);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AlumnosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Alumno alumno)
        {
            try
            {
                await _context.Alumnos.AddAsync(alumno);
                await _context.SaveChangesAsync();
                return Ok(alumno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AlumnosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Alumno alumno)
        {
            try
            {
                if (id != alumno.Id) 
                {
                    return BadRequest();
                }

                 _context.Alumnos.Update(alumno);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Alumno actualizado con exito"});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AlumnosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var alumno = await _context.Alumnos.FindAsync(id);
                if (alumno == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Alumnos.Remove(alumno);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Alumno eliminado con exito" });
      
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
