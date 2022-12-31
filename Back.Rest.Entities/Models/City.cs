using ItemsoftMX.Base.Domain.Entities;

namespace Back.Rest.Entities.Models
{
    /// <summary>
    /// City entity
    /// </summary>
    public class City : EntityBase
    {
        public int CityId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public int CountryId { get; set; }
        public virtual Country? Country { get; set; }

        public int StateId { get; set; }
        public virtual State? State { get; set; }

        public virtual ICollection<AddressBook>? AddressBook { get; set; }
    }
}
