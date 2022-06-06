using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Queries.GetListGradeAllowances
{
    /// <summary>
    /// Объект запроса "Получить список надбавок за классность"
    /// </summary>
    public class GetListGradeAllowancesRequest : IRequest<List<ListGradeAllowanceDto>>
    {
    }
}
