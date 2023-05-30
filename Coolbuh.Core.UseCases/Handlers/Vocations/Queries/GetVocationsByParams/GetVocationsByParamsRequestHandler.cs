using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Vocations.Dto;
using Coolbuh.Core.UseCases.Handlers.Vocations.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.Vocations.Queries.GetVocationsByParams
{
    /// <summary>
    /// Обработчик запроса "Получить список отпусков"
    /// </summary>
    public class GetVocationsByParamsRequestHandler : IRequestHandler<GetVocationsByParamsRequest, List<VocationDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetVocationsByParamsRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Отпуск"</returns>
        public async Task<List<VocationDto>> Handle(GetVocationsByParamsRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var vocations = _dbContext.Vocations
                .Where(rec => rec.AccountingPeriod >= request.StartPeriod && rec.AccountingPeriod <= request.EndPeriod
                                                                          && (request.DepartmentId != null &&
                                                                              rec.DepartmentId ==
                                                                              request.DepartmentId ||
                                                                              request.DepartmentId == null))
                .SelectVocationDtos();

            return await vocations.ToListAsync(cancellationToken);
        }
    }
}
