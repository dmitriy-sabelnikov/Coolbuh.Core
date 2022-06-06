
using Coolbuh.Core.UseCases.Handlers.Payments.Commands.CreatePayment;
using Coolbuh.Core.UseCases.Handlers.Payments.Commands.DeletePayment;
using Coolbuh.Core.UseCases.Handlers.Payments.Commands.UpdatePayment;
using Coolbuh.Core.UseCases.Handlers.Payments.Dto;
using Coolbuh.Core.UseCases.Handlers.Payments.Queries.GetPaymentsByParams;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coolbuh.Core.Controllers
{
    /// <summary>
    /// Выплаты
    /// </summary>
    public class PaymentsController : ApiController
    {
        public PaymentsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Получить список выплат
        /// </summary>
        /// <response code="200">Список выплат</response>
        [HttpGet]
        public async Task<List<PaymentDto>> Get(DateTime startPeriod, DateTime endPeriod)
        {
            return await _mediator.Send(new GetPaymentsByParamsRequest
            {
                StartPeriod = startPeriod,
                EndPeriod = endPeriod
            });
        }

        /// <summary>
        /// Создать выплату
        /// </summary>
        /// <param name="payment">Параметры для создания выплаты</param>
        /// <response code="200">Созданная выплата</response>
        [HttpPost]
        public async Task<PaymentDto> Post([FromBody] CreatePaymentDto payment)
        {
            return await _mediator.Send(new CreatePaymentRequest { Payment = payment });
        }

        /// <summary>
        /// Обновить выплату
        /// </summary>
        /// <param name="payment">Параметры для обновления выплаты</param>
        /// <response code="200">Измененная выплата</response>
        [HttpPut]
        public async Task<PaymentDto> Put([FromBody] UpdatePaymentDto payment)
        {
            return await _mediator.Send(new UpdatePaymentRequest { Payment = payment });
        }

        /// <summary>
        /// Удалить выплату
        /// </summary>
        /// <param name="payment">Параметры для удаления выплаты</param>
        /// <response code="200">Удаленная выплата</response>
        [HttpDelete]
        public async Task<PaymentDto> Delete([FromBody] DeletePaymentDto payment)
        {
            return await _mediator.Send(new DeletePaymentRequest { Payment = payment });
        }
    }
}
