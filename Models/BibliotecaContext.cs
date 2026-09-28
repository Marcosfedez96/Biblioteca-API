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
        public DbSet<Socio> socios { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>().HasData(
                new Libro { Id = 1, Titulo = "Habitos Atomicos", Genero = "Desarrollo personal", Autor = "James Clear", Stock = 2, Isbn = 9783442178582 },
                new Libro { Id = 2, Titulo = "Cien Años de Soledad", Genero = "Realismo mágico", Autor = "Gabriel García Márquez", Stock = 3, Isbn = 9780307474728 },
                new Libro { Id = 3, Titulo = "1984", Genero = "Ciencia ficción", Autor = "George Orwell", Stock = 4, Isbn = 9780451524935 },
                new Libro { Id = 4, Titulo = "El Principito", Genero = "Fábula", Autor = "Antoine de Saint-Exupéry", Stock = 5, Isbn = 9780156012195 },
                new Libro { Id = 5, Titulo = "Sapiens", Genero = "Divulgación histórica", Autor = "Yuval Noah Harari", Stock = 2, Isbn = 9780062316097 }
            );

            modelBuilder.Entity<Socio>().HasData(
                new Socio { Id = 1, Nombre = "Gaston", Telefono = "1928376452", Direccion = "calle falsa 123" },
                new Socio { Id = 2, Nombre = "Marcos", Telefono = "+5491124048045", Direccion = "pozo de vargas 2258" },
                new Socio { Id = 3, Nombre = "Valeria", Telefono = "3544344343", Direccion = "avenida de los patos 43" }
            );
        }
    }
}
