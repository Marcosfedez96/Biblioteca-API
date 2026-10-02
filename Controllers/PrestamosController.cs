using Biblioteca.DTOs;
using Biblioteca_API.DTOs;
using Biblioteca_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public PrestamosController (BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PrestamoDto>>> GetAll([FromQuery] DateOnly? fechaPrestamo, [FromQuery] bool? filtroDeudores)
        {
            IQueryable<Prestamo> resultadoBusqueda = _context.prestamos
                .Include(p => p.Libros)
                .Include(p => p.Socio);
            DateOnly hoy = DateOnly.FromDateTime(DateTime.Now);
            if (fechaPrestamo.HasValue)
            {
                resultadoBusqueda = resultadoBusqueda.Where(x => x.FechaDePrestamo == fechaPrestamo.Value);
            }
            if (filtroDeudores.HasValue && filtroDeudores == true)
            {
                resultadoBusqueda = resultadoBusqueda.Where(x => x.FechaDeDevolucion > hoy);
            }
            List<PrestamoDto> ListPrestamoDto = await resultadoBusqueda
                .Select(p => new PrestamoDto
                {
                    Id = p.Id,
                    FechaDePrestamo = p.FechaDePrestamo,
                    FechaDeDevolucion = p.FechaDeDevolucion,
                    Libros = p.Libros,
                    SocioId = p.SocioId,
                    SocioNombre = p.Socio.Nombre
                }).ToListAsync();
            return Ok(ListPrestamoDto);
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PrestamoDto>> GetById([FromRoute]int id)
        {
            var resultadoBusqueda = await _context.prestamos
                .Include(p => p.Libros)
                .Include(p => p.Socio)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (resultadoBusqueda == null)
            {
                return NotFound($"El prestamo con la id {id} no existe en el sistema");
            }

            PrestamoDto prestamoDto = new PrestamoDto
            {
                Id = resultadoBusqueda.Id,
                FechaDePrestamo = resultadoBusqueda.FechaDePrestamo,
                FechaDeDevolucion = resultadoBusqueda.FechaDeDevolucion,
                Libros = resultadoBusqueda.Libros,
                SocioId = resultadoBusqueda.SocioId,
                SocioNombre = resultadoBusqueda.Socio.Nombre
            };
            return Ok(prestamoDto);
            
        }
        [HttpPost]
        public async Task<IActionResult> PostPrestamo([FromBody]CrearPrestamoDto crearPrestamoDto)
        {
            var librosElegidos = await _context.libros
                .Where(x => crearPrestamoDto.IdLibroPrestado.Contains(x.Id))
                .ToListAsync();
            var socio = await _context.socios
                .FirstOrDefaultAsync(x => x.Id == crearPrestamoDto.IdDatosDeSocio);
            if(socio == null)
            {
                return BadRequest("el socio no existe.");
            }
            Prestamo prestamo = new Prestamo
            {
                FechaDePrestamo = crearPrestamoDto.FechaDePrestamo,
                FechaDeDevolucion = crearPrestamoDto.FechaDeDevolucion,
                Libros = librosElegidos,
                Socio = socio

            };
            _context.prestamos.Add(prestamo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = prestamo.Id},prestamo);
           
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPrestamos([FromRoute]int id, [FromBody] ActualizarPrestamoDto actualizarPrestamoDto)
        {
            var prestamo = await _context.prestamos
                .Include(l=>l.Libros)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (prestamo == null)
            {
                return NotFound("El prestamo que busca no existe.");
            }


            var librosElegidos = await _context.libros.Where(x => actualizarPrestamoDto.IdLibroPrestado.Contains(x.Id)).ToListAsync();


            prestamo.FechaDePrestamo = actualizarPrestamoDto.FechaDePrestamo;
            prestamo.FechaDeDevolucion = actualizarPrestamoDto.FechaDeDevolucion;
            prestamo.SocioId = actualizarPrestamoDto.SocioId;

            prestamo.Libros.Clear();
            foreach(var libro in librosElegidos)
            {
                prestamo.Libros.Add(libro);
            }
            await _context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePrestamo([FromRoute] int id)
        {
            var resultadoBusqueda = _context.prestamos.FirstOrDefault(x => x.Id == id);
            if(resultadoBusqueda == null)
            {
                return NotFound("El prestamo que intenta borrar no existe.");
            }
            else
            {
                _context.prestamos.Remove(resultadoBusqueda);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }

}
