using Biblioteca.Models;

namespace Biblioteca
{
    public static class _content
    {
        public static List<Socio> sociosAfiliados = new List<Socio>
        {
            new Socio{ id = 1, nombre = "gaston",telefono="1928376452",direccion="calle falsa 123"},
            new Socio{ id = 2, nombre = "marcos",telefono="+5491124048045",direccion="pozo de vargas 2258"},
            new Socio{ id = 3, nombre = "valeria",telefono="3544344343",direccion="avenida de los patos 43"},
        };

        public static List<Libro> libros = new List<Libro>
       {
           new Libro{id = 1,titulo = "Habitos Atomicos", genero = "Desarrollo personal",autor = "James Clear", stock = 2,ISBN = 9783442178582},
           new Libro{id = 2,titulo = "", genero = "",autor = "", stock = 2,ISBN = 9783442178582 },
           new Libro{id = 3,titulo = "", genero = "",autor = "", stock = 2,ISBN = 9783442178582 },

       };

    }
}
