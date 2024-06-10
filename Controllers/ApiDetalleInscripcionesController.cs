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
    public class ApiDetalleInscripcionesController : ControllerBase
    {
        private readonly InscripcionesContext _context;

        public ApiDetalleInscripcionesController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: api/DetalleInscripciones1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleInscripciones>>> GetDetalleInscripciones()
        {
            return await _context.DetalleInscripciones.ToListAsync();
        }

        // GET: api/DetalleInscripciones1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleInscripciones>> GetDetalleInscripciones(int id)
        {
            var detalleInscripciones = await _context.DetalleInscripciones.FindAsync(id);

            if (detalleInscripciones == null)
            {
                return NotFound();
            }

            return detalleInscripciones;
        }

        // PUT: api/DetalleInscripciones1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleInscripciones(int id, DetalleInscripciones detalleInscripciones)
        {
            if (id != detalleInscripciones.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleInscripciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleInscripcionesExists(id))
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

        // POST: api/DetalleInscripciones1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleInscripciones>> PostDetalleInscripciones(DetalleInscripciones detalleInscripciones)
        {
            _context.DetalleInscripciones.Add(detalleInscripciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleInscripciones", new { id = detalleInscripciones.Id }, detalleInscripciones);
        }

        // DELETE: api/DetalleInscripciones1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleInscripciones(int id)
        {
            var detalleInscripciones = await _context.DetalleInscripciones.FindAsync(id);
            if (detalleInscripciones == null)
            {
                return NotFound();
            }

            _context.DetalleInscripciones.Remove(detalleInscripciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleInscripcionesExists(int id)
        {
            return _context.DetalleInscripciones.Any(e => e.Id == id);
        }
    }
}
