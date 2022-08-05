using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entidades
{
    public class Imagen
    {
        [Key]
        public int ImagenId { get; set; }
                
        public string Nombre { get; set; }
        
        public string Ruta{ get; set; }

        public DataType FechaSubida { get; set; }

        public int CategoriaId{ get; set; }
        [ForeignKey("CategoriaId")]
        
        public Categoria Categoria { get; set; }
    }
}