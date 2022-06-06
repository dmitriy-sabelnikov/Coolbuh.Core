using Coolbuh.Core.UseCases.Handlers.Salaries.Dto;
using MediatR;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.Salaries.Queries.GetSalaries
{
    /// <summary>
    /// Объект запроса "Получить список зарплат"
    /// </summary>
    public class GetSalariesRequest : IRequest<List<SalaryDto>>
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
