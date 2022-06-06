using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Commands.CreateAdditionalAccrual;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Commands.DeleteAdditionalAccrual;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Commands.UpdateAdditionalAccrual;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Dto;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Queries.GetAdditionalAccrualsByParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Дополнительные начисления
    /// </summary>
    public class AdditionalAccrualsController : ApiController
    {
        public AdditionalAccrualsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список дополнительных начислений
        /// </summary>
        /// <param name="startPeriod">Начало отчетного периода</param>
        /// <param name="endPeriod">Окончание отчетного периода</param>
        /// <param name="departmentId">Идентификатор подразделения</param>
        /// <response code="200">Список дополнительных начислений</response>
        [HttpGet]
        public async Task<List<AdditionalAccrualDto>> Get(DateTime startPeriod, DateTime endPeriod, int? departmentId)
        {
            return await _mediator.Send(new GetAdditionalAccrualsByParamsRequest
            {
                StartPeriod = startPeriod,
                EndPeriod = endPeriod,
                DepartmentId = departmentId
            });
        }

        /// <summary>
        /// Создать дополнительное начисление
        /// </summary>
        /// <param name="additionalAccrual">Параметры для создания дополнительного начисления</param>
        /// <response code="200">Созданное дополнительное начисление</response>
        [HttpPost]
        public async Task<AdditionalAccrualDto> Post([FromBody] CreateAdditionalAccrualDto additionalAccrual)
        {
            return await _mediator.Send(new CreateAdditionalAccrualRequest { AdditionalAccrual = additionalAccrual });
        }

        /// <summary>
        /// Обновить дополнительное начисление
        /// </summary>
        /// <param name="additionalAccrual">Параметры для обновления дополнительного начисления</param>
        /// <response code="200">Обновленное дополнительное начисление</response>
        [HttpPut]
        public async Task<AdditionalAccrualDto> Put([FromBody] UpdateAdditionalAccrualDto additionalAccrual)
        {
            return await _mediator.Send(new UpdateAdditionalAccrualRequest { AdditionalAccrual = additionalAccrual });
        }

        /// <summary>
        /// Удалить дополнительное начисление
        /// </summary>
        /// <param name="additionalAccrual">Параметры для удаления дополнительного начисления</param>
        /// <response code="200">Удаленное дополнительное начисление</response>
        [HttpDelete]
        public async Task<AdditionalAccrualDto> Delete([FromBody] DeleteAdditionalAccrualDto additionalAccrual)
        {
            return await _mediator.Send(new DeleteAdditionalAccrualRequest { AdditionalAccrual = additionalAccrual });
        }
    }
}
