using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Payments.Dto;
using Coolbuh.Core.UseCases.Handlers.Payments.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.Payments.Queries.GetPaymentsByParams
{
    /// <summary>
    /// Обработчик запроса "Получить список отпусков"
    /// </summary>
    public class GetPaymentsByParamsRequestHandler : IRequestHandler<GetPaymentsByParamsRequest, List<PaymentDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetPaymentsByParamsRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Выплата"</returns>
        public async Task<List<PaymentDto>> Handle(GetPaymentsByParamsRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var payments = _dbContext.Payments
                .Where(rec => rec.AccountingPeriod >= request.StartPeriod
                    && rec.AccountingPeriod <= request.EndPeriod)
                .SelectPaymentDtos();

            return await payments.ToListAsync(cancellationToken);
        }
    }
}
