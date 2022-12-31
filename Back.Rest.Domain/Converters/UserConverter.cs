using AutoMapper;
using Back.Rest.Entities.Models;
using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.Converters;
using ItemsoftMX.Base.Domain.Utils;
using Microsoft.Extensions.Options;

namespace Back.Rest.Domain.Converters
{
    /// <summary>
    /// User Converter
    /// </summary>
    public class UserConverter : IConverter<User, UserViewModel>
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
        /// Initializes a new instance of the <see cref="UserConverter"/> class.
        /// </summary>
        public UserConverter(IOptions<BaseAppSettings> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// Convert from the TSource type entity to the TDestination type entity
        /// </summary>
        /// <param name="entity">User entity.</param>
        /// <returns>User View Model</returns>
        public UserViewModel Convert(User entity)
        {
            return _mapper.Map<User, UserViewModel>(entity);
        }

        /// <summary>
        /// Convert from the TSource type list to the TDestination type list
        /// </summary>
        /// <param name="entityList">User List entity.</param>
        /// <returns>User View Model List</returns>
        public List<UserViewModel> ConvertList(IEnumerable<User> entityList)
        {
            return entityList.Select(entity =>
            {
                return _mapper.Map<User, UserViewModel>(entity);
            }).ToList();
        }
    }
}
