using ItemsoftMX.Base.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Back.Rest.Domain.Filters
{
    /// <summary>
    /// Country Filter: allows to parameterize the search for Country endpoint
    /// </summary>
    public class CountryFilter : IFilter
    {
        public int? CountryId { get; set; }

        public string? Code { get; set; }

        public string? Abbreviation { get; set; }

        public string? Name { get; set; }

        /// <summary>
        /// Filters the Name of specific logic.
        /// </summary>
        /// <returns>query with Name filter.</returns>
        /// <param name="query">Query.</param>
        public IQueryable FilterByName(IQueryable query)
        {
            return query.Where("Name.Contains(@0)", this.Name);
        }

    }
}
