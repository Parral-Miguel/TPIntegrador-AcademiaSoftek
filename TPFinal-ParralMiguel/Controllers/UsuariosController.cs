
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using TPFinal_ParralMiguel.Context;
using TPFinal_ParralMiguel.Models;

namespace TPFinal_ParralMiguel.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly ComandasContext _context;

        public UsuariosController(ComandasContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Index()
        {
              return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [Authorize (Roles = "SuperAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            string nuevaId = Guid.NewGuid().ToString();
            usuario.UsuarioId = nuevaId;

            if (ModelState.IsValid)
            {
                var usuarios = _context.Usuarios;
                await usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Usuarios");
            }
            return View("Index", "Usuarios");
        }

        // GET: Usuarios/Edit/5
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Edit(string? id, Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UsuarioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Usuarios");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteConfirmed(string? id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'ComandasContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Usuarios");
        }

        private bool UsuarioExists(string? id)
        {
          return _context.Usuarios.Any(e => e.UsuarioId == id);
        }
    }
}
