using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TPFinal_ParralMiguel.Context;
using TPFinal_ParralMiguel.Models;

namespace TPFinal_ParralMiguel.Controllers
{
    [Authorize]
    public class PlatosController : Controller
    {
        private readonly ComandasContext _context;

        public PlatosController(ComandasContext context)
        {
            _context = context;
        }

        // GET: Platos
        [Authorize(Roles = "Admin, SuperAdmin, User")]
        public async Task<IActionResult> Index()
        {
              return View(await _context.Platos.ToListAsync());
        }

        // GET: Platos/Details/5
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Platos == null)
            {
                return NotFound();
            }

            var plato = await _context.Platos
                .FirstOrDefaultAsync(m => m.PlatoId == id);
            if (plato == null)
            {
                return NotFound();
            }

            return View(plato);
        }

        // GET: Platos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Platos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlatoId,PlatoNombre,PlatoPrecio,PlatoCantidad")] Plato plato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plato);
        }

        // GET: Platos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Platos == null)
            {
                return NotFound();
            }

            var plato = await _context.Platos.FindAsync(id);
            if (plato == null)
            {
                return NotFound();
            }
            return View(plato);
        }

        // POST: Platos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlatoId,PlatoNombre,PlatoPrecio,PlatoCantidad")] Plato plato)
        {
            if (id != plato.PlatoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatoExists(plato.PlatoId))
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
            return View(plato);
        }

        // GET: Platos/Delete/5
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Platos == null)
            {
                return NotFound();
            }

            var plato = await _context.Platos
                .FirstOrDefaultAsync(m => m.PlatoId == id);
            if (plato == null)
            {
                return NotFound();
            }

            return View(plato);
        }

        // POST: Platos/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin, SuperAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Platos == null)
            {
                return Problem("Entity set 'ComandasContext.Platos'  is null.");
            }
            var plato = await _context.Platos.FindAsync(id);
            if (plato != null)
            {
                _context.Platos.Remove(plato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatoExists(int id)
        {
          return _context.Platos.Any(e => e.PlatoId == id);
        }
    }
}
