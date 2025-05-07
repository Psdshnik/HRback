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
    public class DictStatusCandidataConfiguration : IEntityTypeConfiguration<DictStatusCandidata>
    {
        public void Configure(EntityTypeBuilder<DictStatusCandidata> builder)
        {
            builder.ToTable("dict_status_candidata");

            builder.HasKey(dc => dc.Id)
                  .HasName("pk_dict_status_candidata");

            builder.HasIndex(e => e.Id);

            builder.Property(dc => dc.Name)
                  .HasColumnName("name")
                  .HasColumnType("varchar(55)")
                  .HasMaxLength(55)
                  .IsRequired();
        }
    }
}
