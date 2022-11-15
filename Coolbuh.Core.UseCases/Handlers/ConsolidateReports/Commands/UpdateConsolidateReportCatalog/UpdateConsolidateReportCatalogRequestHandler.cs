using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Commands.UpdateConsolidateReportCatalog
{
    /// <summary>
    /// Обработчик команды "Обновить каталог объединенной ведомости"
    /// </summary>
    public class UpdateConsolidateReportCatalogRequestHandler
        : IRequestHandler<UpdateConsolidateReportCatalogRequest, ConsolidateReportCatalogDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IConsolidateReportsService _consolidateReportCatalogsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="consolidateReportCatalogsService">Доменный сервис "Каталог объединенной ведомости"</param>
        public UpdateConsolidateReportCatalogRequestHandler(IDbContext dbContext,
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
        public async Task<ConsolidateReportCatalogDto> Handle(UpdateConsolidateReportCatalogRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.ConsolidateReportCatalog == null)
                throw new InvalidOperationException("request.ConsolidateReportCatalog is null");

            var updateReportCatalog = await _dbContext.ConsolidateReportCatalogs
                .FirstOrDefaultAsync(rec => rec.Id == request.ConsolidateReportCatalog.Id, cancellationToken);

            if (updateReportCatalog == null)
                throw new NotFoundEntityUseCaseException(
                    $"Відсутній каталог об'єднаної відомості в базі (id: {request.ConsolidateReportCatalog.Id})");

            var consolidateReportCatalog = request.ConsolidateReportCatalog.MapConsolidateReportCatalog();

            updateReportCatalog.Number = consolidateReportCatalog.Number;
            updateReportCatalog.Name = consolidateReportCatalog.Name;
            updateReportCatalog.Flags = consolidateReportCatalog.Flags;

            _consolidateReportCatalogsService.ValidationEntity(updateReportCatalog);

            _dbContext.ConsolidateReportCatalogs.Update(updateReportCatalog);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return consolidateReportCatalog.MapConsolidateReportCatalogDto();
        }
    }
}