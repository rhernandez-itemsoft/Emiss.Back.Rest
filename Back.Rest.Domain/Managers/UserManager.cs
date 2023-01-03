using AutoMapper;
using Back.Rest.Domain.Converters;
using Back.Rest.Domain.Filters;
using Back.Rest.Domain.IManagers;
using Back.Rest.Domain.IRepositories;
using Back.Rest.Entities.Models;
using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.Converters;
using ItemsoftMX.Base.Domain.Extensions;
using ItemsoftMX.Base.Domain.Filters;
using ItemsoftMX.Base.Domain.Managers;
using ItemsoftMX.Base.Domain.Utils;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace Back.Rest.Domain.Managers
{
    /// <summary>
    /// UserManager interface implementation
    /// </summary>
    public class UserManager : BaseManager<User, UserViewModel>, IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IOptions<BaseAppSettings> _options;

        private readonly IUserRepository _thisRepository;
       

        /// <summary>
        /// Constructor
        /// </summary>
        public UserManager(IUserRepository thisRespository, IOptions<BaseAppSettings> options, IMapper mapper) : base(thisRespository)
        {
            _options = options;
            _mapper = mapper;
            _thisRepository = thisRespository;
        }

        /// <summary>
        /// Gets the converter instance.
        /// </summary>
        /// <returns>
        /// The converter instance.
        /// </returns>
        protected override IConverter<User, UserViewModel> GetConverter()
        {
            return new UserConverter(_options, _mapper);
        }

        /// <summary>
        /// Entity preparation before saving in database.
        /// </summary>
        /// <param name="viewModel">User view model</param>
        /// <returns>User entity</returns>
        protected override User PrepareAddData(UserViewModel viewModel, ClaimsPrincipal userLogued)
        {
            int userId = CustomClaims.GetUserId(userLogued);

            User entity = _mapper.Map<UserViewModel, User>(viewModel);
            entity.CreatedAt = System.DateTime.UtcNow;
            entity.CreatedBy = userId;
            entity.Enabled = true;

            return entity;
        }

        /// <summary>
        /// Preparation of the entity before updating in database.
        /// </summary>
        /// <param name="entity">User entity</param>
        /// <param name="viewModel">User view model</param>
        /// <returns>User entity</returns>
        protected override User PrepareUpdateData(User entity, UserViewModel viewModel, ClaimsPrincipal userLogued)
        {
            int userId = CustomClaims.GetUserId(userLogued);
            if (entity is null) return entity;
            entity.FirstName = viewModel.FirstName;
            entity.LastName = viewModel.LastName;
            entity.MLastName = viewModel.MLastName;
            
          
            entity.Enabled = viewModel.Enabled;
            entity.UpdatedAt = System.DateTime.UtcNow;
            entity.UpdatedBy = userId;

            return entity;
        }

        /// <summary>
        /// Add User.
        /// </summary>
        /// <returns>The User entity added.</returns>
        /// <param name="viewModel">User View model.</param>
        /// <param name="ct">Cancelation token</param>
        public override async Task<Tuple<List<UserViewModel>, PagedResult<User>>> GetAllAsync(PagingParameter pagingParameter, IFilter filter, CancellationToken ct = default(CancellationToken))
        {
            IQueryable<User> rows = await _thisRepository.GetAllAsync(ct);
            PagedResult<User> source = rows.GetPaged(pagingParameter, filter);
            List<UserViewModel> resources = this.GetConverter().ConvertList(source.Results);
            source.Results = null;



            return new Tuple<List<UserViewModel>, PagedResult<User>>(resources, source);
        }


        /// <summary>
        /// Gets all resources.
        /// </summary>
        /// <returns>The all resources of repository.</returns>
        /// <param name="pagingParameter">Paging parameter.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="ct">Ct.</param>
        public async Task<byte[]> ExportCsvAsync(PagingParameter pagingParameter, UserFilter filter, CancellationToken ct = default(CancellationToken))
        {
            pagingParameter.FullResponse = false;
            pagingParameter.AllowPaging = false;
            Tuple<List<UserViewModel>, PagedResult<User>> result = await GetAllAsync(pagingParameter, filter, ct);
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
        public async Task<byte[]> ExportXlsAsync(PagingParameter pagingParameter, UserFilter filter, CancellationToken ct = default(CancellationToken))
        {
            pagingParameter.FullResponse = false;
            pagingParameter.AllowPaging = false;
            Tuple<List<UserViewModel>, PagedResult<User>> result = await GetAllAsync(pagingParameter, filter, ct);
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
        public async Task<byte[]> ExportPdfAsync(PagingParameter pagingParameter, UserFilter filter, CancellationToken ct = default(CancellationToken))
        {
            pagingParameter.FullResponse = false;
            pagingParameter.AllowPaging = false;
            Tuple<List<UserViewModel>, PagedResult<User>> result = await GetAllAsync(pagingParameter, filter, ct);
            if (!result.Item1.Any())
            {
                return null;
            }

            return await this.ToPdf(pagingParameter.ExportFields, result.Item1, "Users");
        }

    }
}
