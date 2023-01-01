using AutoMapper;
using Back.Rest.Entities.Models;
using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.Converters;
using ItemsoftMX.Base.Domain.Utils;
using Microsoft.Extensions.Options;

namespace Back.Rest.Domain.Converters
{
    /// <summary>
    /// AddressBook Converter
    /// </summary>
    public class AddressBookConverter : IConverter<AddressBook, AddressBookViewModel>
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
        /// Initializes a new instance of the <see cref="AddressBookConverter"/> class.
        /// </summary>
        public AddressBookConverter(IOptions<BaseAppSettings> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// Convert from the TSource type entity to the TDestination type entity
        /// </summary>
        /// <param name="entity">AddressBook entity.</param>
        /// <returns>AddressBook View Model</returns>
        public AddressBookViewModel Convert(AddressBook entity)
        {
            return _mapper.Map<AddressBook, AddressBookViewModel>(entity);
        }

        /// <summary>
        /// Convert from the TSource type list to the TDestination type list
        /// </summary>
        /// <param name="entityList">AddressBook List entity.</param>
        /// <returns>AddressBook View Model List</returns>
        public List<AddressBookViewModel> ConvertList(IEnumerable<AddressBook> entityList)
        {
            return entityList.Select(entity =>
            {
                return _mapper.Map<AddressBook, AddressBookViewModel>(entity);
            }).ToList();
        }
    }
}
