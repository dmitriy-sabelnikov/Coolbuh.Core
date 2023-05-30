using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Commands.DeleteConsolidateReportCatalog
{
    /// <summary>
    /// Обработчик команды "Удалить каталог объединенной ведомости"
    /// </summary>
    public class DeleteConsolidateReportCatalogRequestHandler
        : IRequestHandler<DeleteConsolidateReportCatalogRequest, ConsolidateReportCatalogDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteConsolidateReportCatalogRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Каталог объединенной ведомости"</returns>
        public async Task<ConsolidateReportCatalogDto> Handle(DeleteConsolidateReportCatalogRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.ConsolidateReportCatalog == null)
                throw new InvalidOperationException("request.ConsolidateReportCatalog is null");

            var consolidateReportCatalog =
                await GetConsolidateReportCatalogAsync(request.ConsolidateReportCatalog.Id, cancellationToken);

            _dbContext.ConsolidateReportCatalogs.Remove(consolidateReportCatalog);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return consolidateReportCatalog.MapConsolidateReportCatalogDto();
        }

        /// <summary>
        /// Получить каталог объединенной ведомости
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Каталог объединенной ведомости</returns>
        private async Task<ConsolidateReportCatalog> GetConsolidateReportCatalogAsync(int id,
            CancellationToken cancellationToken)
        {
            var consolidateReportCatalog = await _dbContext.ConsolidateReportCatalogs
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (consolidateReportCatalog == null)
                throw new NotFoundEntityUseCaseException($"Відсутній каталог об'єднаної відомості в базі (id: {id})");

            return consolidateReportCatalog;
        }
    }
}