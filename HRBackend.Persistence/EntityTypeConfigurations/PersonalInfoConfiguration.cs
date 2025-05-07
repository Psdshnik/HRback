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
    public class PersonalInfoConfiguration : IEntityTypeConfiguration<PersonalInfo>
    {
        public void Configure(EntityTypeBuilder<PersonalInfo> builder)
        {
            builder.ToTable("personal_info");

            builder.HasIndex(p => p.Id);

            builder.HasKey(p => p.Id)
                  .HasName("pk_personal_info");

            builder.Property(p => p.Name)
                  .HasColumnName("name")
                  .HasColumnType("varchar(55)")
                  .HasMaxLength(55)
                  .IsRequired();

            builder.Property(p => p.Surname)
                  .HasColumnName("surname")
                  .HasColumnType("varchar(55)")
                  .HasMaxLength(55)
                  .IsRequired();

            builder.Property(p => p.Middlename)
                  .HasColumnName("middlename")
                  .HasColumnType("varchar(55)")
                  .HasMaxLength(55)
                  .IsRequired();

            builder.Property(p => p.Email)
                  .HasColumnName("email")
                  .HasColumnType("varchar(55)")
                  .HasMaxLength(55)
                  .IsRequired();

            builder.Property(p => p.Phone)
                  .HasColumnName("phone")
                  .HasColumnType("varchar(55)")
                  .HasMaxLength(55)
                  .IsRequired();

            builder.Property(p => p.NameSocail)
                  .HasColumnName("name_socail")
                  .HasColumnType("varchar(55)")
                  .HasMaxLength(55)
                  .IsRequired();

            builder.Property(p => p.DateAdd)
                  .HasColumnName("date_add")
                  .HasColumnType("datetime")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");
                  
        }
    }
}
