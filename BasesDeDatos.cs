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
            new Socio{ Id = 1, Nombre = "Gaston", Telefono = "1928376452", Direccion = "calle falsa 123"},
            new Socio{ Id = 2, Nombre = "Marcos", Telefono = "+5491124048045", Direccion = "pozo de vargas 2258"},
            new Socio{ Id = 3, Nombre = "Valeria", Telefono = "3544344343", Direccion = "avenida de los patos 43"},
            new Socio{ Id = 4, Nombre = "Federico", Telefono = "3511234567", Direccion = "san martin 890"},
            new Socio{ Id = 5, Nombre = "Camila", Telefono = "3512345678", Direccion = "belgrano 456"},
            new Socio{ Id = 6, Nombre = "Lucas", Telefono = "3513456789", Direccion = "rivadavia 1023"},
            new Socio{ Id = 7, Nombre = "Sofia", Telefono = "3514567890", Direccion = "mitre 2211"},
            new Socio{ Id = 8, Nombre = "Nicolas", Telefono = "3515678901", Direccion = "sarmiento 678"},
        };


        public static List<Prestamo> PrestamosRealizados = new List<Prestamo>
        {
            new Prestamo{
                Id = 1,
                FechaDePrestamo = new DateOnly(2020,1,1),
                FechaDeDevolucion = new DateOnly(2020,2,1),
                LibroPrestado = Libros.FirstOrDefault(x => x.Id == 1),
                DatosDeSocio = SociosAfiliados.FirstOrDefault(x => x.Id == 3)
            },
            new Prestamo{
                Id = 2,
                FechaDePrestamo = new DateOnly(2021,3,10),
                FechaDeDevolucion = new DateOnly(2027,4,10),
                LibroPrestado = Libros.FirstOrDefault(x => x.Id == 3),
                DatosDeSocio = SociosAfiliados.FirstOrDefault(x => x.Id == 1)
            },
            new Prestamo{
                Id = 3,
                FechaDePrestamo = new (2022,6,5),
                FechaDeDevolucion = new DateOnly(2022,6,20),
                LibroPrestado = Libros.FirstOrDefault(x => x.Id == 7),
                DatosDeSocio = SociosAfiliados.FirstOrDefault(x => x.Id == 5)
            },
            new Prestamo{
                Id = 4,
                FechaDePrestamo = new DateOnly(2023,8,1),
                FechaDeDevolucion = new DateOnly(2028,8,15),
                LibroPrestado = Libros.FirstOrDefault(x => x.Id == 2),
                DatosDeSocio = SociosAfiliados.FirstOrDefault(x => x.Id == 6)
            },
            new Prestamo{
                Id = 5,
                FechaDePrestamo = new DateOnly(2024,1,20),
                FechaDeDevolucion = new DateOnly(2024,2,5),
                LibroPrestado = Libros.FirstOrDefault(x => x.Id == 5),
                DatosDeSocio = SociosAfiliados.FirstOrDefault(x => x.Id == 8)
            },
        };
    }
}
