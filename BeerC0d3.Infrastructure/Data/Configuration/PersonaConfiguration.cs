using BeerC0d3.Core.Entities.chatGPT;
using BeerC0d3.Core.Entities.Sistema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerC0d3.Infrastructure.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Persona", "ChatGPT");
            builder.Property(c => c.Id)
               .ValueGeneratedOnAdd()
                   .IsRequired();
            builder.Property(c => c.nombre)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
            builder.Property(c => c.apellidoPaterno)
                  .IsRequired()
                  .HasColumnType("varchar")
                  .HasMaxLength(100);
            builder.Property(c => c.apellidoMaterno)
                  .IsRequired()
                  .HasColumnType("varchar")
                  .HasMaxLength(100);
            builder.Property(c => c.edad)
                  .IsRequired()
                  .HasColumnType("int");
        }
    }
}
