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
    /// State Manager interface implementation
    /// </summary>
    public class StateManager : BaseManager<State, StateViewModel>, IStateManager
    {
        private readonly IOptions<BaseAppSettings> _options;
        private readonly IStateRepository _thisRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        public StateManager(IStateRepository respository, IOptions<BaseAppSettings> options, IMapper mapper) : base(respository)
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
        protected override IConverter<State, StateViewModel> GetConverter()
        {
            return new StateConverter(_options, _mapper);
        }

        /// <summary>
        /// Entity preparation before saving in database.
        /// </summary>
        /// <param name="viewModel">State view model</param>
        /// <returns>State entity</returns>
        protected override State PrepareAddData(StateViewModel viewModel, ClaimsPrincipal userLogued)
        {
            uint userId = CustomClaims.GetUserId(userLogued);

            State entity = _mapper.Map<StateViewModel, State>(viewModel);
            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = userId;
            entity.Enabled = true;
            return entity;
        }

        /// <summary>
        /// Preparation of the entity before updating in database.
        /// </summary>
        /// <param name="entity">State entity</param>
        /// <param name="viewModel">State view model</param>
        /// <returns>State entity</returns>
        protected override State PrepareUpdateData(State entity, StateViewModel viewModel, ClaimsPrincipal userLogued)
        {
            uint userId = CustomClaims.GetUserId(userLogued);

            if (entity is null) return new State();

            entity.Enabled = viewModel.Enabled;
            entity.Code = viewModel.Code;
            entity.Abbreviation = viewModel.Abbreviation;
            entity.Name = viewModel.Name;

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
        public async Task<byte[]> ExportCsvAsync(PagingParameter pagingParameter, StateFilter filter, CancellationToken ct = default(CancellationToken))
        {
            pagingParameter.FullResponse = false;
            pagingParameter.AllowPaging = false;
            Tuple<List<StateViewModel>, PagedResult<State>> result = await GetAllAsync(pagingParameter, filter, ct);
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
        public async Task<byte[]> ExportXlsAsync(PagingParameter pagingParameter, StateFilter filter, CancellationToken ct = default(CancellationToken))
        {
            pagingParameter.FullResponse = false;
            pagingParameter.AllowPaging = false;
            Tuple<List<StateViewModel>, PagedResult<State>> result = await GetAllAsync(pagingParameter, filter, ct);
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
        public async Task<byte[]> ExportPdfAsync(PagingParameter pagingParameter, StateFilter filter, CancellationToken ct = default(CancellationToken))
        {
            pagingParameter.FullResponse = false;
            pagingParameter.AllowPaging = false;
            Tuple<List<StateViewModel>, PagedResult<State>> result = await GetAllAsync(pagingParameter, filter, ct);
            if (!result.Item1.Any())
            {
                return null;
            }

            return await this.ToPdf(pagingParameter.ExportFields, result.Item1, "Companies");
        }

    }
}
