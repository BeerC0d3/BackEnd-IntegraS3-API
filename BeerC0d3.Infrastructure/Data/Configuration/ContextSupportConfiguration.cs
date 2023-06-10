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
    internal class ContextSupportConfiguration : IEntityTypeConfiguration<ContextSupport>
    {
        public void Configure(EntityTypeBuilder<ContextSupport> builder)
        {
            builder.ToTable("ContextSupport", "chatGPT");
            builder.Property(c => c.Id)
               .ValueGeneratedOnAdd()
                   .IsRequired();
            
            builder.Property(c => c.parentId)
            .HasColumnType("int");

            builder.Property(c => c.name)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(100);
            builder.Property(c => c.logo)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(8000);
            builder.Property(c => c.file)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(8000);


        }
    }
}
