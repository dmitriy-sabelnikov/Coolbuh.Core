using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Commands.CreateListPensionAllowance;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Commands.DeleteListPensionAllowance;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Commands.UpdateListPensionAllowance;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Queries.GetListPensionAllowances;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Справочник "Надбавки за пенсию"
    /// </summary>
    public class ListPensionAllowancesController : ApiController
    {
        public ListPensionAllowancesController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список надбавок за пенсию
        /// </summary>
        /// <response code="200">Список надбавок за пенсию</response>
        [HttpGet]
        public async Task<List<ListPensionAllowanceDto>> Get()
        {
            return await _mediator.Send(new GetListPensionAllowancesRequest());
        }

        /// <summary>
        /// Создать надбавку за пенсию
        /// </summary>
        /// <param name="pensionAllowance">Параметры для создания надбавки за пенсию</param>
        /// <response code="200">Созданная надбавка за пенсию</response>
        [HttpPost]
        public async Task<ListPensionAllowanceDto> Post([FromBody] CreateListPensionAllowanceDto pensionAllowance)
        {
            return await _mediator.Send(new CreateListPensionAllowanceRequest { PensionAllowance = pensionAllowance });
        }

        /// <summary>
        /// Обновить надбавку за пенсию
        /// </summary>
        /// <param name="pensionAllowance">Параметры для обновления надбавки за пенсию</param>
        /// <response code="200">Обновленная надбавка за пенсию</response>
        [HttpPut]
        public async Task<ListPensionAllowanceDto> Put([FromBody] UpdateListPensionAllowanceDto pensionAllowance)
        {
            return await _mediator.Send(new UpdateListPensionAllowanceRequest { PensionAllowance = pensionAllowance });
        }

        /// <summary>
        /// Удалить надбавку за пенсию
        /// </summary>
        /// <param name="pensionAllowance">Параметры для удаления надбавки за пенсию</param>
        /// <response code="200">Удаленная надбавка за пенсию</response>
        [HttpDelete]
        public async Task<ListPensionAllowanceDto> Delete([FromBody] DeleteListPensionAllowanceDto pensionAllowance)
        {
            return await _mediator.Send(new DeleteListPensionAllowanceRequest { PensionAllowance = pensionAllowance });
        }
    }
}
