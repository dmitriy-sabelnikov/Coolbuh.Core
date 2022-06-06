using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Commands.CreateAdditionalPayment;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Commands.DeleteAdditionalPayment;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Commands.UpdateAdditionalPayment;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Dto;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Queries.GetAdditionalPaymentsByParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Дополнительные выплаты
    /// </summary>
    public class AdditionalPaymentsController : ApiController
    {
        public AdditionalPaymentsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список дополнительных выплат
        /// </summary>
        /// <param name="startPeriod">Начало отчетного периода</param>
        /// <param name="endPeriod">Окончание отчетного периода</param>
        /// <param name="additionalPaymentTypeId">Идентификатор типа дополнительной выплаты</param>
        /// <response code="200">Список дополнительных выплат</response>
        [HttpGet]
        public async Task<List<AdditionalPaymentDto>> Get(DateTime startPeriod, DateTime endPeriod,
            int? additionalPaymentTypeId)
        {
            return await _mediator.Send(new GetAdditionalPaymentsByParamsRequest
            {
                StartPeriod = startPeriod,
                EndPeriod = endPeriod,
                AdditionalPaymentTypeId = additionalPaymentTypeId
            });
        }

        /// <summary>
        /// Создать дополнительную выплату
        /// </summary>
        /// <param name="additionalPayment">Параметры для создания дополнительной выплаты</param>
        /// <response code="200">Созданная дополнительная выплата</response>
        [HttpPost]
        public async Task<AdditionalPaymentDto> Post([FromBody] CreateAdditionalPaymentDto additionalPayment)
        {
            return await _mediator.Send(new CreateAdditionalPaymentRequest { AdditionalPayment = additionalPayment });
        }

        /// <summary>
        /// Обновить дополнительную выплату
        /// </summary>
        /// <param name="additionalPayment">Параметры для обновления дополнительной выплаты</param>
        /// <response code="200">Обновленная дополнительная выплата</response>
        [HttpPut]
        public async Task<AdditionalPaymentDto> Put([FromBody] UpdateAdditionalPaymentDto additionalPayment)
        {
            return await _mediator.Send(new UpdateAdditionalPaymentRequest { AdditionalPayment = additionalPayment });
        }

        /// <summary>
        /// Удалить дополнительную выплату
        /// </summary>
        /// <param name="additionalPayment">Параметры для удаления дополнительной выплаты</param>
        /// <response code="200">Удаленная дополнительная выплата</response>
        [HttpDelete]
        public async Task<AdditionalPaymentDto> Delete([FromBody] DeleteAdditionalPaymentDto additionalPayment)
        {
            return await _mediator.Send(new DeleteAdditionalPaymentRequest { AdditionalPayment = additionalPayment });
        }
    }
}
