using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
       

        [HttpGet]
        public ActionResult<List<Prestamo>> GetItAll()
        {
            return Ok(BasesDeDatos.PrestamosRealizados);
        }
    }

}
