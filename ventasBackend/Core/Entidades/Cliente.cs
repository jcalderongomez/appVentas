using System.ComponentModel.DataAnnotations;

namespace Core.Entidades
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono  { get; set; }
        public string Rfc { get; set; }
    }
}