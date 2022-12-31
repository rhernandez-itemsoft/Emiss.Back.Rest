
using ItemsoftMX.Base.Domain.Entities;

namespace Back.Rest.Entities.Models
{
    /// <summary>
    /// Country entity
    /// </summary>
    public class Country : EntityBase
    {
        public int CountryId { get; set; }
        public string Code { get; set; }  = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<State>? States { get; set; }

        public virtual ICollection<City>? Cities { get; set; }

        public virtual ICollection<AddressBook>? AddressBook { get; set; }
    }
}
