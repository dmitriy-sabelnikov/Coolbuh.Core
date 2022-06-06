using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Dto;
using MediatR;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Queries.GetAdditionalPaymentsByParams
{
    /// <summary>
    /// Объект запроса "Получить список дополнительных выплат"
    /// </summary>
    public class GetAdditionalPaymentsByParamsRequest : IRequest<List<AdditionalPaymentDto>>
    {
        /// <summary>
        /// Начало отчетного периода
        /// </summary>
        public DateTime StartPeriod { get; set; }

        /// <summary>
        /// Окончание отчетного периода
        /// </summary>
        public DateTime EndPeriod { get; set; }

        /// <summary>
        /// Идентификатор типа дополнительной выплаты
        /// </summary>
        public int? AdditionalPaymentTypeId { get; set; }
    }
}
