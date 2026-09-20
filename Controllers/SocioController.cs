using Biblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {
       

        [HttpGet]
        public ActionResult<Socio> GetItAll()
        {
            return Ok(_content.sociosAfiliados);
        }
    }
}
