using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Dto;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Queries.GetAdditionalAccrualsByParams
{
    /// <summary>
    /// Обработчик запроса "Получить список дополнительных начислений"
    /// </summary>
    public class GetAdditionalAccrualsByParamsRequestHandler
        : IRequestHandler<GetAdditionalAccrualsByParamsRequest, List<AdditionalAccrualDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetAdditionalAccrualsByParamsRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Дополнительное начисление"</returns>
        public async Task<List<AdditionalAccrualDto>> Handle(GetAdditionalAccrualsByParamsRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var additionalAccruals = _dbContext.AdditionalAccruals.AsNoTracking()
                .Where(rec => rec.AccountingPeriod >= request.StartPeriod && rec.AccountingPeriod <= request.EndPeriod
                                                                          && (request.DepartmentId != null &&
                                                                              rec.DepartmentId == request.DepartmentId ||
                                                                              request.DepartmentId == null))
                .SelectAdditionalAccrualDtos();

            return await additionalAccruals.ToListAsync(cancellationToken);
        }
    }
}
