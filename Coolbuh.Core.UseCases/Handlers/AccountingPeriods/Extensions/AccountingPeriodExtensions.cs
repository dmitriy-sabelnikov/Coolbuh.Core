using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.AccountingPeriods.Dto;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.AccountingPeriods.Extensions
{
    /// <summary>
    /// Методы расширения отчетных периодов
    /// </summary>
    public static class AccountingPeriodExtensions
    {
        /// <summary>
        /// Маппинг списка DTO "Отчетный период"
        /// </summary>
        /// <param name="accountingPeriods">Список отчетных периодов</param>
        /// <returns>Список DTO "Отчетный период"</returns>
        public static List<AccountingPeriodDto> MapListAccountingPeriodDto(
            this IEnumerable<AccountingPeriod> accountingPeriods)
        {
            if (accountingPeriods == null) throw new NullReferenceException(nameof(accountingPeriods));

            var result = new List<AccountingPeriodDto>();

            foreach (var period in accountingPeriods)
                result.Add(period.MapAccountingPeriodDto());

            return result;
        }

        /// <summary>
        /// Маппинг DTO "Отчетный период"
        /// </summary>
        /// <param name="accountingPeriod">Отчетный период</param>
        /// <returns>DTO "Отчетный период"</returns>
        public static AccountingPeriodDto MapAccountingPeriodDto(this AccountingPeriod accountingPeriod)
        {
            if (accountingPeriod == null) throw new NullReferenceException(nameof(accountingPeriod));

            return new AccountingPeriodDto
            {
                Year = accountingPeriod.Year,
                Month = accountingPeriod.Month,
                Caption = accountingPeriod.Caption
            };
        }
    }
}
