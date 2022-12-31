using Back.Rest.Domain.Filters;
using Back.Rest.Entities.Models;
using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.IManagers;
using ItemsoftMX.Base.Domain.Utils;

namespace Back.Rest.Domain.IManagers
{
    /// <summary>
    /// City Manager Interface
    /// </summary>
    public interface ICityManager : IBaseManager<City, CityViewModel>
    {
        Task<byte[]> ExportCsvAsync(PagingParameter pagingParameter, CityFilter filter, CancellationToken ct = default(CancellationToken));
        Task<byte[]> ExportXlsAsync(PagingParameter pagingParameter, CityFilter filter, CancellationToken ct = default(CancellationToken));
        Task<byte[]> ExportPdfAsync(PagingParameter pagingParameter, CityFilter filter, CancellationToken ct = default(CancellationToken));
    }
}
