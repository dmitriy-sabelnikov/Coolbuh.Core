using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Commands.CreateListSpecialSeniority;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Commands.DeleteListSpecialSeniority;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Commands.UpdateListSpecialSeniority;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Dto;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Queries.GetListSpecialSeniorities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Справочник "Спецстажи"
    /// </summary>
    public class ListSpecialSenioritiesController : ApiController
    {
        public ListSpecialSenioritiesController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список спецстажей
        /// </summary>
        /// <response code="200">Список спецстажей</response>
        [HttpGet]
        public async Task<List<ListSpecialSeniorityDto>> Get()
        {
            return await _mediator.Send(new GetListSpecialSenioritiesRequest());
        }

        /// <summary>
        /// Создать спецстаж
        /// </summary>
        /// <param name="specialSeniority">Параметры для создания спецстажа</param>
        /// <response code="200">Созданный спецстаж</response>
        [HttpPost]
        public async Task<ListSpecialSeniorityDto> Post([FromBody] CreateListSpecialSeniorityDto specialSeniority)
        {
            return await _mediator.Send(new CreateListSpecialSeniorityRequest { SpecialSeniority = specialSeniority });
        }

        /// <summary>
        /// Обновить спецстаж
        /// </summary>
        /// <param name="specialSeniority">Параметры для обновления спецстажа</param>
        /// <response code="200">Обновленный спецстаж</response>
        [HttpPut]
        public async Task<ListSpecialSeniorityDto> Put([FromBody] UpdateListSpecialSeniorityDto specialSeniority)
        {
            return await _mediator.Send(new UpdateListSpecialSeniorityRequest { SpecialSeniority = specialSeniority });
        }

        /// <summary>
        /// Удалить спецстаж
        /// </summary>
        /// <param name="specialSeniority">Параметры для удаления спецстажа</param>
        /// <response code="200">Удаленный спецстаж</response>
        [HttpDelete]
        public async Task<ListSpecialSeniorityDto> Delete([FromBody] DeleteListSpecialSeniorityDto specialSeniority)
        {
            return await _mediator.Send(new DeleteListSpecialSeniorityRequest { SpecialSeniority = specialSeniority });
        }
    }
}
