using ItemsoftMX.Base.Domain.Entities;

namespace Back.Rest.Entities.Models
{
    /// <summary>
    /// State entity
    /// </summary>
    public class State : EntityBase
    {
        public int StateId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public int CountryId { get; set; }

        public virtual Country? Country { get; set; }

        public virtual ICollection<City>? Cities { get; set; }

        public virtual ICollection<AddressBook>? AddressBook { get; set; }
    }
}
