using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Queries.GetListPensionAllowances
{
    /// <summary>
    /// Объект запроса "Получить список надбавок за пенсию"
    /// </summary>
    public class GetListPensionAllowancesRequest : IRequest<List<ListPensionAllowanceDto>>
    {
    }
}
