using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Commands.CreateListMinimumSalary;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Commands.DeleteListMinimumSalary;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Commands.UpdateListMinimumSalary;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Queries.GetListMinimumSalaries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Справочник "Минимальные зарплаты"
    /// </summary>
    public class ListMinimumSalariesController : ApiController
    {
        public ListMinimumSalariesController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список минимальных зарплат
        /// </summary>
        /// <response code="200">Список минимальных зарплат</response>
        [HttpGet]
        public async Task<List<ListMinimumSalaryDto>> Get()
        {
            return await _mediator.Send(new GetListMinimumSalariesRequest());
        }

        /// <summary>
        /// Создать минимальную зарплату
        /// </summary>
        /// <param name="minimumSalary">Параметры для создания минимальной зарплаты</param>
        /// <response code="200">Созданная минимальная зарплата</response>
        [HttpPost]
        public async Task<ListMinimumSalaryDto> Post([FromBody] CreateListMinimumSalaryDto minimumSalary)
        {
            return await _mediator.Send(new CreateListMinimumSalaryRequest { MinimumSalary = minimumSalary });
        }

        /// <summary>
        /// Обновить минимальную зарплату
        /// </summary>
        /// <param name="minimumSalary">Параметры для обновления минимальной зарплаты</param>
        /// <response code="200">Обновленная минимальная зарплата</response>
        [HttpPut]
        public async Task<ListMinimumSalaryDto> Put([FromBody] UpdateListMinimumSalaryDto minimumSalary)
        {
            return await _mediator.Send(new UpdateListMinimumSalaryRequest { MinimumSalary = minimumSalary });
        }

        /// <summary>
        /// Удалить минимальную зарплату
        /// </summary>
        /// <param name="minimumSalary">Параметры для удаления минимальной зарплаты</param>
        /// <response code="200">Удаленная минимальная зарплата</response>
        [HttpDelete]
        public async Task<ListMinimumSalaryDto> Delete([FromBody] DeleteListMinimumSalaryDto minimumSalary)
        {
            return await _mediator.Send(new DeleteListMinimumSalaryRequest { MinimumSalary = minimumSalary });
        }
    }
}
