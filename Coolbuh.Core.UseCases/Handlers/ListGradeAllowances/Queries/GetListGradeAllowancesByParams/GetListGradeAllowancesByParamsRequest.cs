using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Queries.GetListGradeAllowancesByParams
{
    /// <summary>
    /// Объект запроса "Получить надбавки за классность"
    /// </summary>
    public class GetListGradeAllowancesByParamsRequest : IRequest<List<ListGradeAllowanceDto>>
    {
        /// <summary>
        /// Идентификатор подразделения
        /// </summary>
        public int? DepartmentId { get; set; }

        /// <summary>
        /// Классность
        /// </summary>
        public int? Grade { get; set; }
    }
}
