using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HRBackend.Domain.Entities;

namespace HRBackend.Persistence.EntityTypeConfigurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id) 
                  .HasName("pk_users");

            builder.HasIndex(u => u.Id);

            builder.Property(u => u.Id)
                  .HasColumnName("id")
                  .HasColumnType("int")
                  .IsRequired();

            builder.Property(u => u.Name)
                  .HasColumnName("name")
                  .HasColumnType("varchar(55)")
                  .HasMaxLength(55)
                  .IsRequired();

            builder.Property(u => u.Surname)
                  .HasColumnName("surname")
                  .HasColumnType("varchar(55)")
                  .HasMaxLength(55)
                  .IsRequired();

            builder.Property(u => u.Middlename)
                  .HasColumnName("middlename")
                  .HasColumnType("varchar(55)")
                  .HasMaxLength(55)
                  .IsRequired();

            builder.Property(u => u.Login)
                  .HasColumnName("login")
                  .HasColumnType("varchar(55)")
                  .HasMaxLength(55)
                  .IsRequired();

            builder.Property(u => u.Password)
                  .HasColumnName("password")
                  .HasColumnType("varchar(55)")
                  .HasMaxLength(55)
                  .IsRequired();
        }
    }
}
