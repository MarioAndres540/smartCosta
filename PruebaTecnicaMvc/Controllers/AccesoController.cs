using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PruebaTecnicaMvc.Data;
using PruebaTecnicaMvc.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaMvc.Controllers
{
    public class AccesoController : Controller
    {
        private readonly AppDbContext _context;

        public AccesoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Identificar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Identificar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Buscar si el usuario ya existe por email
                var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
                
                if (usuarioExistente == null)
                {
                    _context.Usuarios.Add(usuario);
                    await _context.SaveChangesAsync();
                    usuarioExistente = usuario;
                }

                // Guardar en sesión
                HttpContext.Session.SetInt32("UsuarioId", usuarioExistente.Id);
                HttpContext.Session.SetString("UsuarioNombre", usuarioExistente.Nombre);
                HttpContext.Session.SetString("UsuarioEmail", usuarioExistente.Email);

                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Identificar");
        }
    }
}
