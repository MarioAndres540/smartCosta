using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaMvc.Data;
using PruebaTecnicaMvc.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaMvc.Controllers
{
    public class LibrosController : Controller
    {
        private readonly AppDbContext _context;

        public LibrosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Libros.ToList());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libro);
        }
    }
}
