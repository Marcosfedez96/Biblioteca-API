namespace Biblioteca_API.Models
{
    public class Prestamo
    {
        public int Id { set; get; }
        public DateOnly FechaDePrestamo { set; get; }
        public DateOnly FechaDeDevolucion { set; get; }
        public List<Libro> Libros { set; get; }
        public int SocioId { set; get; }
        public Socio Socio { set; get; } = null!;
    }
}
