using AutoMapper;
using Back.Rest.Entities.Models;
using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.Converters;
using ItemsoftMX.Base.Domain.Utils;
using Microsoft.Extensions.Options;

namespace Back.Rest.Domain.Converters
{
    /// <summary>
    /// Country Converter
    /// </summary>
    public class CountryConverter : IConverter<Country, CountryViewModel>
    {
        /// <summary>
        /// The options.
        /// </summary>
        private readonly IOptions<BaseAppSettings> _options;

        /// <summary>
        /// Automapper instance
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryConverter"/> class.
        /// </summary>
        public CountryConverter(IOptions<BaseAppSettings> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// Convert from the TSource type entity to the TDestination type entity
        /// </summary>
        /// <param name="entity">Country entity.</param>
        /// <returns>Country View Model</returns>
        public CountryViewModel Convert(Country entity)
        {
            return _mapper.Map<Country, CountryViewModel>(entity);
        }

        /// <summary>
        /// Convert from the TSource type list to the TDestination type list
        /// </summary>
        /// <param name="entityList">Country List entity.</param>
        /// <returns>Country View Model List</returns>
        public List<CountryViewModel> ConvertList(IEnumerable<Country> entityList)
        {
            return entityList.Select(entity =>
            {
                return _mapper.Map<Country, CountryViewModel>(entity);
            }).ToList();
        }
    }
}
