using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto;
using Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Queries.GetConsolidateReportCatalogs
{
    /// <summary>
    /// Обработчик запроса "Получить список каталогов объединенной ведомости"
    /// </summary>
    public class GetConsolidateReportCatalogsRequestHandler : IRequestHandler<GetConsolidateReportCatalogsRequest,
        List<ConsolidateReportCatalogDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetConsolidateReportCatalogsRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Администрации"</returns>
        public async Task<List<ConsolidateReportCatalogDto>> Handle(GetConsolidateReportCatalogsRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var consolidateReportCatalogs = _dbContext.ConsolidateReportCatalogs
                .SelectConsolidateReportCatalogDtos();

            return await consolidateReportCatalogs.ToListAsync(cancellationToken);
        }
    }
}