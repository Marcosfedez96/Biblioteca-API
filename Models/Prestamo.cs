namespace Biblioteca.Models
{
    public class Prestamo
    {
        public int Id { set; get; }
        public DateOnly FechaDePrestamo { set; get; }
        public DateOnly FechaDeDevolucion { set; get; }
        public Libro LibroPrestado { set; get; }
        public Socio DatosDeSocio { set; get; }
    }
}
