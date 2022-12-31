using Back.Rest.Domain.IRepositories;
using Back.Rest.Entities.Models;
using ItemsoftMX.Base.Data.Repositories;

namespace Back.Rest.Data.Repositories
{
    /// <summary>
    /// Repository interface implementation for Country
    /// </summary>
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        private readonly MsSqlContext _context;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="context">database context</param>
        public CountryRepository(MsSqlContext context) : base(context)
        {
            _context = context;
        }

    }
}
