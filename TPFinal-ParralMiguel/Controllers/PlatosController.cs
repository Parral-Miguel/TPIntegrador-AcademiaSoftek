using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Details(string? id)
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
        [Authorize(Roles = "Admin, SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Plato plato)
        {
            string nuevaId = Guid.NewGuid().ToString();
            plato.PlatoId = nuevaId;

            if (ModelState.IsValid)
            {
                _context.Add(plato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plato);
        }

        // GET: Platos/Edit/5
        public async Task<IActionResult> Edit(string? id)
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
        [HttpPost]
        [Authorize(Roles = "Admin, SuperAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Plato plato)
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
                return RedirectToAction("Index", "Platos");
            }
            return View("Index", "Platos");
        }

        // GET: Platos/Delete/5
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Delete(string? id)
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
        public async Task<IActionResult> DeleteConfirmed(string id)
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
            return RedirectToAction("Index", "Platos");
        }

        private bool PlatoExists(string id)
        {
          return _context.Platos.Any(e => e.PlatoId == id);
        }
    }
}
