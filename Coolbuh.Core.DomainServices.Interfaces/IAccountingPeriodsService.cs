using Coolbuh.Core.Entities.Models;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис "Отчетные периоды" 
    /// </summary>
    public interface IAccountingPeriodsService
    {
        /// <summary>
        /// Получить список отчетных периодов
        /// </summary>
        /// <param name="periodStart">Начало периода</param>
        /// <param name="periodEnd">Окончание периода</param>
        /// <param name="isAddItemAllYear">Добавить элемент "Год хххх"</param>
        /// <returns>Список</returns>
        IEnumerable<AccountingPeriod> GetAccountingPeriods(DateTime periodStart, DateTime periodEnd,
            bool isAddItemAllYear);
    }
}
