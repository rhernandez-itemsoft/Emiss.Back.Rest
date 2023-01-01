using Back.Rest.Domain.Filters;
using Back.Rest.Entities.Models;
using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.IManagers;
using ItemsoftMX.Base.Domain.Utils;

namespace Back.Rest.Domain.IManagers
{
    /// <summary>
    /// Address Book Manager Interface
    /// </summary>
    public interface IAddressBookManager : IBaseManager<AddressBook, AddressBookViewModel>
    {
        Task<byte[]> ExportCsvAsync(PagingParameter pagingParameter, AddressBookFilter filter, CancellationToken ct = default(CancellationToken));
        Task<byte[]> ExportXlsAsync(PagingParameter pagingParameter, AddressBookFilter filter, CancellationToken ct = default(CancellationToken));
        Task<byte[]> ExportPdfAsync(PagingParameter pagingParameter, AddressBookFilter filter, CancellationToken ct = default(CancellationToken));
    }
}
