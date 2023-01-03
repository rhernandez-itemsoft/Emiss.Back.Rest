using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.Entities;

namespace Back.Rest.Entities.ViewModels
{
    /// <summary>
    /// State entity
    /// </summary>
    public class StateViewModel : EntityBase
    {
        public int StateId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public int CountryId { get; set; }

        public virtual CountryViewModel? Country { get; set; }

        public virtual ICollection<CityViewModel>? Cities { get; set; }

        public virtual ICollection<AddressBookViewModel>? AddressBook { get; set; }
    }
}
