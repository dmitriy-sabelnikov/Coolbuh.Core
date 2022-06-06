using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.AccountingPeriods.Dto;
using Coolbuh.Core.UseCases.Handlers.AccountingPeriods.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.AccountingPeriods.Queries.GetAccountingPeriods
{
    /// <summary>
    /// Обработчик запроса "Получить список отчетных периодов"
    /// </summary>
    public class GetAccountingPeriodsRequestHandler
        : IRequestHandler<GetAccountingPeriodsRequest, List<AccountingPeriodDto>>
    {
        private readonly IDbContext _dbContext;
        private readonly IAccountingPeriodsService _accountingPeriodsService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        /// <param name="accountingPeriodsService">Доменный сервис "Отчетные периоды"</param>
        public GetAccountingPeriodsRequestHandler(IDbContext dbContext,
            IAccountingPeriodsService accountingPeriodsService)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _accountingPeriodsService = accountingPeriodsService ??
                                        throw new ArgumentNullException(nameof(accountingPeriodsService));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Отчетный период"</returns>
        public async Task<List<AccountingPeriodDto>> Handle(GetAccountingPeriodsRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var year = (await _dbContext.ApplicationSettings.AsNoTracking()
                .FirstOrDefaultAsync(rec => rec.Type == ApplicationSettingType.AccountingYear, cancellationToken: cancellationToken))
                ?.DigitValue ?? 0;

            var periodStart = new DateTime(DateTime.Today.Year - year, 1, 1);
            var periodEnd = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            var periods = _accountingPeriodsService.GetAccountingPeriods(periodStart, periodEnd,
                request.AddItemAllYear);

            return periods.MapListAccountingPeriodDto();
        }
    }
}
