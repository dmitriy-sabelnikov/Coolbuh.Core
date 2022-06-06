using Coolbuh.Core.UseCases.Handlers.AccountingPeriods.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.AccountingPeriods.Queries.GetAccountingPeriods
{
    /// <summary>
    /// Объект запроса "Получить список отчетных периодов"
    /// </summary>
    public class GetAccountingPeriodsRequest : IRequest<List<AccountingPeriodDto>>
    {
        /// <summary>
        /// Добавлять в список Год  
        /// </summary>
        public bool AddItemAllYear { get; set; }
    }
}
