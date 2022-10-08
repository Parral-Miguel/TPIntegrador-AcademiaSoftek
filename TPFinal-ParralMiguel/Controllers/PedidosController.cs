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
    public class PedidosController : Controller
    {
      
        private readonly ComandasContext _context;

        public PedidosController(ComandasContext context)
        {
            _context = context;
        }
        
        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var comandasContext = _context.Pedidos.Include(p => p.PedidoUsuario);
            return View(await comandasContext.ToListAsync());
        }

        // GET: Pedidos/Details/5
        [Authorize(Roles = "Admin, SuperAdmin, User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.PedidoUsuario)
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        [Authorize(Roles = "Admin, SuperAdmin, User")]
        public IActionResult Create()
        {
            ViewData["PedidoUsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, SuperAdmin, User")]
        public async Task<IActionResult> Create([Bind("PedidoId,PedidoUsuarioId,PedidoPreparado,PrecioTotal")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoUsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", pedido.PedidoUsuarioId);
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        [Authorize(Roles = "Admin, SuperAdmin, User")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["PedidoUsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", pedido.PedidoUsuarioId);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, SuperAdmin, User")]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId,PedidoUsuarioId,PedidoPreparado,PrecioTotal")] Pedido pedido)
        {
            if (id != pedido.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.PedidoId))
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
            ViewData["PedidoUsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", pedido.PedidoUsuarioId);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.PedidoUsuario)
                .FirstOrDefaultAsync(m => m.PedidoId == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedidos == null)
            {
                return Problem("Entity set 'ComandasContext.Pedidos'  is null.");
            }
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
          return _context.Pedidos.Any(e => e.PedidoId == id);
        }
    }
}
