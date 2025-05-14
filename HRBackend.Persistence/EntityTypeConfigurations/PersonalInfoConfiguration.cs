using HRBackend.Domain.Entities;
using HRBackend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRBackend.Persistence.EntityTypeConfigurations
{
    public class PersonalInfoConfiguration : IEntityTypeConfiguration<PersonalInfo>
    {
        public void Configure(EntityTypeBuilder<PersonalInfo> builder)
        {
            builder.ToTable("personal_info");

            builder.HasKey(p => p.Id)
                  .HasName("pk_personal_info");

            builder.HasIndex(p => p.Id);

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

            // Конфигурация для enum
            builder.Property(p => p.NameSocail)
                .HasColumnName("name_socail")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.DateAdd)
                  .HasColumnName("date_add")
                  .HasColumnType("timestamp")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Добавляем связь с Country
            builder.HasOne(p => p.Country)
                .WithMany()
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}