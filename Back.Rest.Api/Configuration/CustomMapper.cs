using Back.Rest.Entities.Models;
using Back.Rest.Entities.ViewModels;

namespace Back.Rest.Api.Configuration
{
    public class CustomMapper : AutoMapper.Profile
    {
        public CustomMapper()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();

            CreateMap<AddressBookViewModel, AddressBook>();
            CreateMap<AddressBook, AddressBookViewModel>();

            CreateMap<CountryViewModel, Country>();
            CreateMap<Country, CountryViewModel>();

            CreateMap<StateViewModel, State>();
            CreateMap<State, StateViewModel>();

            CreateMap<CityViewModel, City>();
            CreateMap<City, CityViewModel>();
        }
    }
}
