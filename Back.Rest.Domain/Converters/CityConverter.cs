using AutoMapper;
using Back.Rest.Entities.Models;
using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.Converters;
using ItemsoftMX.Base.Domain.Utils;
using Microsoft.Extensions.Options;

namespace Back.Rest.Domain.Converters
{
    /// <summary>
    /// City Converter
    /// </summary>
    public class CityConverter : IConverter<City, CityViewModel>
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
        /// Initializes a new instance of the <see cref="CityConverter"/> class.
        /// </summary>
        public CityConverter(IOptions<BaseAppSettings> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// Convert from the TSource type entity to the TDestination type entity
        /// </summary>
        /// <param name="entity">City entity.</param>
        /// <returns>City View Model</returns>
        public CityViewModel Convert(City entity)
        {
            return _mapper.Map<City, CityViewModel>(entity);
        }

        /// <summary>
        /// Convert from the TSource type list to the TDestination type list
        /// </summary>
        /// <param name="entityList">City List entity.</param>
        /// <returns>City View Model List</returns>
        public List<CityViewModel> ConvertList(IEnumerable<City> entityList)
        {
            return entityList.Select(entity =>
            {
                return _mapper.Map<City, CityViewModel>(entity);
            }).ToList();
        }
    }
}
