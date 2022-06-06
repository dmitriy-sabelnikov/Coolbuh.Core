using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Commands.CreateConsolidateReportCatalog;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Commands.DeleteConsolidateReportCatalog;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Commands.UpdateConsolidateReportCatalog;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Queries.GetConsolidateReportAppendixes;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Queries.GetConsolidateReportCatalogs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Объединенная ведомость
    /// </summary>
    public class ConsolidateReportsController : ApiController
    {
        public ConsolidateReportsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список объединенных ведомостей
        /// </summary>
        /// <response code="200">Список объединенных ведомостей</response>
        [HttpGet]
        public async Task<List<ConsolidateReportCatalogDto>> Get()
        {
            return await _mediator.Send(new GetConsolidateReportCatalogsRequest());
        }

        /// <summary>
        /// Получить приложения объединенной ведомости
        /// </summary>
        /// <param name="consolidateReportCatalogId">Идентификатор каталога объединенной ведомости</param>
        /// <response code="200">Приложения объединенной ведомости</response>
        [HttpGet("Appendixes")]
        public async Task<ConsolidateReportAppendixesDto> Get(int consolidateReportCatalogId)
        {
            return await _mediator.Send(new GetConsolidateReportAppendixesRequest
            {
                ConsolidateReportCatalogId = consolidateReportCatalogId
            });
        }


        /// <summary>
        /// Создать объединенную ведомость
        /// </summary>
        /// <param name="consolidateReportCatalog">Параметры для объединенной ведомости</param>
        /// <response code="200">Созданная объединенная ведомость</response>
        [HttpPost]
        public async Task<ConsolidateReportCatalogDto> Post([FromBody] CreateConsolidateReportCatalogDto consolidateReportCatalog)
        {
            return await _mediator.Send(new CreateConsolidateReportCatalogRequest
            {
                ConsolidateReportCatalog = consolidateReportCatalog
            });
        }

        /// <summary>
        /// Обновить объединенную ведомость
        /// </summary>
        /// <param name="consolidateReportCatalog">Параметры для обновления объединенной ведомости</param>
        /// <response code="200">Обновленная объединенная ведомость</response>
        [HttpPut]
        public async Task<ConsolidateReportCatalogDto> Put([FromBody] UpdateConsolidateReportCatalogDto consolidateReportCatalog)
        {
            return await _mediator.Send(new UpdateConsolidateReportCatalogRequest
            {
                ConsolidateReportCatalog = consolidateReportCatalog
            });
        }

        /// <summary>
        /// Удалить объединенную ведомость
        /// </summary>
        /// <param name="consolidateReportCatalog">Параметры для удаления объединенной ведомости</param>
        /// <response code="200">Удаленная объединенная ведомость</response>
        [HttpDelete]
        public async Task<ConsolidateReportCatalogDto> Delete([FromBody] DeleteConsolidateReportCatalogDto consolidateReportCatalog)
        {
            return await _mediator.Send(new DeleteConsolidateReportCatalogRequest
            {
                ConsolidateReportCatalog = consolidateReportCatalog
            });
        }
    }
}
