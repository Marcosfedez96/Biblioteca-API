using Biblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
       

        [HttpGet]
        public ActionResult<List<Libro>> GetAll()
        {
            return Ok(_content.libros);
        }
    }
}
