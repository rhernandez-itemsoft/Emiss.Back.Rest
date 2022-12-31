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
    /// UserFilter: allows to parameterize the search for User endpoint
    /// </summary>
    public class UserFilter : IFilter
    {
        public uint? UserId { get; set; }

        public Nullable<uint> GroupId { get; set; }

        //public string FullName { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MLastName { get; set; }

        public string WorkEmail { get; set; }

        public Nullable<bool> Enabled { get; set; }

        /// <summary>
        /// Filters the UserName of specific logic.
        /// </summary>
        /// <returns>query with UserName filter.</returns>
        /// <param name="query">Query.</param>
        public IQueryable FilterByUserName(IQueryable query)
        {
            return query.Where("UserName.Contains(@0)", this.UserName);
        }


        /// <summary>
        /// Filters the FirstName of specific logic.
        /// </summary>
        /// <returns>query with FirstName filter.</returns>
        /// <param name="query">Query.</param>
        public IQueryable FilterByFirstName(IQueryable query)
        {
            return query.Where("UserDetail.FirstName.Contains(@0)", this.FirstName);
        }

        /// <summary>
        /// Filters the LastName of specific logic.
        /// </summary>
        /// <returns>query with LastName filter.</returns>
        /// <param name="query">Query.</param>
        public IQueryable FilterByLastName(IQueryable query)
        {
            return query.Where("UserDetail.LastName.Contains(@0)", this.LastName);
        }

        /// <summary>
        /// Filters the MLastName of specific logic.
        /// </summary>
        /// <returns>query with MLastName filter.</returns>
        /// <param name="query">Query.</param>
        public IQueryable FilterByMLastName(IQueryable query)
        {
            return query.Where("UserDetail.MLastName.Contains(@0)", this.MLastName);
        }

        ///// <summary>
        ///// Filters the FullName of specific logic.
        ///// </summary>
        ///// <returns>query with FullName filter.</returns>
        ///// <param name="query">Query.</param>
        //public IQueryable FilterByFullName(IQueryable query)
        //{
        //    return query.Where("FirstName.Contains(@0) || LastName.Contains(@0) || MlastName.Contains(@0) ", this.FullName);
        //}
    }
}