using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Biblioteca_API.Models;
using Biblioteca.DTOs;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {


        [HttpGet]
        public ActionResult<List<Prestamo>> GetAll([FromQuery] DateOnly? fechaPrestamo, [FromQuery]bool? filtroDeudores)
        {
            var resultadoBusqueda = BasesDeDatos.PrestamosRealizados.AsEnumerable();
            DateOnly hoy = DateOnly.FromDateTime(DateTime.Now);
            if (fechaPrestamo.HasValue)
            {
                resultadoBusqueda = resultadoBusqueda.Where(x => x.FechaDePrestamo == fechaPrestamo);
            }
            if (filtroDeudores.HasValue && filtroDeudores == true)
            {
                resultadoBusqueda = resultadoBusqueda.Where(x => x.FechaDeDevolucion > hoy);
            }
            return Ok(resultadoBusqueda.ToList());
        }
        [HttpGet("{id:int}")]
        public ActionResult<Prestamo> GetById([FromRoute]int id)
        {
            var resultadoBusqueda = BasesDeDatos.PrestamosRealizados.FirstOrDefault(x => x.Id == id);
            if(resultadoBusqueda == null)
            {
                return NotFound($"El prestamo con la id {id} no existe en el sistema");
            }
            else
            {
                return Ok(resultadoBusqueda);
            }
        }
        [HttpPost]
        public IActionResult PostPrestamo([FromBody]PrestamoDTO prestamoDTO)
        {
            
            Libro libro = BasesDeDatos.Libros.FirstOrDefault(x => x.Id == prestamoDTO.IdLibroPrestado);
            if(libro == null)
            {
                return NotFound(new { message = "El libro especifico no existe." });
            }
            Socio socio = BasesDeDatos.SociosAfiliados.FirstOrDefault(x => x.Id == prestamoDTO.IdDatosDeSocio);
            if(socio == null)
            {
                return NotFound(new { message = "El socio especifico no existe." });
            }
            Prestamo prestamo = new Prestamo()
            {
                Id = BasesDeDatos.PrestamosRealizados.Any() ? BasesDeDatos.PrestamosRealizados.Max(x => x.Id) + 1 : 1,

                FechaDePrestamo = prestamoDTO.FechaDePrestamo,
                FechaDeDevolucion = prestamoDTO.FechaDeDevolucion,
                
                LibroPrestado = new Libro{
                    Id = prestamoDTO.IdLibroPrestado,
                    Titulo = libro.Titulo,
                    Autor = libro.Autor,
                    Genero = libro.Genero,
                    Stock = libro.Stock,
                    Isbn = libro.Isbn
                },
                DatosDeSocio = new Socio
                {
                    Id = prestamoDTO.IdDatosDeSocio,
                    Nombre = socio.Nombre,
                    Telefono = socio.Telefono,
                    Direccion = socio.Direccion
                }
            };
            

            BasesDeDatos.PrestamosRealizados.Add(prestamo);
            return Ok(prestamo);
        }
        [HttpPut("{id:int}")]
        public IActionResult PutPrestamos([FromRoute]int id, [FromBody]PrestamoDTO prestamoDTO)
        {
            var resultadoBusqueda = BasesDeDatos.PrestamosRealizados.FirstOrDefault(x => x.Id == id);
            if(resultadoBusqueda == null)
            {
                return NotFound("No se encuentra el prestamo buscado.");
            }

            Libro libro = BasesDeDatos.Libros.FirstOrDefault(x => x.Id == prestamoDTO.IdLibroPrestado);
            if(libro == null)
            {
                return NotFound("El libro no existe.");
            }
            Socio socio = BasesDeDatos.SociosAfiliados.FirstOrDefault(x => x.Id == prestamoDTO.IdDatosDeSocio);
            if(socio == null)
            {
                return NotFound("El socio no existe.");
            }
           
            resultadoBusqueda.FechaDePrestamo = prestamoDTO.FechaDePrestamo;
            resultadoBusqueda.FechaDeDevolucion = prestamoDTO.FechaDeDevolucion;

            resultadoBusqueda.LibroPrestado.Id = libro.Id;
            resultadoBusqueda.LibroPrestado.Autor = libro.Autor;
            resultadoBusqueda.LibroPrestado.Genero = libro.Genero;
            resultadoBusqueda.LibroPrestado.Isbn = libro.Isbn;
            resultadoBusqueda.LibroPrestado.Stock = libro.Stock;
            resultadoBusqueda.LibroPrestado.Titulo = libro.Titulo;

            resultadoBusqueda.DatosDeSocio.Id = socio.Id;
            resultadoBusqueda.DatosDeSocio.Nombre = socio.Nombre;
            resultadoBusqueda.DatosDeSocio.Telefono = socio.Telefono;
            resultadoBusqueda.DatosDeSocio.Direccion = socio.Direccion;

            return Ok(resultadoBusqueda);
        
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeletePrestamo([FromRoute] int id)
        {
            var resultadoBusqueda = BasesDeDatos.PrestamosRealizados.FirstOrDefault(x => x.Id == id);
            if(resultadoBusqueda == null)
            {
                return NotFound("El prestamo que intenta borrar no existe.");
            }
            else
            {
                BasesDeDatos.PrestamosRealizados.Remove(resultadoBusqueda);
                return NoContent();
            }
        }
    }

}
