using HRBackend.Domain.Entities;
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
                  .HasColumnType("datetime")
                  .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
