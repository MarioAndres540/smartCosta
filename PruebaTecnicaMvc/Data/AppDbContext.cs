using Microsoft.EntityFrameworkCore;
using PruebaTecnicaMvc.Models;

namespace PruebaTecnicaMvc.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
    }
}
