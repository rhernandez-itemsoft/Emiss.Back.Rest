using Back.Rest.Domain.IRepositories;
using Back.Rest.Entities.Models;
using ItemsoftMX.Base.Data.Repositories;

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
    }
}
