using Coolbuh.Core.UseCases.Handlers.Vocations.Dto;
using MediatR;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.Vocations.Queries.GetVocationsByParams
{
    /// <summary>
    /// Объект запроса "Получить список отпусков"
    /// </summary>
    public class GetVocationsByParamsRequest : IRequest<List<VocationDto>>
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
