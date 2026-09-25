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
        public ActionResult<List<Socio>> GetAll([FromQuery]string? nombre)
        {
            var resultadoBusqueda = BasesDeDatos.SociosAfiliados.AsEnumerable();
            if (!String.IsNullOrEmpty(nombre))
            {
                resultadoBusqueda = BasesDeDatos.SociosAfiliados.Where(x => x.Nombre.Contains(nombre,StringComparison.OrdinalIgnoreCase));
            }
            return Ok(resultadoBusqueda.ToList());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Socio> GetById([FromRoute] int id)
        {
            var socioEncontrado = BasesDeDatos.SociosAfiliados.FirstOrDefault(x => x.Id == id);
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
        public ActionResult<Socio> CreateSocio([FromBody] Socio socio)
        {
            socio.Id = BasesDeDatos.SociosAfiliados.Any() ? BasesDeDatos.SociosAfiliados.Max(x => x.Id) + 1 : 1;
            BasesDeDatos.SociosAfiliados.Add(socio);
            return CreatedAtAction(nameof(GetById), new { id = socio.Id }, socio);
        }
        [HttpPut("{id:int}")]
        public ActionResult<Socio> EditSocio([FromRoute]int id, [FromBody]Socio socio)
        {
            var resultadoBusqueda = BasesDeDatos.SociosAfiliados.FirstOrDefault(x => x.Id == id);
            if(resultadoBusqueda == null)
            {
                return NotFound("El socio buscado no existe.");
            }
            else
            {
                resultadoBusqueda.Nombre = socio.Nombre;
                resultadoBusqueda.Telefono = socio.Telefono;
                resultadoBusqueda.Direccion = socio.Direccion;
                return Ok("El socio ha sido modificado.");
            }

        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteSocio([FromRoute]int id)
        {
            var resultadoBusqueda = BasesDeDatos.SociosAfiliados.FirstOrDefault(x => x.Id == id);
            if(resultadoBusqueda == null)
            {
                return NotFound("El socio no existe.");
            }
            else
            {
                BasesDeDatos.SociosAfiliados.Remove(resultadoBusqueda);
                return Ok("El socio fue eliminado del sistema.");
            }
        }
    }
}
