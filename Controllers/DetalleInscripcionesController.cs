using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;

namespace Inscripciones.Controllers
{
    public class DetalleInscripcionesController : Controller
    {
        private readonly InscripcionesContext _context;

        public DetalleInscripcionesController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: DetalleInscripciones
        public async Task<IActionResult> Index()
        {
            var inscripcionesContext = _context.DetalleInscripciones.Include(d => d.Inscripcion);
            return View(await inscripcionesContext.ToListAsync());
        }

        // GET: DetalleInscripciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleInscripciones = await _context.DetalleInscripciones
                .Include(d => d.Inscripcion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleInscripciones == null)
            {
                return NotFound();
            }

            return View(detalleInscripciones);
        }

        // GET: DetalleInscripciones/Create
        public IActionResult Create()
        {
            ViewData["InscripcionId"] = new SelectList(_context.Inscripciones, "Id", "Id");
            return View();
        }

        // POST: DetalleInscripciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ModalidadCursado,InscripcionId,MateriasId")] DetalleInscripciones detalleInscripciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleInscripciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InscripcionId"] = new SelectList(_context.Inscripciones, "Id", "Id", detalleInscripciones.InscripcionId);
            return View(detalleInscripciones);
        }

        // GET: DetalleInscripciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleInscripciones = await _context.DetalleInscripciones.FindAsync(id);
            if (detalleInscripciones == null)
            {
                return NotFound();
            }
            ViewData["InscripcionId"] = new SelectList(_context.Inscripciones, "Id", "Id", detalleInscripciones.InscripcionId);
            return View(detalleInscripciones);
        }

        // POST: DetalleInscripciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ModalidadCursado,InscripcionId,MateriasId")] DetalleInscripciones detalleInscripciones)
        {
            if (id != detalleInscripciones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleInscripciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleInscripcionesExists(detalleInscripciones.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["InscripcionId"] = new SelectList(_context.Inscripciones, "Id", "Id", detalleInscripciones.InscripcionId);
            return View(detalleInscripciones);
        }

        // GET: DetalleInscripciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleInscripciones = await _context.DetalleInscripciones
                .Include(d => d.Inscripcion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleInscripciones == null)
            {
                return NotFound();
            }

            return View(detalleInscripciones);
        }

        // POST: DetalleInscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleInscripciones = await _context.DetalleInscripciones.FindAsync(id);
            if (detalleInscripciones != null)
            {
                _context.DetalleInscripciones.Remove(detalleInscripciones);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleInscripcionesExists(int id)
        {
            return _context.DetalleInscripciones.Any(e => e.Id == id);
        }
    }
}
