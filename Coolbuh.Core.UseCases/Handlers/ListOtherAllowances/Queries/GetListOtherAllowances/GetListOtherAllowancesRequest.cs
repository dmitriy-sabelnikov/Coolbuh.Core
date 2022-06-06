using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Queries.GetListOtherAllowances
{
    /// <summary>
    /// Объект запроса "Получить список надбавок"
    /// </summary>
    public class GetListOtherAllowancesRequest : IRequest<List<ListOtherAllowanceDto>>
    {
    }
}
