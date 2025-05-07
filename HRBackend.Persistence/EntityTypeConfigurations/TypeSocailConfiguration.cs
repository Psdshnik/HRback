using HRBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBackend.Persistence.EntityTypeConfigurations
{
    public class TypeSocailConfiguration : IEntityTypeConfiguration<TypeSocail>
    {
        public void Configure(EntityTypeBuilder<TypeSocail> builder)
        {
            builder.ToTable("type_socail");

            builder.HasIndex(t => t.Id);

            builder.HasKey(t => t.Id)
                  .HasName("pk_type_socail");
        }
    }
}
