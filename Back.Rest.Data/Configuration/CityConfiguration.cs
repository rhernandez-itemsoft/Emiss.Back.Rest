using Back.Rest.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Back.Rest.Data.Configuration
{
    public class CityConfiguration : BasicConfiguration
    {
        /// <summary>
        /// Fields Configuration and seed data for  City Entity.
        /// </summary>
        /// <param name="entity">Entity to configurate</param>
        public CityConfiguration(EntityTypeBuilder<City> entity)
        {
            entity.HasIndex(field => field.Code).IsUnique();
            entity.Property(field => field.StateId).IsRequired();
            entity.Property(field => field.CountryId).IsRequired();

            entity.Property(field => field.Code).IsRequired().HasMaxLength(3);
            entity.Property(field => field.Abbreviation).IsRequired().HasMaxLength(5);
            entity.Property(field => field.Name).IsRequired().HasMaxLength(75);

            entity.Property(field => field.Enabled).IsRequired(false).HasDefaultValue(true);
            entity.Property(field => field.CreatedBy).IsRequired();
            entity.Property(field => field.CreatedAt).IsRequired();
            entity.Property(field => field.UpdatedBy).IsRequired(false);
            entity.Property(field => field.UpdatedAt).IsRequired(false);


            entity
                .HasOne(e => e.State)
                 .WithMany(c => c.Cities)
                 .HasForeignKey(bc => bc.StateId)
                 .HasConstraintName("IXC_City_State")
                 .OnDelete(DeleteBehavior.NoAction)
                 .IsRequired();

            entity
                .HasOne(e => e.Country)
                 .WithMany(c => c.Cities)
                 .HasForeignKey(bc => bc.CountryId)
                 .HasConstraintName("IXC_City_Country")
                 .OnDelete(DeleteBehavior.NoAction)
                 .IsRequired();


            entity.HasData(
               new City() { CityId = 1, StateId = 1, CountryId = 1, Code = "052", Abbreviation = "Col.", Name = "Colima", Enabled = DefaultStatus, CreatedBy = DefaultUserId, CreatedAt = DefaultDate }
           );
        }
    }
}
