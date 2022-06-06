using Coolbuh.Core.UseCases.Handlers.Vocations.Commands.CreateVocation;
using Coolbuh.Core.UseCases.Handlers.Vocations.Commands.DeleteVocation;
using Coolbuh.Core.UseCases.Handlers.Vocations.Commands.UpdateVocation;
using Coolbuh.Core.UseCases.Handlers.Vocations.Dto;
using Coolbuh.Core.UseCases.Handlers.Vocations.Queries.GetVocationsByParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Отпуска
    /// </summary>
    public class VocationsController : ApiController
    {
        public VocationsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список отпусков
        /// </summary>
        /// <response code="200">Список отпусков</response>
        [HttpGet]
        public async Task<List<VocationDto>> Get(DateTime startPeriod, DateTime endPeriod, int? departmentId)
        {
            return await _mediator.Send(new GetVocationsByParamsRequest
            {
                StartPeriod = startPeriod,
                EndPeriod = endPeriod,
                DepartmentId = departmentId
            });
        }

        /// <summary>
        /// Создать отпуск
        /// </summary>
        /// <param name="vocation">Параметры для создания отпуска</param>
        /// <response code="200">Добавленный отпуск</response>
        [HttpPost]
        public async Task<VocationDto> Post([FromBody] CreateVocationDto vocation)
        {
            return await _mediator.Send(new CreateVocationRequest { Vocation = vocation });
        }

        /// <summary>
        /// Обновить отпуск
        /// </summary>
        /// <param name="vocation">Параметры для обновления отпуска</param>
        /// <response code="200">Измененный отпуск</response>
        [HttpPut]
        public async Task<VocationDto> Put([FromBody] UpdateVocationDto vocation)
        {
            return await _mediator.Send(new UpdateVocationRequest { Vocation = vocation });
        }

        /// <summary>
        /// Удалить отпуск
        /// </summary>
        /// <param name="vocation">Параметры для удаления отпуска</param>
        /// <response code="200">Удаленный отпуск</response>
        [HttpDelete]
        public async Task<VocationDto> Delete([FromBody] DeleteVocationDto vocation)
        {
            return await _mediator.Send(new DeleteVocationRequest { Vocation = vocation });
        }
    }
}
