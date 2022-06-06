using Coolbuh.Core.UseCases.Handlers.SickLists.Commands.CreateSickList;
using Coolbuh.Core.UseCases.Handlers.SickLists.Commands.DeleteSickList;
using Coolbuh.Core.UseCases.Handlers.SickLists.Commands.UpdateSickList;
using Coolbuh.Core.UseCases.Handlers.SickLists.Dto;
using Coolbuh.Core.UseCases.Handlers.SickLists.Queries.GetSickListsByParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Больничные листы
    /// </summary>
    public class SickListsController : ApiController
    {
        public SickListsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список больничных листов
        /// </summary>
        /// <response code="200">Список больничных листов</response>
        [HttpGet]
        public async Task<List<SickListDto>> Get(DateTime startPeriod, DateTime endPeriod, int? departmentId)
        {
            return await _mediator.Send(new GetSickListsByParamsRequest
            {
                StartPeriod = startPeriod,
                EndPeriod = endPeriod,
                DepartmentId = departmentId
            });
        }

        /// <summary>
        /// Создать больничный лист
        /// </summary>
        /// <param name="sickList">Параметры для создания больничного листа</param>
        /// <response code="200">Созданный больничный лист</response>
        [HttpPost]
        public async Task<SickListDto> Post([FromBody] CreateSickListDto sickList)
        {
            return await _mediator.Send(new CreateSickListRequest { SickList = sickList });
        }

        /// <summary>
        /// Обновить больничный лист
        /// </summary>
        /// <param name="sickList">Параметры для обновления больничного листа</param>
        /// <response code="200">Измененный больничный лист</response>
        [HttpPut]
        public async Task<SickListDto> Put([FromBody] UpdateSickListDto sickList)
        {
            return await _mediator.Send(new UpdateSickListRequest { SickList = sickList });
        }

        /// <summary>
        /// Удалить больничный лист
        /// </summary>
        /// <param name="sickList">Параметры для удаления больничного листа</param>
        /// <response code="200">Удаленный больничный лист</response>
        [HttpDelete]
        public async Task<SickListDto> Delete([FromBody] DeleteSickListDto sickList)
        {
            return await _mediator.Send(new DeleteSickListRequest { SickList = sickList });
        }
    }
}
