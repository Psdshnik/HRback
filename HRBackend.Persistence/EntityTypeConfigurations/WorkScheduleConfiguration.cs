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
    public class WorkScheduleConfiguration : IEntityTypeConfiguration<WorkSchedule>
    {
        public void Configure(EntityTypeBuilder<WorkSchedule> builder)
        {
            builder.ToTable("work_shedule");

            builder.HasKey(t => t.Id)
                   .HasName("pk_work_shedule");

            builder.HasIndex(t => t.Id);

            builder.Property(t => t.Name)
                  .HasColumnName("name")
                  .HasColumnType("varchar(30)")
                  .HasMaxLength(30);
        }
    }
}
