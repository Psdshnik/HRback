using HRBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRBackend.Persistence.EntityTypeConfigurations
{
    public class CheckConfiguration : IEntityTypeConfiguration<Check>
    {
        public void Configure(EntityTypeBuilder<Check> builder)
        {
            builder.ToTable("check");

            builder.HasKey(c => c.Id)
                  .HasName("pk_check");

            builder.Property(c => c.DateCheck)
                  .HasColumnName("date_check")
                  .HasColumnType("timestamp")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP")
                  .IsRequired();

            builder.Property(c => c.Event)
                  .HasColumnName("event")
                  .HasColumnType("text")
                  .IsRequired();

            // Добавляем связи
            builder.HasOne(c => c.User)
                .WithMany(u => u.Checks)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}