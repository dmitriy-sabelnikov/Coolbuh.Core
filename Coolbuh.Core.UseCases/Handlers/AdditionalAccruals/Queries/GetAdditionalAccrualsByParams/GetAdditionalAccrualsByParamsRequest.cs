using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Dto;
using MediatR;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Queries.GetAdditionalAccrualsByParams
{
    /// <summary>
    /// Объект запроса "Получить список дополнительных начислений"
    /// </summary>
    public class GetAdditionalAccrualsByParamsRequest : IRequest<List<AdditionalAccrualDto>>
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
        /// Идентификатор подразделения
        /// </summary>
        public int? DepartmentId { get; set; }
    }
}
