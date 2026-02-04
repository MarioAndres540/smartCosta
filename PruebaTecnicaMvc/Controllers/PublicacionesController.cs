using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaMvc.Data;
using PruebaTecnicaMvc.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaMvc.Controllers
{
    public class PublicacionesController : Controller
    {
        private readonly AppDbContext _context;

        public PublicacionesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var publicaciones = _context.Publicaciones.Include(p => p.Usuario);
            return View(await publicaciones.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            if (HttpContext.Session.GetInt32("UsuarioId") == null)
            {
                return RedirectToAction("Identificar", "Acceso");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Publicacion publicacion)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
            {
                return RedirectToAction("Identificar", "Acceso");
            }

            if (ModelState.IsValid)
            {
                publicacion.UsuarioId = usuarioId.Value;
                publicacion.FechaPublicacion = DateTime.Now;
                _context.Add(publicacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publicacion);
        }
    }
}
