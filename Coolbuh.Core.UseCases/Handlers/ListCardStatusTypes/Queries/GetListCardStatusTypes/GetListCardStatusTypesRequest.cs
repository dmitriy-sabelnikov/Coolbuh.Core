using Coolbuh.Core.UseCases.Handlers.ListCardStatusTypes.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ListCardStatusTypes.Queries.GetListCardStatusTypes
{
    /// <summary>
    /// Объект запроса "Получить список типов статусов карточки"
    /// </summary>
    public class GetListCardStatusTypesRequest : IRequest<List<ListCardStatusTypeDto>>
    {
    }
}