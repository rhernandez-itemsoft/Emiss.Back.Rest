using ItemsoftMX.Base.Domain.Entities;

namespace Back.Rest.Entities.Models
{
    /// <summary>
    /// User entity: stores the user information
    /// </summary>
    public class User : EntityBase
    {
        public int UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MLastName { get; set; } = string.Empty;

        public virtual ICollection<AddressBook>? AddressBook { get; set; }
    }
}
