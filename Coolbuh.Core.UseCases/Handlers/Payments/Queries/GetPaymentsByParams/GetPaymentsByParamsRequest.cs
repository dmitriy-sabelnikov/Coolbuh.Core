using Coolbuh.Core.UseCases.Handlers.Payments.Dto;
using MediatR;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.Payments.Queries.GetPaymentsByParams
{
    /// <summary>
    /// Объект запроса "Получить список выплат"
    /// </summary>
    public class GetPaymentsByParamsRequest : IRequest<List<PaymentDto>>
    {
        /// <summary>
        /// Начало отчетного периода
        /// </summary>
        public DateTime StartPeriod { get; set; }

        /// <summary>
        /// Окончание отчетного периода
        /// </summary>
        public DateTime EndPeriod { get; set; }
    }
}
