using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        public List<Prestamo> prestamosRealizados = new List<Prestamo>
       {
           new Prestamo{id= 1,
               fechaDePrestamo = new DateTime(2020,1,1),
               fechaDeDevolucion = new DateTime (2020,2,1),
               libroPrestado = _content.libros.FirstOrDefault(x => x.id == 1),
               datosDeSocio = _content.sociosAfiliados.FirstOrDefault(x=> x.id == 3)
           }

            
        }; 

        [HttpGet]
        public ActionResult<List<Prestamo>> GetItAll()
        {
            return Ok(prestamosRealizados);
        }
    }

}
