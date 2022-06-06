using Coolbuh.Core.UseCases.Handlers.SickLists.Dto;
using MediatR;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.SickLists.Queries.GetSickListsByParams
{
    /// <summary>
    /// Объект запроса "Получить список больничных листов"
    /// </summary>
    public class GetSickListsByParamsRequest : IRequest<List<SickListDto>>
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
