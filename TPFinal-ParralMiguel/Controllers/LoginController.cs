using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TPFinal_ParralMiguel.Models;
using TPFinal_ParralMiguel.Context;

namespace TPFinal_ParralMiguel.Controllers
{
    //Controladores para el login
    
    public class LoginController : Controller
    {
        private ComandasContext _context;
        public LoginController(ComandasContext context)
        {
            _context = context;
        }

        //Metodo Get
        public IActionResult Index()
        {
            return View();
        }

        //Metodo Post
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Usuario _user)
        {
            //Valido los datos con la informacion de la BBDD

            var usuarioValido = ValidarUsuario(_user.UsuarioNombre, _user.Contrasenia);

            if (usuarioValido != null)
            {
                //Claims
                var claims = new List<Claim>
                {

                    new Claim(ClaimTypes.Name, usuarioValido.UsuarioNombre),
                    new Claim("Correo", usuarioValido.UsuarioMail),
                    new Claim("id", usuarioValido.UsuarioId.ToString())


            };
                
                claims.Add(new Claim(ClaimTypes.Role, usuarioValido.UsuarioRol));

                //metemos toda la info en una variable
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                //Metodo primero, controlador despues
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }

        public IActionResult Registrar()
        {
            return View();
        }

        /// <summary>
        /// Metodo Post de Registro de Usuario. Un usuario registrado desde este metodo solo sera User
        /// </summary>
        /// <param name="usuario1"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Registrar(Usuario usuario)
        {
            string nuevaId = Guid.NewGuid().ToString();
            usuario.UsuarioId = nuevaId;
            usuario.UsuarioRol = "User";

            if (ModelState.IsValid)
            {
                var usuarios = _context.Usuarios;
                await usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Login");
            }
            return View("Index", "Login");
        }

        /// <summary>
        /// Metodo de validacion del usuario ingresado por el usuario. 
        /// Compara los datos obtenidos con los presentes en BBDD
        /// </summary>
        /// <param name="usuarioNombre"></param>
        /// <param name="usuarioContrasenia"></param>
        /// <returns></returns>
        private Usuario ValidarUsuario(string usuarioNombre, string usuarioContrasenia)
        {

            return _context.Usuarios.Where(item => item.UsuarioNombre == usuarioNombre && item.Contrasenia == usuarioContrasenia).FirstOrDefault();
        }

        //Salir del home de vuelta a la vista login
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

    }
}