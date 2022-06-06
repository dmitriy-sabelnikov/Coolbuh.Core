using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Commands.CreateListOtherAllowance;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Commands.DeleteListOtherAllowance;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Commands.UpdateListOtherAllowance;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Queries.GetListOtherAllowances;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Справочник "Другие надбавки"
    /// </summary>
    public class ListOtherAllowancesController : ApiController
    {
        public ListOtherAllowancesController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список других надбавок
        /// </summary>
        /// <response code="200">Список других надбавок</response>
        [HttpGet]
        public async Task<List<ListOtherAllowanceDto>> Get()
        {
            return await _mediator.Send(new GetListOtherAllowancesRequest());
        }

        /// <summary>
        /// Создать другую надбавку
        /// </summary>
        /// <param name="otherAllowance">Параметры для создания другой надбавки</param>
        /// <response code="200">Созданная другая надбавка</response>
        [HttpPost]
        public async Task<ListOtherAllowanceDto> Post([FromBody] CreateListOtherAllowanceDto otherAllowance)
        {
            return await _mediator.Send(new CreateListOtherAllowanceRequest { OtherAllowance = otherAllowance });
        }

        /// <summary>
        /// Обновить другую надбавку
        /// </summary>
        /// <param name="otherAllowance">Параметры для обновления другой надбавки</param>
        /// <response code="200">Обновленная другая надбавка</response>
        [HttpPut]
        public async Task<ListOtherAllowanceDto> Put([FromBody] UpdateListOtherAllowanceDto otherAllowance)
        {
            return await _mediator.Send(new UpdateListOtherAllowanceRequest { OtherAllowance = otherAllowance });
        }

        /// <summary>
        /// Удалить другую надбавку
        /// </summary>
        /// <param name="otherAllowance">Параметры для удаления другой надбавки</param>
        /// <response code="200">Удаленная другая надбавка</response>
        [HttpDelete]
        public async Task<ListOtherAllowanceDto> Delete([FromBody] DeleteListOtherAllowanceDto otherAllowance)
        {
            return await _mediator.Send(new DeleteListOtherAllowanceRequest { OtherAllowance = otherAllowance });
        }
    }
}
