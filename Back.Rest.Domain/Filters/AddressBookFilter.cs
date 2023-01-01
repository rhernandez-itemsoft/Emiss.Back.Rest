using ItemsoftMX.Base.Domain.Filters;
using System.Linq.Dynamic.Core;

namespace Back.Rest.Domain.Filters
{
    /// <summary>
    /// AddressBook Filter: allows to parameterize the search for AddressBook endpoint
    /// </summary>
    public class AddressBookFilter : IFilter
    {
        public int? AddressBookId { get; set; }

        public int? UserId { get; set; }

        public int? CountryId { get; set; }

        public string? Alias { get; set; }


        /// <summary>
        /// Filters the Alias of specific logic.
        /// </summary>
        /// <returns>query with Alias filter.</returns>
        /// <param name="query">Query.</param>
        public IQueryable FilterByAlias(IQueryable query)
        {
            return query.Where("Alias.Contains(@0)", this.Alias);
        }
    }
}
