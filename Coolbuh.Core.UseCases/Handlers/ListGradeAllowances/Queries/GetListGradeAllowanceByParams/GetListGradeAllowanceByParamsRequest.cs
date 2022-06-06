using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Queries.GetListGradeAllowanceByParams
{
    /// <summary>
    /// Объект запроса "Получить надбавку за классность"
    /// </summary>
    public class GetListGradeAllowanceByParamsRequest : IRequest<ListGradeAllowanceDto>
    {
        /// <summary>
        /// Идентификатор подразделения
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Классность
        /// </summary>
        public int? Grade { get; set; }
    }
}
