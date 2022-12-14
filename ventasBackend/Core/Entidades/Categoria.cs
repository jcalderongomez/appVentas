using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entidades
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
                
        public string NombreCategoria { get; set; }
        
        public string FechaCaptura{ get; set; }  

        public int UsuarioId{ get; set; }
        
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }  
    }
}