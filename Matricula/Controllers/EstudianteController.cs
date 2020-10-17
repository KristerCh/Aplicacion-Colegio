using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matricula.DataContext;
using Matricula.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Matricula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {

        //GET:
        private readonly UniversidadDataContext _baseDatos;
        public EstudianteController (UniversidadDataContext _context)
        {
            _baseDatos = _context;

            if(_baseDatos.Estudiantes.Count() == 0)
            {
                _baseDatos.Estudiantes.Add(new Estudiante { nombre = "Josue" });
                _baseDatos.SaveChanges();
            }
        }

        // Get: api/Estudiante
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetEstudiante()
        {
            return await _baseDatos.Estudiantes.Include(q => q.Curso).ToListAsync();
        }

        //GET: api/Estudiante/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            var est = await _baseDatos.Estudiantes.Include(q => q.Curso).FirstOrDefaultAsync(q => q.id == id);
            
            if(est == null)
            {
                return NotFound();
            }

            return est;
        }

        // POST: api/Estudiante 
        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante item)
        {
            _baseDatos.Estudiantes.Add(item);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstudiante), new { id = item.id }, item);

        }

        [HttpPost("rango")]
        public async Task<ActionResult<Estudiante>> PostEstudiante(IEnumerable<Estudiante> items)
        {
            _baseDatos.Estudiantes.AddRange(items);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstudiante), items);
        }

        //PUT: api/Estudiantes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante item)
        {
            if (id != item.id)
            {
                return BadRequest();
            }

            Curso curso = await _baseDatos.Cursos.FirstOrDefaultAsync(q => q.id == item.CursoId);
            if (curso == null)
            {
                return NotFound("El curso no existe");
            }

            _baseDatos.Entry(item).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return NoContent();
        }

        //DELETE: api/Estudiante/4
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var est = await _baseDatos.Estudiantes.FindAsync(id);

            if (est == null)
            {
                return NotFound();
            }

            _baseDatos.Estudiantes.Remove(est);
            await _baseDatos.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteEstudiantes(IEnumerable<int> ids)
        {
            IEnumerable<Estudiante> est = _baseDatos.Estudiantes.Where(q => ids.Contains(q.id));

            if (est == null)
            {
                return NotFound();
            }

            _baseDatos.Estudiantes.RemoveRange(est);
            await _baseDatos.SaveChangesAsync();

            return NoContent();
        }

    }
}
