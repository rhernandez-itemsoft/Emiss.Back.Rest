using ItemsoftMX.Base.Domain.Entities;

namespace Back.Rest.Entities.ViewModels
{
    /// <summary>
    /// AddressBook entity
    /// </summary>
    public class AddressBookViewModel : EntityBase
    {
        public int AddressBookId { get; set; }

        public int UserId { get; set; }

        //address can only have assigned one user
        public virtual UserViewModel? User { get; set; }

        public string Alias { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public int CountryId { get; set; }
        public virtual CountryViewModel? Country { get; set; }

        public int StateId { get; set; }
        public virtual StateViewModel? State { get; set; }

        public int CityId { get; set; }
        public virtual CityViewModel? City { get; set; }

        public string Street { get; set; } = string.Empty;

        //colonia
        public string Subdivision { get; set; } = string.Empty;

        //address reference
        public string Reference { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}
