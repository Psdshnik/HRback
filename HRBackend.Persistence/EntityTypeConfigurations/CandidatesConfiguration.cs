using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HRBackend.Domain.Entities;
using HRBackend.Domain.Enums;

namespace HRBackend.Persistence.EntityTypeConfigurations
{
    public class CandidatesConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("candidates");

            builder.HasKey(e => e.Id)
                   .HasName("PK_candidates");

            // Настройка enum-свойств
            builder.Property(c => c.WorkSchedule)
                .HasConversion<string>() // Сохранять как строку в БД
                .IsRequired();

            builder.HasIndex(e => e.Id);

            // Связи
            builder.HasOne(c => c.User)
                .WithMany(c => c.Candidates)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Добавляем конфигурацию для enum
            builder.Property(e => e.Status)
                .HasColumnName("status")
                .HasConversion<string>()
                .HasMaxLength(20);
        }
    }
}