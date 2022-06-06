using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Commands.UpdateConsolidateReportCatalog
{
    /// <summary>
    /// Объект команды "Обновить каталог объединенной ведомости"
    /// </summary>
    public class UpdateConsolidateReportCatalogRequest : IRequest<ConsolidateReportCatalogDto>
    {
        public UpdateConsolidateReportCatalogDto ConsolidateReportCatalog { get; set; }
    }
}