namespace Biblioteca.Models
{
    public class Prestamo
    {
        public int id { set; get; }
        public DateTime fechaDePrestamo { set; get; }
        public DateTime fechaDeDevolucion { set; get; }
        public Libro libroPrestado { set; get; }
        public Socio datosDeSocio { set; get; }
    }
}
