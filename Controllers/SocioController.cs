using Biblioteca_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {
        private readonly BibliotecaContext _context;
        public SocioController(BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Socio>>> GetAll([FromQuery]string? nombre)
        {
            var resultadoBusqueda = _context.socios.AsQueryable();
            if (!String.IsNullOrEmpty(nombre))
            {
                resultadoBusqueda = _context.socios.Where(x => x.Nombre.Contains(nombre,StringComparison.OrdinalIgnoreCase));
            }
            return Ok(resultadoBusqueda);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Socio>> GetById([FromRoute] int id)
        {
            var socioEncontrado = _context.socios.FirstOrDefault(x => x.Id == id);
            if (socioEncontrado == null)
            {
                return NotFound("El socio no esta registrado");
            }
            else
            {
                return Ok(socioEncontrado);
            }
        }
        [HttpPost]
        public async Task<ActionResult<Socio>> CreateSocio([FromBody] Socio socio)
        {
            //socio.Id = BasesDeDatos.SociosAfiliados.Any() ? BasesDeDatos.SociosAfiliados.Max(x => x.Id) + 1 : 1;
            _context.socios.Add(socio);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = socio.Id }, socio);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Socio>> EditSocio([FromRoute]int id, [FromBody]Socio socio)
        {
            var resultadoBusqueda = _context.socios.FirstOrDefault(x => x.Id == id);
            if(resultadoBusqueda == null)
            {
                return NotFound("El socio buscado no existe.");
            }
            else
            {
                resultadoBusqueda.Nombre = socio.Nombre;
                resultadoBusqueda.Telefono = socio.Telefono;
                resultadoBusqueda.Direccion = socio.Direccion;
                await _context.SaveChangesAsync();
                return Ok("El socio ha sido modificado.");
            }

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSocio([FromRoute]int id)
        {
            var resultadoBusqueda = _context.socios.FirstOrDefault(x => x.Id == id);
            if(resultadoBusqueda == null)
            {
                return NotFound("El socio no existe.");
            }
            else
            {
                _context.socios.Remove(resultadoBusqueda);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
}
