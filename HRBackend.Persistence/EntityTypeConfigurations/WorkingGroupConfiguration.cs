using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HRBackend.Domain.Entities;


namespace HRBackend.Persistence.EntityTypeConfigurations
{
    public class WorkingGroupConfiguration : IEntityTypeConfiguration<WorkingGroup>
    {
        public void Configure(EntityTypeBuilder<WorkingGroup> builder)
        {
            builder.ToTable("working_groups");

            builder.HasKey(w => w.Id)
                  .HasName("pk_working_groups");

            builder.HasIndex(u => u.Id);

            builder.Property(w => w.Id)
                  .HasColumnName("id")
                  .HasColumnType("int");

            builder.Property(w => w.Name)
                  .HasColumnName("name")
                  .HasColumnType("varchar(30)")
                  .HasMaxLength(30)
                  .IsRequired();
        }
    }
}
