using Core.Entidades;
using Infraestructura.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            //modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            //modelBuilder.ApplyConfiguration(new ImagenConfiguration());
            modelBuilder.ApplyConfiguration(new ProductoConfiguration());
            //modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            //modelBuilder.ApplyConfiguration(new VentaConfiguration());
       }

        public DbSet<Categoria> Categoria { get; set; }
        //public DbSet<Cliente> Cliente { get; set; }
        //public DbSet<Imagen> Imagen { get; set; }
        public DbSet<Producto> Producto { get; set; }
        //public DbSet<Usuario> Usuario { get; set; }
        //public DbSet<Venta> Venta { get; set; }

    }
}