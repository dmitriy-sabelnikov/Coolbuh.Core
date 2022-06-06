using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.CalculateEmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.CreateEmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.DeleteEmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.UpdateEmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Queries.GetEmployeeCardById;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Queries.GetEmployeeCards;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Карточки работника
    /// </summary>
    public class EmployeeCardsController : ApiController
    {
        public EmployeeCardsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список карточек работника
        /// </summary>
        /// <response code="200">Список карточек работника</response>
        [HttpGet]
        public async Task<List<EmployeeCardDto>> Get()
        {
            return await _mediator.Send(new GetEmployeeCardsRequest());
        }

        /// <summary>
        /// Получить карточку работника
        /// </summary>
        /// <param name="id">Идентификатор работника</param>
        /// <response code="200">Карточка работника</response>
        [HttpGet("{id:int}")]
        public async Task<EmployeeCardDto> Get(int id)
        {
            return await _mediator.Send(new GetEmployeeCardByIdRequest { Id = id });
        }

        /// <summary>
        /// Создать карточку работника
        /// </summary>
        /// <param name="employeeCard">Параметры для создания карточки работника</param>
        /// <response code="200">Созданная карточка работника</response>
        [HttpPost]
        public async Task<EmployeeCardDto> Post([FromBody] CreateEmployeeCardDto employeeCard)
        {
            return await _mediator.Send(new CreateEmployeeCardRequest { EmployeeCard = employeeCard });
        }

        /// <summary>
        /// Рассчитать карточку работника
        /// </summary>
        /// <returns></returns>
        [HttpGet("Calculate")]
        public async Task<CalculatedEmployeeCardDto> Post([FromBody] CalculateEmployeeCardDto employeeCard)
        {
            return await _mediator.Send(
                new CalculateEmployeeCardRequest { EmployeeCard = employeeCard });
        }

        /// <summary>
        /// Обновить карточку работника
        /// </summary>
        /// <param name="employeeCard">Параметры для обновления карточки работника</param>
        /// <response code="200">Обновленная карточка работника</response>
        [HttpPut]
        public async Task<EmployeeCardDto> Put([FromBody] UpdateEmployeeCardDto employeeCard)
        {
            return await _mediator.Send(new UpdateEmployeeCardRequest { EmployeeCard = employeeCard });
        }

        /// <summary>
        /// Удалить карточку работника
        /// </summary>
        /// <param name="employeeCard">Параметры для удаления карточки работника</param>
        /// <response code="200">Удаленная карточка работника</response>
        [HttpDelete]
        public async Task<EmployeeCardDto> Delete([FromBody] DeleteEmployeeCardDto employeeCard)
        {
            return await _mediator.Send(new DeleteEmployeeCardRequest { EmployeeCard = employeeCard });
        }
    }
}