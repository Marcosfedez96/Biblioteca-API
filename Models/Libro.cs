namespace Biblioteca_API.Models
{
    public class Libro
    {
        public int Id { set; get;}
        public required string Titulo { set; get; }
        public required string Genero { set; get; }
        public required string Autor { set; get; }
        public int Stock { set; get; }
        public long Isbn { set; get; }

    }
}
