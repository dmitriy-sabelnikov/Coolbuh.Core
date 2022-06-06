using Coolbuh.Core.UseCases.Handlers.AccountingPeriods.Dto;
using Coolbuh.Core.UseCases.Handlers.AccountingPeriods.Queries.GetAccountingPeriods;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Отчетные периоды
    /// </summary>
    public class AccountingPeriodsController : ApiController
    {
        public AccountingPeriodsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список отчетных периодов
        /// </summary>
        /// <param name="AddItemAllYear">Добавлять в список Год</param>
        /// <response code="200">Список отчетных периодов</response>
        [HttpGet]
        public async Task<List<AccountingPeriodDto>> Get(bool AddItemAllYear)
        {
            return await _mediator.Send(new GetAccountingPeriodsRequest { AddItemAllYear = AddItemAllYear });
        }
    }
}
