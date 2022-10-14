using System;
using System.Collections.Generic;
using System.Dynamic;
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
        public async Task<IActionResult> Details(string? id)
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
            return View();
        }

       /* // POST: Pedidos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, SuperAdmin, User")]
        public async Task<IActionResult> Create(Pedido pedido)
        {
            ViewData["PedidoUsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", pedido.PedidoUsuarioId);

            Plato platoAux;

            Agregar(platoAux);
            
            foreach (var item in _context.Platos)
            {
               pedido.PrecioTotal =+ item.PlatoPrecio * item.PlatoCantidad;
            }            
         
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Pedidos");
            }
            return View(pedido);
        }
       */
        // GET: Pedidos/Agregar
        public async Task <IActionResult> Agregar()
        {
            IEnumerable<Plato> ListaPlatos = await _context.Platos.ToListAsync();
            return View(ListaPlatos);
        }

        // POST: Pedidos/Agregar 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, SuperAdmin, User")]
        public async Task<IActionResult> Agregar(Plato plato)
        {
           // ViewData["PedidoUsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", pedido.PedidoUsuarioId);

           /* if (ModelState.IsValid)
            {
                _context.Platos.Update(plato);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Pedidos");
            }*/

            return View("Create", "Pedidos");
        }

        // GET: Pedidos/Edit/5
        [Authorize(Roles = "Admin, SuperAdmin, User")]
        public async Task<IActionResult> Edit(string? id)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, SuperAdmin, User")]
        public async Task<IActionResult> Edit(string id, Pedido pedido)
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
        public async Task<IActionResult> Delete(string? id)
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
        public async Task<IActionResult> DeleteConfirmed(string id)
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

        private bool PedidoExists(string id)
        {
          return _context.Pedidos.Any(e => e.PedidoId == id);
        }

    }
}
