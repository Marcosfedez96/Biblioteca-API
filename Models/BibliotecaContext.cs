using Microsoft.EntityFrameworkCore;
namespace Biblioteca_API.Models
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options)
        {

        }
        public DbSet<Libro> libros { set; get; } 

        public DbSet<Prestamo> prestamos { set; get; }
    }
}
