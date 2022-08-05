using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Config
{
    public class ImagenConfiguration : IEntityTypeConfiguration<Imagen>
    {
        public void Configure(EntityTypeBuilder<Imagen> builder)
        {
            builder.Property( i => i.ImagenId).IsRequired();
            builder.Property( i => i.Nombre).IsRequired().HasMaxLength(30);
            builder.Property( i => i.Ruta).IsRequired().HasMaxLength(200);
            builder.Property( i => i.FechaSubida).IsRequired().HasMaxLength(30);
            builder.Property( i => i.Categoria).IsRequired().HasMaxLength(10);

            //TODO RELACIONES
            builder.HasOne(i => i.Categoria).WithMany()
                    .HasForeignKey(i => i.CategoriaId);
        }
    }
}