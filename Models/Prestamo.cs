namespace Biblioteca.Models
{
    public class Prestamo
    {
        public int Id { set; get; }
        public DateTime FechaDePrestamo { set; get; }
        public DateTime FechaDeDevolucion { set; get; }
        public Libro LibroPrestado { set; get; }
        public Socio DatosDeSocio { set; get; }
    }
}
