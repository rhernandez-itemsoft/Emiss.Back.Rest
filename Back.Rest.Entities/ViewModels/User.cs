using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.Entities;

namespace Back.Rest.Entities.ViewModels
{
    /// <summary>
    /// User entity: stores the user information
    /// </summary>
    public class UserViewModel : EntityBase
    {
        public int UserId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MLastName { get; set; } = string.Empty;

        public virtual ICollection<AddressBookViewModel>? AddressBook { get; set; }
    }
}
