using Back.Rest.Domain.Filters;
using Back.Rest.Domain.IManagers;
using Back.Rest.Entities.Models;
using Back.Rest.Entities.ViewModels;
using ItemsoftMX.Base.Domain.Controllers;
using ItemsoftMX.Base.Domain.Utils;
using ItemsoftMX.Base.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Security;

namespace Back.Rest.Api.Controllers
{
    /// <summary>
    /// Allows you to manage Country Catalog
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller"/>
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : BaseController<ICountryManager, Country, CountryViewModel, CountryViewModel, CountryFilter>
    {
        private readonly ICountryManager _thisManager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="manager">The mapper.</param>
        public CountryController(ICountryManager manager) : base(manager)
        {
            _thisManager = manager;
        }

        /// <summary>
        /// Get Country by specified Id
        /// </summary>
        /// <response code="200">Returns the Country</response>
        /// <response code="404">If the Country doesn´t exits</response>
        /// <response code="500">If server error exists</response>
        /// <param name="id">Country Id</param>
        /// <param name="ct">Cancellation Token</param>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CountryViewModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500, Type = typeof(ErrorMessageViewModel))]
        public override async Task<IActionResult> Get(int id, CancellationToken ct = default(CancellationToken))
        => await base.Get(id, ct);

        /// <summary>
        /// Get list of the Country entity with its relationships
        /// </summary>
        /// <response code="200">Returns the all Country</response>
        /// <response code="500">If server error exists</response>
        /// <param name="pagingParameter">Paging parameter.</param>
        /// <param name="entityFilter">Banner filter.</param>
        /// <param name="ct">Cancellation Token.</param>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<CountryViewModel>))]
        [ProducesResponseType(500, Type = typeof(ErrorMessageViewModel))]
        public override async Task<IActionResult> Get([FromQuery] PagingParameter pagingParameter, [FromQuery] CountryFilter entityFilter, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                Tuple<List<CountryViewModel>, PagedResult<Country>> response = await _thisManager.GetAllAsync(pagingParameter, entityFilter, ct);
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(response.Item2));
                //if this is true send item1 and item2 in same response result,this allows get all paging info. 
                if (pagingParameter.FullResponse)
                {
                    return ResponseOk(response);
                }

                if (response.Item1 == null || !response.Item1.Any())
                {
                    return ResponseNotFound();
                }

                return ResponseOk(response.Item1);
            }
            catch (DbUpdateException ex)
            {
                return ResponseException(ex);
            }
            catch (SqlException ex)
            {
                return ResponseException(ex);
            }
            catch (SecurityException ex)
            {
                return ResponseSecurityException(ex);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        /// <summary>
        /// Add a new Country
        /// </summary>
        /// <response code="201">Returns the created Country</response>
        /// <response code="500">If server error exists</response>
        /// <param name="input">Input.</param>
        /// <param name="ct">Cancellation Token</param>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CountryViewModel))]
        [ProducesResponseType(500, Type = typeof(ErrorMessageViewModel))]
        public override async Task<IActionResult> Post([FromBody] CountryViewModel input, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                CountryViewModel response = await _thisManager.AddAsync(HttpContext.User, input, ct);

                return ResponseOk(response, "", HttpStatusCode.Created);

            }
            catch (DbUpdateException ex)
            {
                return ResponseException(ex);
            }
            catch (SqlException ex)
            {
                return ResponseException(ex);
            }
            catch (SecurityException ex)
            {
                return ResponseSecurityException(ex);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        /// <summary>
        /// Put the specified Country
        /// </summary>
        /// <response code="200">Returns the updated Country</response>
        /// <response code="404">If Country doesn´t exits</response>
        /// <response code="500">If server error exists</response>
        /// <param name="id">Identifier.</param>
        /// <param name="input">Input.</param>
        /// <param name="ct">Cancellation Token</param>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(CountryViewModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500, Type = typeof(ErrorMessageViewModel))]
        public override async Task<IActionResult> Put(int id, [FromBody] CountryViewModel input, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                bool isUpdated = await _thisManager.UpdateAsync(HttpContext.User, input, id, ct);
                if (!isUpdated)
                {
                    return ResponseNotFound();
                }


                return ResponseOk(isUpdated);

            }
            catch (DbUpdateException ex)
            {
                return ResponseException(ex);
            }
            catch (SqlException ex)
            {
                return ResponseException(ex);
            }
            catch (SecurityException ex)
            {
                return ResponseSecurityException(ex);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        /// <summary>
        /// Patch the specified Country
        /// </summary>
        /// <response code="200">Returns the updated Country</response>
        /// <response code="404">If Country doesn´t exits</response>
        /// <response code="500">If server error exists</response>
        /// <param name="id">Identifier.</param>
        /// <param name="input">Input.</param>
        /// <param name="ct">Cancellation Token</param>
        [HttpPatch("{id}")]
        [ProducesResponseType(200, Type = typeof(CountryViewModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500, Type = typeof(ErrorMessageViewModel))]
        public override async Task<IActionResult> Patch(int id, [FromBody] CountryViewModel input, CancellationToken ct = default(CancellationToken))
        => await base.Patch(id, input, ct);

        /// <summary>
        /// Delete the specified Country
        /// </summary>
        /// <response code="204">If a Country is deleted successful</response>
        /// <response code="404">If a Country doesn´t exits</response>
        /// <response code="500">If server error exists</response>
        /// <param name="id">Identifier.</param>
        /// <param name="ct">Cancellation Token</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500, Type = typeof(ErrorMessageViewModel))]
        public override async Task<ActionResult> Delete(int id, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                if (await _thisManager.GetByIdAsync(id, ct) == null)
                {
                    return ResponseNotFound();
                }

                bool isDeleted = await _thisManager.DeleteAsync(id, ct);

                if (!isDeleted)
                {
                    return ResponseException(null);
                }


                return ResponseOk(isDeleted);

            }
            catch (DbUpdateException ex)
            {
                return ResponseException(ex);
            }
            catch (SqlException ex)
            {
                return ResponseException(ex);
            }
            catch (SecurityException ex)
            {
                return ResponseSecurityException(ex);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }



        /// <summary>
        /// Export to CSV: get list of the Country entity
        /// </summary>
        /// <response code="200">Returns the all Country</response>
        /// <response code="500">If server error exists</response>
        /// <param name="pagingParameter">Paging parameter.</param>
        /// <param name="entityFilter">Country filter.</param>
        /// <param name="ct">Cancellation Token.</param>
        [HttpGet("ExportCsv")]
        [ProducesResponseType(200, Type = typeof(List<CountryViewModel>))]
        [ProducesResponseType(500, Type = typeof(ErrorMessageViewModel))]
        public async Task<IActionResult> ExportCsv([FromQuery] PagingParameter pagingParameter, [FromQuery] CountryFilter entityFilter, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                Byte[] response = await _thisManager.ExportCsvAsync(pagingParameter, entityFilter, ct);
                if (response == null)
                {
                    return ResponseNotFound();
                }


                return ResponseOk(Convert.ToBase64String(response));
            }
            catch (DbUpdateException ex)
            {
                return ResponseException(ex);
            }
            catch (SqlException ex)
            {
                return ResponseException(ex);
            }
            catch (SecurityException ex)
            {
                return ResponseSecurityException(ex);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        /// <summary>
        /// Export to XLS: get list of the Country entity with its relationships
        /// </summary>
        /// <response code="200">Returns the all Country</response>
        /// <response code="500">If server error exists</response>
        /// <param name="pagingParameter">Paging parameter.</param>
        /// <param name="entityFilter">Country filter.</param>
        /// <param name="ct">Cancellation Token.</param>
        [HttpGet("ExportXls")]
        [ProducesResponseType(200, Type = typeof(List<CountryViewModel>))]
        [ProducesResponseType(500, Type = typeof(ErrorMessageViewModel))]
        public async Task<IActionResult> ExportXls([FromQuery] PagingParameter pagingParameter, [FromQuery] CountryFilter entityFilter, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                Byte[] response = await _thisManager.ExportXlsAsync(pagingParameter, entityFilter, ct);
                if (response == null)
                {
                    return ResponseNotFound();
                }


                return ResponseOk(Convert.ToBase64String(response));
            }
            catch (DbUpdateException ex)
            {
                return ResponseException(ex);
            }
            catch (SqlException ex)
            {
                return ResponseException(ex);
            }
            catch (SecurityException ex)
            {
                return ResponseSecurityException(ex);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }


        /// <summary>
        /// Export to PDF: get list of the Country entity with its relationships
        /// </summary>
        /// <response code="200">Returns the all Country</response>
        /// <response code="500">If server error exists</response>
        /// <param name="pagingParameter">Paging parameter.</param>
        /// <param name="entityFilter">Country filter.</param>
        /// <param name="ct">Cancellation Token.</param>
        [HttpGet("ExportPdf")]
        [ProducesResponseType(200, Type = typeof(List<CountryViewModel>))]
        [ProducesResponseType(500, Type = typeof(ErrorMessageViewModel))]
        public async Task<IActionResult> ExportPdf([FromQuery] PagingParameter pagingParameter, [FromQuery] CountryFilter entityFilter, CancellationToken ct = default(CancellationToken))
        {
            try
            {
                Byte[] response = await _thisManager.ExportPdfAsync(pagingParameter, entityFilter, ct);
                if (response == null)
                {
                    return ResponseNotFound();
                }


                return ResponseOk(Convert.ToBase64String(response));
            }
            catch (DbUpdateException ex)
            {
                return ResponseException(ex);
            }
            catch (SqlException ex)
            {
                return ResponseException(ex);
            }
            catch (SecurityException ex)
            {
                return ResponseSecurityException(ex);
            }
            catch (Exception ex)
            {
                return ResponseException(ex);
            }
        }

        /// <summary>
        /// Populates the entity.
        /// </summary>
        /// <param name="entity">Country Entity.</param>
        /// <param name="ct">CancellationToken.</param>
        /// <returns>The Country ViewModel.</returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public override async Task<CountryViewModel> PopulateEntity(CountryViewModel entity, CancellationToken ct = default(CancellationToken))
        => await base.PopulateEntity(entity, ct);

        /// <summary>
        /// ConverterOutput
        /// </summary>
        /// <param name="input">Input.</param>
        /// <returns>Country ViewModel</returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        protected override CountryViewModel ConverterOutput(CountryViewModel input)
        {
            return input;
        }
    }
}