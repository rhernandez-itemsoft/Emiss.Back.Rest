using ItemsoftMX.Base.Domain.Filters;
using System.Linq.Dynamic.Core;

namespace Back.Rest.Domain.Filters
{
    /// <summary>
    /// UserFilter: allows to parameterize the search for User endpoint
    /// </summary>
    public class UserFilter : IFilter
    {
        public int? UserId { get; set; }

        public string? FullName { get; set; } = string.Empty;

        public Nullable<bool> Enabled { get; set; }

        /// <summary>
        /// Filters the FullName of specific logic.
        /// </summary>
        /// <returns>query with FullName filter.</returns>
        /// <param name="query">Query.</param>
        public IQueryable FilterByFullName(IQueryable query)
        {
            return query.Where("FirstName.Contains(@0) or LastName.Contains(@0) or MLastName.Contains(@0)", this.FullName);
        }
    }
}