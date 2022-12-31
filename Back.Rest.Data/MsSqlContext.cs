using Back.Rest.Data.Configuration;
using Back.Rest.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Back.Rest.Data
{

	/// <summary>
	/// https://www.learnentityframeworkcore.com/configuration/one-to-many-relationship-configuration
	/// </summary>
	public class MsSqlContext : DbContext
	{
		private readonly string? _dbName;

		#region === [ DbSets ] ===
		public virtual DbSet<User> User { get; set; }
		public virtual DbSet<Country> Country { get; set; }
		public virtual DbSet<State> State { get; set; }
		public virtual DbSet<City> City { get; set; }
		public virtual DbSet<AddressBook> AddressBook { get; set; }
		#endregion


		// Might be best to move these to another partial class, so they don't get removed in any updates.
		//public DbSet<VwCanActionsViewModel> VwPermissionsViewModel { get; set; }

		public MsSqlContext(DbContextOptions<MsSqlContext> options) : base(options)
		{

		}

		/// <summary>
		/// Context constructor
		/// </summary>
		/// <param name="dbName">DataBase Name</param>
		public MsSqlContext(string dbName)
		{
			_dbName = dbName;
		}

		/// <summary>
		/// Ons the configuring.
		/// </summary>
		/// <param name="optionsBuilder">Options builder.</param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			//optionsBuilder.EnableSensitiveDataLogging(false);
			base.OnConfiguring(optionsBuilder);

			if (!string.IsNullOrEmpty(_dbName))
			{
				optionsBuilder.UseSqlServer(_dbName);

			}
		}

		#region === [ Initial Charge ] ===
		/// <summary>
		/// Method to insert initial data
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Ignore<VwCanActionsViewModel>();
			
			new UserConfiguration(modelBuilder.Entity<User>());
			new CountryConfiguration(modelBuilder.Entity<Country>());
			new StateConfiguration(modelBuilder.Entity<State>());
			new CityConfiguration(modelBuilder.Entity<City>());
			new AddressBookConfiguration(modelBuilder.Entity<AddressBook>());

		}
		#endregion
	}
}
