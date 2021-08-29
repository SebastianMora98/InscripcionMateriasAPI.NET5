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
    public class MateriasController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public MateriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<MateriasController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listMaterias = await _context.Materias.Include(m => m.Alumnos).ToListAsync();
                return Ok(listMaterias);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<MateriasController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var materia = await _context.Materias.Include(m => m.Alumnos).ThenInclude(a => a.Alumno).FirstOrDefaultAsync(m => m.Id == id);
                if (materia == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(materia);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<MateriasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Materia materia)
        {
            try
            {
                await _context.Materias.AddAsync(materia);
                await _context.SaveChangesAsync();
                return Ok(materia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MateriasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Materia materia)
        {
            try
            {
                if (id != materia.Id)
                {
                    return BadRequest();
                }

                _context.Materias.Update(materia);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Materia actualizada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<MateriasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var materia = await _context.Materias.FindAsync(id);
                if (materia == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Materias.Remove(materia);
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Materia eliminado con exito" });

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
