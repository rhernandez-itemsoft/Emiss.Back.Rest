using Back.Rest.Domain.Filters;
using Back.Rest.Entities.Models;
using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.IManagers;
using ItemsoftMX.Base.Domain.Utils;

namespace Back.Rest.Domain.IManagers
{
    /// <summary>
    /// Country Manager Interface
    /// </summary>
    public interface ICountryManager : IBaseManager<Country, CountryViewModel>
    {
        Task<byte[]> ExportCsvAsync(PagingParameter pagingParameter, CountryFilter filter, CancellationToken ct = default(CancellationToken));
        Task<byte[]> ExportXlsAsync(PagingParameter pagingParameter, CountryFilter filter, CancellationToken ct = default(CancellationToken));
        Task<byte[]> ExportPdfAsync(PagingParameter pagingParameter, CountryFilter filter, CancellationToken ct = default(CancellationToken));
    }
}
