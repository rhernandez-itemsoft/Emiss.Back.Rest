using Back.Rest.Entities.Models;
using ItemsoftMX.Base.Domain.Utils;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Back.Rest.Data.Configuration
{
    public class UserConfiguration : BasicConfiguration
    {
        /// <summary>
        /// Fields Configuration and seed data for User Entity.
        /// </summary>
        /// <param name="entity">Entity to configurate</param>
        public UserConfiguration(EntityTypeBuilder<User> entity)
        {
            //entity.HasIndex(field => field.UserName).IsUnique();

            entity.Property(field => field.FirstName).IsRequired().HasMaxLength(150);
            entity.Property(field => field.LastName).IsRequired().HasMaxLength(150);
            entity.Property(field => field.MLastName).IsRequired().HasMaxLength(150);
          
        }
    }
}
