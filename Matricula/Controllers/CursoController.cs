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
    public class CursoController : ControllerBase
    {
        private readonly UniversidadDataContext _baseDatos;
        public CursoController(UniversidadDataContext _context)
        {
            _baseDatos = _context;

            if (_baseDatos.Cursos.Count() == 0)
            {
                _baseDatos.Cursos.Add(new Curso { nombre = "Josue" });
                _baseDatos.SaveChanges();
            }
        }

        // Get: api/Curso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            return await _baseDatos.Cursos.Include(q => q.Estudiantes).ToListAsync();
        }

        //GET: api/Curso/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var cu = await _baseDatos.Cursos.Include(q => q.Estudiantes).FirstOrDefaultAsync(q => q.id == id);

            if (cu == null)
            {
                return NotFound();
            }

            return cu;
        }

        // POST: api/Curso 
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso item)
        {
            _baseDatos.Cursos.Add(item);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCurso), new { id = item.id }, item);

        }

        [HttpPost("rango")]
        public async Task<ActionResult<Curso>> PostCurso(IEnumerable<Curso> items)
        {
            _baseDatos.Cursos.AddRange(items);
            await _baseDatos.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCurso), items);
        }

        //PUT: api/Curso/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso item)
        {
            if (id != item.id)
            {
                return BadRequest();
            }

            _baseDatos.Entry(item).State = EntityState.Modified;
            await _baseDatos.SaveChangesAsync();

            return NoContent();
        }

        //DELETE: api/Curso/4
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var cu = await _baseDatos.Cursos.FindAsync(id);

            if (cu == null)
            {
                return NotFound();
            }

            _baseDatos.Cursos.Remove(cu);
            await _baseDatos.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("rango")]
        public async Task<IActionResult> DeleteCursos(IEnumerable<int> ids)
        {
            IEnumerable<Curso> cus = _baseDatos.Cursos.Where(q => ids.Contains(q.id));

            if (cus == null)
            {
                return NotFound();
            }

            _baseDatos.Cursos.RemoveRange(cus);
            await _baseDatos.SaveChangesAsync();

            return NoContent();
        }


    }
}
