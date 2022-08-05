using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entidades
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
                
        public string Nombre { get; set; }
        
        public string Descripcion{ get; set; }

        public int Cantidad { get; set; }

        public float Precio { get; set; }

        public string FechaCaptura { get; set; }
        
        public int CategoriaId { get; set; }
        
        [ForeignKey("CategoriaId")]
        
        public Categoria Categoria { get; set; }
    }
}