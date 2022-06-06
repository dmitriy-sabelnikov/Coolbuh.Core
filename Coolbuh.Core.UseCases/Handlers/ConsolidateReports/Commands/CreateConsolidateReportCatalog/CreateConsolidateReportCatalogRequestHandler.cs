using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Extensions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Commands.CreateConsolidateReportCatalog
{
    /// <summary>
    /// Обработчик команды "Создать каталог объединенной ведомости"
    /// </summary>
    public class CreateConsolidateReportCatalogRequestHandler
        : IRequestHandler<CreateConsolidateReportCatalogRequest, ConsolidateReportCatalogDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IConsolidateReportsService _consolidateReportCatalogsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="consolidateReportCatalogsService">Доменный сервис "Каталог объединенной ведомости"</param>
        public CreateConsolidateReportCatalogRequestHandler(IDbContext dbContext,
            IConsolidateReportsService consolidateReportCatalogsService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _consolidateReportCatalogsService = consolidateReportCatalogsService ??
                                                throw new ArgumentNullException(nameof(consolidateReportCatalogsService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Каталог объединенной ведомости"</returns>
        public async Task<ConsolidateReportCatalogDto> Handle(CreateConsolidateReportCatalogRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.ConsolidateReportCatalog == null)
                throw new NullReferenceException(nameof(request.ConsolidateReportCatalog));

            var consolidateReportCatalog = request.ConsolidateReportCatalog.MapConsolidateReportCatalog();

            _consolidateReportCatalogsService.ValidationEntity(consolidateReportCatalog);

            await _dbContext.ConsolidateReportCatalogs.AddAsync(consolidateReportCatalog, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return consolidateReportCatalog.MapConsolidateReportCatalogDto();
        }
    }
}