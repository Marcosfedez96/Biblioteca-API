using Biblioteca_API.Models;

namespace Biblioteca.DTOs
{
    public class PrestamoDTO
    {
        public DateOnly FechaDePrestamo { set; get; }
        public DateOnly FechaDeDevolucion { set; get; }
        public int IdLibroPrestado { set; get; }
        public int IdDatosDeSocio { set; get; }
    }
}
