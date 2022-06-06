using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Queries.GetConsolidateReportCatalogs
{
    /// <summary>
    /// Объект запроса "Получить список каталогов объединенной ведомости"
    /// </summary>
    public class GetConsolidateReportCatalogsRequest : IRequest<List<ConsolidateReportCatalogDto>>
    {
    }
}