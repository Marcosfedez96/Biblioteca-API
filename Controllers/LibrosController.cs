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
            return Ok(BasesDeDatos.Libros);
        }
        [HttpGet("{id:int}")]
        public ActionResult<Libro> GetById([FromRoute]int id)
        {
            var libroEncontrado = BasesDeDatos.Libros.FirstOrDefault(x => x.Id == id);
            if(libroEncontrado == null)
            {
                return NotFound("el libro no se encontro.");
            } else
            {
                return Ok(libroEncontrado);
            }
            
        }
        [HttpPost]
        public ActionResult<Libro> PostLibro([FromBody] Libro libro)
        {
            libro.Id = BasesDeDatos.Libros.Any() ? BasesDeDatos.Libros.Max(x => x.Id) + 1 : 1;
            BasesDeDatos.Libros.Add(libro);
            return CreatedAtAction(nameof(GetById), new { id = libro.Id }, libro);
        }
        [HttpPut("{id:int}")]
        public IActionResult PutLibro([FromRoute] int id, [FromBody]Libro libro)
        {
            var libroEncontrado = BasesDeDatos.Libros.FirstOrDefault(x => x.Id == id);
            if(libroEncontrado == null)
            {
                return NotFound("el Libro no existe");
            } else
            {
                libroEncontrado.Titulo = libro.Titulo;
                libroEncontrado.Genero = libro.Genero;
                libroEncontrado.Autor = libro.Autor;
                libroEncontrado.Stock = libro.Stock;
                libroEncontrado.Isbn = libro.Isbn;
                return Ok(libroEncontrado);
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteLibro([FromRoute]int id)
        {
            var libroEncontrado = BasesDeDatos.Libros.FirstOrDefault(x => x.Id == id);
            if(libroEncontrado == null)
            {
                return NotFound("El libro que intenta eliminar no existe.");
            }
            else
            {
                string nombreLibro = libroEncontrado.Titulo;
                BasesDeDatos.Libros.Remove(libroEncontrado);
                return Ok($"El libro {nombreLibro} se ha eliminado.");
            }
        }
    }
}
