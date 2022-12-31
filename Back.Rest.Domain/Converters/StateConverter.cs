using AutoMapper;
using Back.Rest.Entities.Models;
using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.Converters;
using ItemsoftMX.Base.Domain.Utils;
using Microsoft.Extensions.Options;

namespace Back.Rest.Domain.Converters
{
    /// <summary>
    /// State Converter
    /// </summary>
    public class StateConverter : IConverter<State, StateViewModel>
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
        /// Initializes a new instance of the <see cref="StateConverter"/> class.
        /// </summary>
        public StateConverter(IOptions<BaseAppSettings> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// Convert from the TSource type entity to the TDestination type entity
        /// </summary>
        /// <param name="entity">State entity.</param>
        /// <returns>State View Model</returns>
        public StateViewModel Convert(State entity)
        {
            return _mapper.Map<State, StateViewModel>(entity);
        }

        /// <summary>
        /// Convert from the TSource type list to the TDestination type list
        /// </summary>
        /// <param name="entityList">State List entity.</param>
        /// <returns>State View Model List</returns>
        public List<StateViewModel> ConvertList(IEnumerable<State> entityList)
        {
            return entityList.Select(entity =>
            {
                return _mapper.Map<State, StateViewModel>(entity);
            }).ToList();
        }
    }
}
