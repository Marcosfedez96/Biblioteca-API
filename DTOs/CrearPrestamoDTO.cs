using Biblioteca_API.Models;

namespace Biblioteca.DTOs
{
    public class CrearPrestamoDto
    {
        public DateOnly FechaDePrestamo { set; get; }
        public DateOnly FechaDeDevolucion { set; get; }
        public List<int> IdLibroPrestado { set; get; }
        public int IdDatosDeSocio { set; get; }
    }
}
