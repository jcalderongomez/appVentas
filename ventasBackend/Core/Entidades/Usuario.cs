using System.ComponentModel.DataAnnotations;

namespace Core.Entidades
{
    public class Usuario
    {
    [Key]
    public int UsuarioId { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Password  { get; set; }
    public string FechaCaptura { get; set; }
    }
}