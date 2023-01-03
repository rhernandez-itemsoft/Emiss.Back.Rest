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

        //public Nullable<int> GroupId { get; set; }

        //public string FullName { get; set; }

        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? MLastName { get; set; } = string.Empty;


        public Nullable<bool> Enabled { get; set; }

        /// <summary>
        /// Filters the FirstName of specific logic.
        /// </summary>
        /// <returns>query with FirstName filter.</returns>
        /// <param name="query">Query.</param>
        public IQueryable FilterByFirstName(IQueryable query)
        {
            return query.Where("FirstName.Contains(@0)", this.FirstName);
        }


        /// <summary>
        /// Filters the LastName of specific logic.
        /// </summary>
        /// <returns>query with LastName filter.</returns>
        /// <param name="query">Query.</param>
        public IQueryable FilterByLastName(IQueryable query)
        {
            return query.Where("LastName.Contains(@0)", this.LastName);
        }


        /// <summary>
        /// Filters the MLastName of specific logic.
        /// </summary>
        /// <returns>query with MLastName filter.</returns>
        /// <param name="query">Query.</param>
        public IQueryable FilterByMLastName(IQueryable query)
        {
            return query.Where("MLastName.Contains(@0)", this.MLastName);
        }

    }
}