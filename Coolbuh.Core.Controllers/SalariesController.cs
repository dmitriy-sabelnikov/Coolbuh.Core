using Coolbuh.Core.UseCases.Handlers.Salaries.Commands.CalculateSalary;
using Coolbuh.Core.UseCases.Handlers.Salaries.Commands.CreateSalary;
using Coolbuh.Core.UseCases.Handlers.Salaries.Commands.DeleteSalary;
using Coolbuh.Core.UseCases.Handlers.Salaries.Commands.UpdateSalary;
using Coolbuh.Core.UseCases.Handlers.Salaries.Dto;
using Coolbuh.Core.UseCases.Handlers.Salaries.Queries.GetSalaries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    public class SalariesController : ApiController
    {
        public SalariesController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список зарплат
        /// </summary>
        /// <response code="200">Список зарплат</response>
        [HttpGet]
        public async Task<List<SalaryDto>> Get(DateTime startPeriod, DateTime endPeriod, int? departmentId)
        {
            return await _mediator.Send(new GetSalariesRequest
            {
                StartPeriod = startPeriod,
                EndPeriod = endPeriod,
                DepartmentId = departmentId
            });
        }

        /// <summary>
        /// Создать зарплату
        /// </summary>
        /// <param name="salary">Параметры для создания зарплаты</param>
        /// <response code="200">Созданная зарплата</response>
        [HttpPost]
        public async Task<SalaryDto> Post([FromBody] CreateSalaryDto salary)
        {
            return await _mediator.Send(new CreateSalaryRequest { Salary = salary });
        }

        /// <summary>
        /// Рассчитать зарплату
        /// </summary>
        /// <param name="salary">Параметры для расчета зарплаты</param>
        /// <response code="200">Рассчитанная зарплата</response>
        [HttpPost("Calculate")]
        public async Task<CalculatedSalaryDto> Post([FromBody] CalculateSalaryDto salary)
        {
            return await _mediator.Send(new CalculateSalaryRequest { Salary = salary });
        }

        /// <summary>
        /// Обновить зарплату
        /// </summary>
        /// <param name="salary">Параметры для обновления зарплаты</param>
        /// <response code="200">Измененная зарплата</response>
        [HttpPut]
        public async Task<SalaryDto> Put([FromBody] UpdateSalaryDto salary)
        {
            return await _mediator.Send(new UpdateSalaryRequest { Salary = salary });
        }

        /// <summary>
        /// Удалить зарплату
        /// </summary>
        /// <param name="salary">Параметры для удаления зарплаты</param>
        /// <response code="200">Удаленная зарплата</response>
        [HttpDelete]
        public async Task<SalaryDto> Delete([FromBody] DeleteSalaryDto salary)
        {
            return await _mediator.Send(new DeleteSalaryRequest { Salary = salary });
        }
    }
}
