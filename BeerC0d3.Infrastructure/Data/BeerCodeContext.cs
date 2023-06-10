using BeerC0d3.Core.Entities.chatGPT;
using BeerC0d3.Core.Entities.Seguridad;
using BeerC0d3.Core.Entities.Sistema;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Data
{
    public class BeerCodeContext:DbContext
    {
        public BeerCodeContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<CatalogoDetalle> CatalogoDetalles { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Persona> Personas { get; set; }

        public DbSet<ContextSupport> ContextoSoporte { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Seguridad");
            modelBuilder.HasDefaultSchema("Sistema");
            modelBuilder.HasDefaultSchema("chatGPT");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
