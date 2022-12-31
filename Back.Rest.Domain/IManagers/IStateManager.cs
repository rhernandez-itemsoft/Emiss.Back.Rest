using Back.Rest.Domain.Filters;
using Back.Rest.Entities.Models;
using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.IManagers;
using ItemsoftMX.Base.Domain.Utils;

namespace Back.Rest.Domain.IManagers
{
    /// <summary>
    /// State Manager Interface
    /// </summary>
    public interface IStateManager : IBaseManager<State, StateViewModel>
    {
        Task<byte[]> ExportCsvAsync(PagingParameter pagingParameter, StateFilter filter, CancellationToken ct = default(CancellationToken));
        Task<byte[]> ExportXlsAsync(PagingParameter pagingParameter, StateFilter filter, CancellationToken ct = default(CancellationToken));
        Task<byte[]> ExportPdfAsync(PagingParameter pagingParameter, StateFilter filter, CancellationToken ct = default(CancellationToken));
    }
}
