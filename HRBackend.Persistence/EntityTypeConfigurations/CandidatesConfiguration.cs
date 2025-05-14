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

            builder.HasIndex(e => e.Id);

            // Добавляем конфигурацию для enum
            builder.Property(e => e.StatusCandidat)
                .HasColumnName("status")
                .HasConversion<string>()
                .HasMaxLength(20);
        }
    }
}