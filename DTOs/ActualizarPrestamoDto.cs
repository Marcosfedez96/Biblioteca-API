using Biblioteca_API.Models;

namespace Biblioteca_API.DTOs
{
    public class ActualizarPrestamoDto
    {
        public DateOnly FechaDePrestamo { set; get; }
        public DateOnly FechaDeDevolucion { set; get; }
        public List<int> IdLibroPrestado { set; get; }
        public int SocioId { set; get; }
    }
}
