using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property( u => u.UsuarioId).IsRequired();
            builder.Property( u => u.Nombre).IsRequired().HasMaxLength(50);
            builder.Property( u => u.Apellido).IsRequired().HasMaxLength(50);
            builder.Property( u => u.Email).IsRequired().HasMaxLength(150);
            builder.Property( u => u.Password).IsRequired().HasMaxLength(20);
            builder.Property( u => u.FechaCaptura).IsRequired().HasMaxLength(50);
        }
    }
}