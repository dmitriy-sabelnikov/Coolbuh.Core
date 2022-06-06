using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Commands.DeleteConsolidateReportCatalog
{
    /// <summary>
    /// Объект команды "Удалить каталог объединенной ведомости"
    /// </summary>
    public class DeleteConsolidateReportCatalogRequest : IRequest<ConsolidateReportCatalogDto>
    {
        public DeleteConsolidateReportCatalogDto ConsolidateReportCatalog { get; set; }
    }
}