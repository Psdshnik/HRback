using HRBackend.Domain.Entities;
using HRBackend.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRBackend.Persistence.EntityTypeConfigurations
{
    public class EmployeesConfiguration : IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.ToTable("employees");

            builder.HasKey(e => e.Id)
                  .HasName("PK_emploees");

            builder.HasIndex(e => e.Id);

            builder.Property(e => e.DateAdd)
                  .HasColumnName("date_add")
                  .HasColumnType("timestamp")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");

            // Добавляем конфигурацию для enum
            builder.Property(e => e.NameWorkSchedule)
                .HasColumnName("work_schedule")
                .HasConversion<string>()
                .HasMaxLength(20);

            // Добавляем связь с PersonalInfo
            builder.HasOne(e => e.PersonalInfo)
                .WithMany()
                .HasForeignKey(e => e.PersonalInfoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}