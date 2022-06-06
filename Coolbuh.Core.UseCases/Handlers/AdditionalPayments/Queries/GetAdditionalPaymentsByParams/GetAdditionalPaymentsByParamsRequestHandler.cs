using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Dto;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Queries.GetAdditionalPaymentsByParams
{
    /// <summary>
    /// Обработчик запроса "Получить список дополнительных выплат"
    /// </summary>
    public class GetAdditionalPaymentsByParamsRequestHandler
        : IRequestHandler<GetAdditionalPaymentsByParamsRequest, List<AdditionalPaymentDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetAdditionalPaymentsByParamsRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Дополнительная выплата"</returns>
        public async Task<List<AdditionalPaymentDto>> Handle(GetAdditionalPaymentsByParamsRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var additionalPayments = _dbContext.AdditionalPayments.AsNoTracking()
                .Where(rec => rec.AccountingPeriod >= request.StartPeriod && rec.AccountingPeriod <= request.EndPeriod
                                                                          && (request.AdditionalPaymentTypeId != null &&
                                                                              rec.AdditionalPaymentTypeId == request.AdditionalPaymentTypeId
                                                                              || request.AdditionalPaymentTypeId == null))
                .SelectAdditionalPaymentDtos();

            return await additionalPayments.ToListAsync(cancellationToken);
        }
    }
}
