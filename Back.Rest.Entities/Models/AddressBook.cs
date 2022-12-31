using ItemsoftMX.Base.Domain.Entities;

namespace Back.Rest.Entities.Models
{
    /// <summary>
    /// AddressBook entity
    /// </summary>
    public class AddressBook : EntityBase
    {
        public int AddressBookId { get; set; }

        public int UserId { get; set; }

        //address can only have assigned one user
        public virtual User? User { get; set; }
        public string Alias { get; set; } = string.Empty;


        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public int CountryId { get; set; }
        public virtual Country? Country { get; set; }

        public int StateId { get; set; }
        public virtual State? State { get; set; }

        public int CityId { get; set; }
        public virtual City? City { get; set; }

        public string Street { get; set; } = string.Empty;

        //colonia
        public string Subdivision { get; set; } = string.Empty;

        //address reference
        public string Reference { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}
