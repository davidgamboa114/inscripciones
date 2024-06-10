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
    public class AnioCarrerasController : Controller
    {
        private readonly InscripcionesContext _context;

        public AnioCarrerasController(InscripcionesContext context)
        {
            _context = context;
        }

        // GET: AnioCarreras
        public async Task<IActionResult> Index()
        {
            var inscripcionesContext = _context.AnioCarrera.Include(a => a.Carrera);
            return View(await inscripcionesContext.ToListAsync());
        }

        // GET: AnioCarreras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anioCarreras = await _context.AnioCarrera
                .Include(a => a.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anioCarreras == null)
            {
                return NotFound();
            }

            return View(anioCarreras);
        }

        // GET: AnioCarreras/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "Id", "Id");
            return View();
        }

        // POST: AnioCarreras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,CarreraId")] AnioCarrera anioCarreras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anioCarreras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "Id", "Id", anioCarreras.CarreraId);
            return View(anioCarreras);
        }

        // GET: AnioCarreras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anioCarreras = await _context.AnioCarrera.FindAsync(id);
            if (anioCarreras == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "Id", "Id", anioCarreras.CarreraId);
            return View(anioCarreras);
        }

        // POST: AnioCarreras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,CarreraId")] AnioCarrera anioCarreras)
        {
            if (id != anioCarreras.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anioCarreras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnioCarrerasExists(anioCarreras.Id))
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
            ViewData["CarreraId"] = new SelectList(_context.Carreras, "Id", "Id", anioCarreras.CarreraId);
            return View(anioCarreras);
        }

        // GET: AnioCarreras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anioCarreras = await _context.AnioCarrera
                .Include(a => a.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anioCarreras == null)
            {
                return NotFound();
            }

            return View(anioCarreras);
        }

        // POST: AnioCarreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anioCarreras = await _context.AnioCarrera.FindAsync(id);
            if (anioCarreras != null)
            {
                _context.AnioCarrera.Remove(anioCarreras);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnioCarrerasExists(int id)
        {
            return _context.AnioCarrera.Any(e => e.Id == id);
        }
    }
}
