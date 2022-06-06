using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Queries.GetConsolidateReportAppendixes
{
    /// <summary>
    /// Объект запроса "Получить приложения объединенной ведомости"
    /// </summary>
    public class GetConsolidateReportAppendixesRequest : IRequest<ConsolidateReportAppendixesDto>
    {
        /// <summary>
        /// Идентификатор каталога объединенной ведомости
        /// </summary>
        public int ConsolidateReportCatalogId { get; set; }
    }
}
