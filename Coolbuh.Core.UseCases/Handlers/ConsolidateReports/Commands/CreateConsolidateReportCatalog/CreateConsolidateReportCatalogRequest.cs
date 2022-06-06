using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Commands.CreateConsolidateReportCatalog
{
    /// <summary>
    /// Объект команды "Создать каталог объединенной ведомости"
    /// </summary>
    public class CreateConsolidateReportCatalogRequest : IRequest<ConsolidateReportCatalogDto>
    {
        public CreateConsolidateReportCatalogDto ConsolidateReportCatalog { get; set; }
    }
}