
using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.Entities;

namespace Back.Rest.Entities.ViewModels
{
    /// <summary>
    /// Country entity
    /// </summary>
    public class CountryViewModel : EntityBase
    {
        public int CountryId { get; set; }
        public string Code { get; set; }  = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<StateViewModel>? States { get; set; }

        public virtual ICollection<CityViewModel>? Cities { get; set; }

        public virtual ICollection<AddressBookViewModel>? AddressBook { get; set; }
    }
}
