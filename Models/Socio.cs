using System.ComponentModel.DataAnnotations;
namespace Biblioteca.Models
{
    public class Socio
    {
        public int Id { set; get; }
        //[Required(ErrorMessage = "Es necesario la carga del nombre.")]
        //[StringLength(40,MinimumLength = 2,ErrorMessage = "el nombre debe tener entre 2 y 40 caracteres")]
        public string Nombre { set; get; }
        public string Telefono { set; get; }
        public string Direccion { set; get; }

    }
}
