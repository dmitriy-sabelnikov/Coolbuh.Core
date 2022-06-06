using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Commands.CreateListGradeAllowance;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Commands.DeleteListGradeAllowance;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Commands.UpdateListGradeAllowance;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Queries.GetListGradeAllowanceByParams;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Queries.GetListGradeAllowances;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Справочник "Надбавки за классность"
    /// </summary>
    public class ListGradeAllowancesController : ApiController
    {
        public ListGradeAllowancesController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список надбавок за классность
        /// </summary>
        /// <response code="200">Список надбавок за классность</response>
        [HttpGet]
        public async Task<List<ListGradeAllowanceDto>> Get()
        {
            return await _mediator.Send(new GetListGradeAllowancesRequest());
        }

        /// <summary>
        /// Получить надбавку за классность
        /// </summary>
        /// <response code="200">Надбавки зарплат</response>
        [HttpGet("{departmentId:int}")]
        public async Task<ListGradeAllowanceDto> Get(int departmentId, int? grade)
        {
            return await _mediator.Send(new GetListGradeAllowanceByParamsRequest()
            {
                DepartmentId = departmentId,
                Grade = grade
            });
        }

        /// <summary>
        /// Создать надбавку за классность
        /// </summary>
        /// <param name="gradeAllowance">Параметры для создания надбавки за классность</param>
        /// <response code="200">Созданная надбавка за классность</response>
        [HttpPost]
        public async Task<ListGradeAllowanceDto> Post([FromBody] CreateListGradeAllowanceDto gradeAllowance)
        {
            return await _mediator.Send(new CreateListGradeAllowanceRequest { GradeAllowance = gradeAllowance });
        }

        /// <summary>
        /// Обновить надбавку за классность
        /// </summary>
        /// <param name="gradeAllowance">Параметры для обновления надбавки за классность</param>
        /// <response code="200">Обновленная надбавка за классность</response>
        [HttpPut]
        public async Task<ListGradeAllowanceDto> Put([FromBody] UpdateListGradeAllowanceDto gradeAllowance)
        {
            return await _mediator.Send(new UpdateListGradeAllowanceRequest { GradeAllowance = gradeAllowance });
        }

        /// <summary>
        /// Удалить надбавку за классность
        /// </summary>
        /// <param name="gradeAllowance">Параметры для удаления надбавки за классность</param>
        /// <response code="200">Удаленная надбавка за классность</response>
        [HttpDelete]
        public async Task<ListGradeAllowanceDto> Delete([FromBody] DeleteListGradeAllowanceDto gradeAllowance)
        {
            return await _mediator.Send(new DeleteListGradeAllowanceRequest { GradeAllowance = gradeAllowance });
        }
    }
}
