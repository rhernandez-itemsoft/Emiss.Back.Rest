using AutoMapper;
using Back.Rest.Domain.Converters;
using Back.Rest.Domain.Filters;
using Back.Rest.Domain.IManagers;
using Back.Rest.Domain.IRepositories;
using Back.Rest.Entities.Models;
using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.Converters;
using ItemsoftMX.Base.Domain.Managers;
using ItemsoftMX.Base.Domain.Utils;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Back.Rest.Domain.Managers
{
    /// <summary>
    /// AddressBook Manager interface implementation
    /// </summary>
    public class AddressBookManager : BaseManager<AddressBook, AddressBookViewModel>, IAddressBookManager
    {
        private readonly IOptions<BaseAppSettings> _options;
        private readonly IAddressBookRepository _thisRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        public AddressBookManager(IAddressBookRepository respository, IOptions<BaseAppSettings> options, IMapper mapper) : base(respository)
        {
            _mapper = mapper;
            _options = options;
            _thisRepository = respository;
        }

        /// <summary>
        /// Gets the converter instance.
        /// </summary>
        /// <returns>
        /// The converter instance.
        /// </returns>
        protected override IConverter<AddressBook, AddressBookViewModel> GetConverter()
        {
            return new AddressBookConverter(_options, _mapper);
        }

        /// <summary>
        /// Entity preparation before saving in database.
        /// </summary>
        /// <param name="viewModel">AddressBook view model</param>
        /// <returns>AddressBook entity</returns>
        protected override AddressBook PrepareAddData(AddressBookViewModel viewModel, ClaimsPrincipal userLogued)
        {
            uint userId = CustomClaims.GetUserId(userLogued);

            AddressBook entity = _mapper.Map<AddressBookViewModel, AddressBook>(viewModel);
            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = userId;
            entity.Enabled = true;
            return entity;
        }

        /// <summary>
        /// Preparation of the entity before updating in database.
        /// </summary>
        /// <param name="entity">AddressBook entity</param>
        /// <param name="viewModel">AddressBook view model</param>
        /// <returns>AddressBook entity</returns>
        protected override AddressBook PrepareUpdateData(AddressBook entity, AddressBookViewModel viewModel, ClaimsPrincipal userLogued)
        {
            uint userId = CustomClaims.GetUserId(userLogued);

            if (entity is null) return new AddressBook();

            entity.Enabled = viewModel.Enabled;
            entity.Alias = viewModel.Alias;
            entity.Phone = viewModel.Phone;
            entity.Email = viewModel.Email;
            entity.CountryId = viewModel.CountryId;
            entity.StateId = viewModel.StateId;
            entity.CityId = viewModel.CityId;
            entity.Street = viewModel.Street;
            entity.Subdivision = viewModel.Subdivision;
            entity.Reference = viewModel.Reference;
            entity.ZipCode = viewModel.ZipCode;

            entity.UpdatedAt = System.DateTime.UtcNow;
            entity.UpdatedBy = userId;

            return entity;
        }

        /// <summary>
        /// Gets all resources.
        /// </summary>
        /// <returns>The all resources of repository.</returns>
        /// <param name="pagingParameter">Paging parameter.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="ct">Ct.</param>
        public async Task<byte[]> ExportCsvAsync(PagingParameter pagingParameter, AddressBookFilter filter, CancellationToken ct = default(CancellationToken))
        {
            pagingParameter.FullResponse = false;
            pagingParameter.AllowPaging = false;
            Tuple<List<AddressBookViewModel>, PagedResult<AddressBook>> result = await GetAllAsync(pagingParameter, filter, ct);
            if (!result.Item1.Any())
            {
                return null;
            }

            return await this.ToCsv(pagingParameter.ExportFields, result.Item1);
        }

        /// <summary>
        /// Gets all resources.
        /// </summary>
        /// <returns>The all resources of repository.</returns>
        /// <param name="pagingParameter">Paging parameter.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="ct">Ct.</param>
        public async Task<byte[]> ExportXlsAsync(PagingParameter pagingParameter, AddressBookFilter filter, CancellationToken ct = default(CancellationToken))
        {
            pagingParameter.FullResponse = false;
            pagingParameter.AllowPaging = false;
            Tuple<List<AddressBookViewModel>, PagedResult<AddressBook>> result = await GetAllAsync(pagingParameter, filter, ct);
            if (!result.Item1.Any())
            {
                return null;
            }

            return await this.ToXls(pagingParameter.ExportFields, result.Item1);
        }

        /// <summary>
        /// Gets all resources.
        /// </summary>
        /// <returns>The all resources of repository.</returns>
        /// <param name="pagingParameter">Paging parameter.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="ct">Ct.</param>
        public async Task<byte[]> ExportPdfAsync(PagingParameter pagingParameter, AddressBookFilter filter, CancellationToken ct = default(CancellationToken))
        {
            pagingParameter.FullResponse = false;
            pagingParameter.AllowPaging = false;
            Tuple<List<AddressBookViewModel>, PagedResult<AddressBook>> result = await GetAllAsync(pagingParameter, filter, ct);
            if (!result.Item1.Any())
            {
                return null;
            }

            return await this.ToPdf(pagingParameter.ExportFields, result.Item1, "Companies");
        }

    }
}
