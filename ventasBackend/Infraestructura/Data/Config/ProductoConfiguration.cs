using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Config
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property( p => p.ProductoId).IsRequired();
            builder.Property( p => p.Nombre).IsRequired().HasMaxLength(100);
            builder.Property( p => p.Descripcion).IsRequired().HasMaxLength(300);
            builder.Property( p => p.Cantidad).IsRequired().HasMaxLength(10);
            builder.Property( p => p.Precio).IsRequired().HasMaxLength(10);
            builder.Property( p => p.FechaCaptura).IsRequired().HasMaxLength(30);
            builder.Property( p => p.CategoriaId).IsRequired().HasMaxLength(30);
            //builder.Property( p => p.ImagenId).IsRequired().HasMaxLength(300);
            
            //TODO RELACIONES
            builder.HasOne(p => p.Categoria).WithMany()
                   .HasForeignKey(p => p.CategoriaId);
        }
    }
}