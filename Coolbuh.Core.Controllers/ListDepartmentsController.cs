using Coolbuh.Core.UseCases.Handlers.ListDepartments.Commands.CreateListDepartment;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Commands.DeleteListDepartment;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Commands.UpdateListDepartment;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Dto;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Queries.GetListDepartments;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Справочник "Подразделения"
    /// </summary>
    public class ListDepartmentsController : ApiController
    {
        public ListDepartmentsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список подразделений
        /// </summary>
        /// <response code="200">Список подразделений</response>
        [HttpGet]
        public async Task<List<ListDepartmentDto>> Get()
        {
            return await _mediator.Send(new GetListDepartmentsRequest());
        }

        /// <summary>
        /// Создать подразделение
        /// </summary>
        /// <param name="department">Параметры для создания подразделения</param>
        /// <response code="200">Созданное подразделение</response>
        [HttpPost]
        public async Task<ListDepartmentDto> Post([FromBody] CreateListDepartmentDto department)
        {
            return await _mediator.Send(new CreateListDepartmentRequest { Department = department });
        }

        /// <summary>
        /// Обновить подразделение
        /// </summary>
        /// <param name="department">Параметры для обновления подразделения</param>
        /// <response code="200">Обновленное подразделение</response>
        [HttpPut]
        public async Task<ListDepartmentDto> Put([FromBody] UpdateListDepartmentDto department)
        {
            return await _mediator.Send(new UpdateListDepartmentRequest { Department = department });
        }

        /// <summary>
        /// Удалить подразделение
        /// </summary>
        /// <param name="department">Параметры для удаления подразделения</param>
        /// <response code="200">Удаленное подразделение</response>
        [HttpDelete]
        public async Task<ListDepartmentDto> Delete([FromBody] DeleteListDepartmentDto department)
        {
            return await _mediator.Send(new DeleteListDepartmentRequest { Department = department });
        }
    }
}
