using ItemsoftMX.Base.Domain.Filters;
using System.Linq.Dynamic.Core;

namespace Back.Rest.Domain.Filters
{
    /// <summary>
    /// AddressBook Filter: allows to parameterize the search for AddressBook endpoint
    /// </summary>
    public class AddressBookFilter : IFilter
    {

        public string? Alias { get; set; } = string.Empty;

        public string? FullName { get; set; } = string.Empty;

        public string? Address { get; set; } = string.Empty;

        public string? Phone { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;


        /// <summary>
        /// Filters the Alias of specific logic.
        /// </summary>
        /// <returns>query with Alias filter.</returns>
        /// <param name="query">Query.</param>
        public IQueryable FilterByAlias(IQueryable query)
        {
            return query.Where("Alias.Contains(@0)", this.Alias);
        }

        /// <summary>
        /// Filters the FullName of specific logic.
        /// </summary>
        /// <returns>query with FullName filter.</returns>
        /// <param name="query">Query.</param>
        public IQueryable FilterByFullName(IQueryable query)
        {
            return query.Where("User.FirstName.Contains(@0) or User.LastName.Contains(@0) or User.MLastName.Contains(@0)", this.FullName);
        }

        /// <summary>
        /// Filters the Address of specific logic.
        /// </summary>
        /// <returns>query with Address filter.</returns>
        /// <param name="query">Query.</param>
        public IQueryable FilterByAddress(IQueryable query)
        {
            return query.Where("Street.Contains(@0) Or Subdivision.Contains(@0) Or Reference.Contains(@0) Or ZipCode.Contains(@0) Or Country.Name.Contains(@0) Or State.Name.Contains(@0) Or City.Name.Contains(@0)", this.Address);
        }

        /// <summary>
        /// Filters the Phone of specific logic.
        /// </summary>
        /// <returns>query with Phone filter.</returns>
        /// <param name="query">Query.</param>
        public IQueryable FilterByPhone(IQueryable query)
        {
            return query.Where("Phone.Contains(@0)", this.Phone);
        }


        /// <summary>
        /// Filters the Email of specific logic.
        /// </summary>
        /// <returns>query with Email filter.</returns>
        /// <param name="query">Query.</param>
        public IQueryable FilterByEmail(IQueryable query)
        {
            return query.Where("Email.Contains(@0)", this.Email);
        }

    }
}
