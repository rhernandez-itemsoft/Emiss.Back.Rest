using Back.Rest.Data.Repositories;
using Back.Rest.Domain.IManagers;
using Back.Rest.Domain.IRepositories;
using Back.Rest.Domain.Managers;

namespace Back.Rest.Api.Configuration
{
    public static class DependencyInjectionExtension
    {
        public static void Add(this IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IAddressBookManager, AddressBookManager>();
            services.AddScoped<IAddressBookRepository, AddressBookRepository>();

            services.AddScoped<ICountryManager, CountryManager>();
            services.AddScoped<ICountryRepository, CountryRepository>(); 
            
            services.AddScoped<IStateManager, StateManager>();
            services.AddScoped<IStateRepository, StateRepository>();

            services.AddScoped<ICityManager, CityManager>();
            services.AddScoped<ICityRepository, CityRepository>();

            services.AddAutoMapper(typeof(Startup));
        }
    }
}
