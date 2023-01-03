using Back.Rest.Domain.IRepositories;
using Back.Rest.Entities.Models;
using ItemsoftMX.Base.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Back.Rest.Data.Repositories
{
    /// <summary>
    /// Repository interface implementation for AddressBook
    /// </summary>
    public class AddressBookRepository : BaseRepository<AddressBook>, IAddressBookRepository
    {
        private readonly MsSqlContext _context;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="context">database context</param>
        public AddressBookRepository(MsSqlContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Get User where filter matched
        /// </summary>
        /// <param name="id">User Identifier</param>
        /// <param name="ct">Cancellation Token</param>
        /// <returns>Item requested</returns>
        //public async Task<User> GetByIdCustomAsync(int id, CancellationToken ct = default(CancellationToken))
        public async Task<IQueryable<AddressBook>> GetAllAsync(CancellationToken ct)
        {
            var t = await Task.Run(() =>
            {
                var q = (from b in _context.Set<AddressBook>() select b);
                if (this.HasSoftDelete())
                {
                    q = q.Where("Enabled=false");
                }
                return q.AsQueryable().Include("User");
            });
            return t;
        }

        /// <summary>
        /// Validate if entity implements ISoftDelete contract
        /// </summary>
        /// <returns><c>true</c>, if soft delete contract implements, <c>false</c> otherwise.</returns>
        private bool HasSoftDelete()
        {
            var interfaces = typeof(User).GetInterfaces();
            return interfaces.Any(x => x.Name.Contains("ISoftDelete"));
        }

    }

   
}
