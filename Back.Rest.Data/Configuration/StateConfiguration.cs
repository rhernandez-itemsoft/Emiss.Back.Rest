using Back.Rest.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Back.Rest.Data.Configuration
{
    public class StateConfiguration : BasicConfiguration
    {
        /// <summary>
        /// Fields Configuration and seed data for  State Entity.
        /// </summary>
        /// <param name="entity">Entity to configurate</param>
        public StateConfiguration(EntityTypeBuilder<State> entity)
        {
            entity.HasIndex(field => field.Code).IsUnique();
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
                .HasOne(e => e.Country)
                 .WithMany(c => c.States)
                 .HasForeignKey(bc => bc.CountryId)
                 .HasConstraintName("IXC_State_Country")
                 .OnDelete(DeleteBehavior.NoAction)
                 .IsRequired();

            entity.HasData(
                new State() { StateId = 1, CountryId = 1, Code = "052", Abbreviation = "Col.", Name = "Colima", Enabled = DefaultStatus, CreatedBy = DefaultUserId, CreatedAt = DefaultDate }
            );
        }
    }
}
