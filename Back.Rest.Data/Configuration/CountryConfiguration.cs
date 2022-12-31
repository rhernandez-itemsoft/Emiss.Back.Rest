using Back.Rest.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Rest.Data.Configuration
{
    public class CountryConfiguration : BasicConfiguration
    {
        /// <summary>
        /// Fields Configuration and seed data for  Country Entity.
        /// </summary>
        /// <param name="entity">Entity to configurate</param>
        public CountryConfiguration(EntityTypeBuilder<Country> entity)
        {
            entity.HasIndex(field => field.Code).IsUnique();
            entity.Property(field => field.Code).IsRequired().HasMaxLength(3);
            entity.Property(field => field.Abbreviation).IsRequired().HasMaxLength(5);
            entity.Property(field => field.Name).IsRequired().HasMaxLength(75);

            entity.Property(field => field.Enabled).IsRequired(false).HasDefaultValue(true);
            entity.Property(field => field.CreatedBy).IsRequired();
            entity.Property(field => field.CreatedAt).IsRequired();
            entity.Property(field => field.UpdatedBy).IsRequired(false);
            entity.Property(field => field.UpdatedAt).IsRequired(false);

            entity.HasData(
                new Country() { CountryId = 1, Code = "052", Abbreviation = "MX", Name = "México", Enabled = DefaultStatus, CreatedBy = DefaultUserId, CreatedAt = DefaultDate }
            );
        }
    }
}
