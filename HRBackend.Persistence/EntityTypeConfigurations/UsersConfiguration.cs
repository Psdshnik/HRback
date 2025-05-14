using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HRBackend.Domain.Entities;
using HRBackend.Domain.Enums;

namespace HRBackend.Persistence.EntityTypeConfigurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id)
                  .HasName("pk_users");

            builder.HasIndex(u => u.Id);

            builder.Property(u => u.Login)
                  .HasColumnName("login")
                  .HasColumnType("varchar(55)")
                  .HasMaxLength(55)
                  .IsRequired();

            builder.Property(u => u.Password)
                  .HasColumnName("password")
                  .HasColumnType("varchar(255)")
                  .HasMaxLength(255)
                  .IsRequired();

            // Конфигурация для enum
            builder.Property(u => u.Role)
                .HasColumnName("role")
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(u => u.NameWorkSchedule)
                .HasColumnName("work_schedule")
                .HasConversion<string>()
                .HasMaxLength(20);

            // Добавляем связи
            builder.HasOne(u => u.WorkingGroup)
                .WithMany()
                .HasForeignKey(u => u.WorkingGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.PersonalInfo)
                .WithMany()
                .HasForeignKey(u => u.PersonalInfoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}