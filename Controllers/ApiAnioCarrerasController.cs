using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;

namespace Inscripciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAnioCarrerasController : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public ApiAnioCarrerasController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/ApiAnioCarreras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnioCarrera>>> GetAnioCarreras()
        {
            return await _context.AnioCarrera.ToListAsync();
        }

        // GET: api/ApiAnioCarreras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnioCarrera>> GetAnioCarreras(int id)
        {
            var anioCarreras = await _context.AnioCarrera.FindAsync(id);

            if (anioCarreras == null)
            {
                return NotFound();
            }

            return anioCarreras;
        }

        // PUT: api/ApiAnioCarreras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnioCarreras(int id, AnioCarrera anioCarreras)
        {
            if (id != anioCarreras.Id)
            {
                return BadRequest();
            }

            _context.Entry(anioCarreras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnioCarrerasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiAnioCarreras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnioCarrera>> PostAnioCarreras(AnioCarrera anioCarreras)
        {
            _context.AnioCarrera.Add(anioCarreras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnioCarreras", new { id = anioCarreras.Id }, anioCarreras);
        }

        // DELETE: api/ApiAnioCarreras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnioCarreras(int id)
        {
            var anioCarreras = await _context.AnioCarrera.FindAsync(id);
            if (anioCarreras == null)
            {
                return NotFound();
            }

            _context.AnioCarrera.Remove(anioCarreras);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnioCarrerasExists(int id)
        {
            return _context.AnioCarrera.Any(e => e.Id == id);
        }
    }
}
