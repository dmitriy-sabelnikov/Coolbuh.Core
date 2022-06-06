using Coolbuh.Core.UseCases.Handlers.ListPositions.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ListPositions.Queries.GetListPositions
{
    /// <summary>
    /// Объект запроса "Получить список должностей"
    /// </summary>
    public class GetListPositionsRequest : IRequest<List<ListPositionDto>>
    {
    }
}