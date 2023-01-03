using ItemsoftMX.Base.Domain.Entities;

namespace Back.Rest.Entities.ViewModels
{
    /// <summary>
    /// City entity
    /// </summary>
    public class CityViewModel : EntityBase
    {
        public int CityId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public int CountryId { get; set; }
        public virtual CountryViewModel? Country { get; set; }

        public int StateId { get; set; }
        public virtual StateViewModel? State { get; set; }

        public virtual ICollection<AddressBookViewModel>? AddressBook { get; set; }
    }
}
