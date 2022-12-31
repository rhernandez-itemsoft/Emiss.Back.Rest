using Back.Rest.Domain.Filters;
using Back.Rest.Entities.Models;
using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.IManagers;
using ItemsoftMX.Base.Domain.Utils;
using System.Security.Claims;

namespace Back.Rest.Domain.IManagers
{
    /// <summary>
    /// UserManager Interface
    /// </summary>
    public interface IUserManager : IBaseManager<User, UserViewModel>
    {
        Task<byte[]> ExportCsvAsync(PagingParameter pagingParameter, UserFilter filter, CancellationToken ct = default(CancellationToken));
        Task<byte[]> ExportXlsAsync(PagingParameter pagingParameter, UserFilter filter, CancellationToken ct = default(CancellationToken));
        Task<byte[]> ExportPdfAsync(PagingParameter pagingParameter, UserFilter filter, CancellationToken ct = default(CancellationToken));

    }
}
