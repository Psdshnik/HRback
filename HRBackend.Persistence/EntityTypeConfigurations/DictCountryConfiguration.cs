using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HRBackend.Domain.Entities;


namespace HRBackend.Persistence.EntityTypeConfigurations
{
    public class DictCountryConfiguration : IEntityTypeConfiguration<DictCountry>
    {
        public void Configure(EntityTypeBuilder<DictCountry> builder)
        {
            builder.ToTable("dict_country");

            builder.HasKey(x => x.Id);

            builder.HasKey(c => c.Id)
                  .HasName("pk_country");
        }
    }
}
