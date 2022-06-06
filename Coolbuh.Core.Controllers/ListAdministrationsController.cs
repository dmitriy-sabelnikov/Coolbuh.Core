using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Commands.CreateListAdministration;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Commands.DeleteListAdministration;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Commands.UpdateListAdministration;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Dto;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Queries.GetListAdministrations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Справочник "Администрации"
    /// </summary>
    public class ListAdministrationsController : ApiController
    {
        public ListAdministrationsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список администраций
        /// </summary>
        /// <response code="200">Список администраций</response>
        [HttpGet]
        public async Task<List<ListAdministrationDto>> Get()
        {
            return await _mediator.Send(new GetListAdministrationsRequest());
        }

        /// <summary>
        /// Создать администрацию
        /// </summary>
        /// <param name="administration">Параметры для создания администрации</param>
        /// <response code="200">Созданная администрация</response>
        [HttpPost]
        public async Task<ListAdministrationDto> Post([FromBody] CreateListAdministrationDto administration)
        {
            return await _mediator.Send(new CreateListAdministrationRequest { Administration = administration });
        }

        /// <summary>
        /// Обновить администрацию
        /// </summary>
        /// <param name="administration">Параметры для обновления администрации</param>
        /// <response code="200">Обновленная администрация</response>
        [HttpPut]
        public async Task<ListAdministrationDto> Put([FromBody] UpdateListAdministrationDto administration)
        {
            return await _mediator.Send(new UpdateListAdministrationRequest { Administration = administration });
        }

        /// <summary>
        /// Удалить администрацию
        /// </summary>
        /// <param name="administration">Параметры для удаления администрации</param>
        /// <response code="200">Удаленная администрация</response>
        [HttpDelete]
        public async Task<ListAdministrationDto> Delete([FromBody] DeleteListAdministrationDto administration)
        {
            return await _mediator.Send(new DeleteListAdministrationRequest { Administration = administration });
        }
    }
}