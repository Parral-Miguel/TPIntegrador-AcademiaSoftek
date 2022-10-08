using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TPFinal_ParralMiguel.Models;
using TPFinal_ParralMiguel.Context;

namespace TPFinal_ParralMiguel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ComandasContext _context;

        public HomeController(ILogger<HomeController> logger, ComandasContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var usuario = _context.Usuarios;
            
            return View(usuario);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}