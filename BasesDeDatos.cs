using Biblioteca.Models;

namespace Biblioteca
{
    public static class BasesDeDatos
    {
        public static List<Libro> Libros = new List<Libro>
{
    new Libro{Id = 1, Titulo = "Habitos Atomicos", Genero = "Desarrollo personal",
             Autor = "James Clear", Stock = 2, Isbn = 9783442178582},
    new Libro{Id = 2, Titulo = "Cien Años de Soledad", Genero = "Realismo mágico",
             Autor = "Gabriel García Márquez", Stock = 3, Isbn = 9780307474728},
    new Libro{Id = 3, Titulo = "1984", Genero = "Ciencia ficción",
             Autor = "George Orwell", Stock = 4, Isbn = 9780451524935},
    new Libro{Id = 4, Titulo = "El Principito", Genero = "Fábula",
             Autor = "Antoine de Saint-Exupéry", Stock = 5, Isbn = 9780156012195},
    new Libro{Id = 5, Titulo = "Sapiens", Genero = "Divulgación histórica",
             Autor = "Yuval Noah Harari", Stock = 2, Isbn = 9780062316097},
    new Libro{Id = 6, Titulo = "El Nombre del Viento", Genero = "Fantasía",
             Autor = "Patrick Rothfuss", Stock = 3, Isbn = 9780756404741},
    new Libro{Id = 7, Titulo = "Clean Code", Genero = "Programación",
             Autor = "Robert C. Martin", Stock = 2, Isbn = 9780132350884},
    new Libro{Id = 8, Titulo = "Rayuela", Genero = "Novela experimental",
             Autor = "Julio Cortázar", Stock = 3, Isbn = 9788437604572},
};
        public static List<Socio> SociosAfiliados = new List<Socio>
        {
            new Socio{ id = 1, nombre = "gaston",telefono="1928376452",direccion="calle falsa 123"},
            new Socio{ id = 2, nombre = "marcos",telefono="+5491124048045",direccion="pozo de vargas 2258"},
            new Socio{ id = 3, nombre = "valeria",telefono="3544344343",direccion="avenida de los patos 43"},
        };

        
        public static List<Prestamo> PrestamosRealizados = new List<Prestamo>
       {
           new Prestamo{id= 1,
               fechaDePrestamo = new DateTime(2020,1,1),
               fechaDeDevolucion = new DateTime (2020,2,1),
               libroPrestado = Libros.FirstOrDefault(x => x.Id == 1),
               datosDeSocio = SociosAfiliados.FirstOrDefault(x=> x.id == 3)
           }


        };
    }
}
