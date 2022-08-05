using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infraestructura.Data.Config
{
    public class VentaConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.Property( v => v.VentaId).IsRequired();
            builder.Property( v => v.Precio).IsRequired().HasMaxLength(100);
            builder.Property( v => v.FechaCompra).IsRequired().HasMaxLength(300);
            builder.Property( v => v.Cliente).IsRequired().HasMaxLength(50);
            builder.Property( v => v.Producto).IsRequired().HasMaxLength(30);
            
            //TODO RELACIONES
            builder.HasOne(v => v.Cliente).WithMany()
                   .HasForeignKey(v => v.ClienteId);
            builder.HasOne(v => v.Producto).WithMany()
                   .HasForeignKey(v => v.ProductoId);
        }
    }
}