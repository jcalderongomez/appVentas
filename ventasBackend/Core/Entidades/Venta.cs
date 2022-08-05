using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entidades
{
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }
        public float Precio { get; set; }
        
        public DataType FechaCompra { get; set; }
        
        public int ClienteId { get; set; }
        
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        public int ProductoId { get; set; }
        
        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }    
    }
}