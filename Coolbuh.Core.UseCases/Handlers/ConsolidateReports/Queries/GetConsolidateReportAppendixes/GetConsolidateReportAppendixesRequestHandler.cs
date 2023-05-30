using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Queries.GetConsolidateReportAppendixes
{
    /// <summary>
    /// Обработчик запроса "Получить приложения объединенной ведомости"
    /// </summary>
    public class GetConsolidateReportAppendixesRequestHandler
        : IRequestHandler<GetConsolidateReportAppendixesRequest, ConsolidateReportAppendixesDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetConsolidateReportAppendixesRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Приложения объединенной ведомости"</returns>
        public async Task<ConsolidateReportAppendixesDto> Handle(GetConsolidateReportAppendixesRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var сonsolidateReportAppendixes1 = await _dbContext.ConsolidateReportAppendixes1
                .Where(rec => rec.ConsolidateReportCatalogId == request.ConsolidateReportCatalogId)
                .SelectConsolidateReportAppendix1Dtos().ToListAsync(cancellationToken);

            var сonsolidateReportAppendixes4 = await _dbContext.ConsolidateReportAppendixes4
                .Where(rec => rec.ConsolidateReportCatalogId == request.ConsolidateReportCatalogId)
                .SelectConsolidateReportAppendix4Dtos().ToListAsync(cancellationToken);

            var сonsolidateReportAppendixes6 = await _dbContext.ConsolidateReportAppendixes6
                .Where(rec => rec.ConsolidateReportCatalogId == request.ConsolidateReportCatalogId)
                .SelectConsolidateReportAppendix6Dtos().ToListAsync(cancellationToken);

            return new ConsolidateReportAppendixesDto
            {
                ConsolidateReportAppendixes1 = сonsolidateReportAppendixes1,
                ConsolidateReportAppendixes4 = сonsolidateReportAppendixes4,
                ConsolidateReportAppendixes6 = сonsolidateReportAppendixes6
            };
        }
    }
}
