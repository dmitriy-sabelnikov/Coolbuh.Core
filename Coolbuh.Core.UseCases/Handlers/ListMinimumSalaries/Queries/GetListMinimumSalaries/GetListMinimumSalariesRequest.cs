using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Queries.GetListMinimumSalaries
{
    /// <summary>
    /// Объект запроса "Получить список минимальных зарплат"
    /// </summary>
    public class GetListMinimumSalariesRequest : IRequest<List<ListMinimumSalaryDto>>
    {
    }
}
