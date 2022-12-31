using Back.Rest.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Rest.Data.Configuration
{
    public class AddressBookConfiguration : BasicConfiguration
    {
        /// <summary>
        /// Fields Configuration and seed data for  AddressBook Entity.
        /// </summary>
        /// <param name="entity">Entity to configurate</param>
        public AddressBookConfiguration(EntityTypeBuilder<AddressBook> entity)
        {
            entity.HasIndex(field => field.Alias).IsUnique();
            entity.Property(field => field.Alias).IsRequired().HasMaxLength(50);

            entity.Property(field => field.Phone).IsRequired().HasMaxLength(10);
            entity.Property(field => field.Email).IsRequired().HasMaxLength(150);

            entity.Property(field => field.CountryId).IsRequired();
            entity.Property(field => field.StateId).IsRequired();
            entity.Property(field => field.CityId).IsRequired();

            entity.Property(field => field.Street).IsRequired().HasMaxLength(250);
            entity.Property(field => field.Subdivision).IsRequired().HasMaxLength(250);
            entity.Property(field => field.Reference).IsRequired(false).HasMaxLength(250);
            entity.Property(field => field.ZipCode).IsRequired().HasMaxLength(15);



            entity.Property(field => field.Enabled).IsRequired(false).HasDefaultValue(true);
            entity.Property(field => field.CreatedBy).IsRequired();
            entity.Property(field => field.CreatedAt).IsRequired();
            entity.Property(field => field.UpdatedBy).IsRequired(false);
            entity.Property(field => field.UpdatedAt).IsRequired(false);

            entity
            .HasOne(e => e.User)
            .WithMany(c => c.AddressBook)
            .HasForeignKey(bc => bc.UserId)
            .HasConstraintName("IXC_AddressBook_User")
            .IsRequired();
        }
    }
}
