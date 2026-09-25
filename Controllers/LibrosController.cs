using Biblioteca_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly BibliotecaContext _context;
        public LibrosController ( BibliotecaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Libro>>> GetAll()
        {
            var librosEncontrados = _context.libros.AsAsyncEnumerable();

            return Ok(librosEncontrados);
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
        public async Task<IActionResult> PostLibro([FromBody] Libro libro)
        {
            //libro.Id = BasesDeDatos.Libros.Any() ? BasesDeDatos.Libros.Max(x => x.Id) + 1 : 1;
            _context.libros.Add(libro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = libro.Id }, libro);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutLibro([FromRoute] int id, [FromBody]Libro libro)
        {
            var libroEncontrado = _context.libros.FirstOrDefault(x => x.Id == id);
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
                await _context.SaveChangesAsync();
                return Ok(libroEncontrado);
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLibro([FromRoute]int id)
        {
            var libroEncontrado = _context.libros.FirstOrDefault(x => x.Id == id);
            if(libroEncontrado == null)
            {
                return NotFound("El libro que intenta eliminar no existe.");
            }
            else
            {
                string nombreLibro = libroEncontrado.Titulo;
                _context.libros.Remove(libroEncontrado);
                await _context.SaveChangesAsync();
                return Ok($"El libro {nombreLibro} se ha eliminado.");
            }
        }
    }
}
