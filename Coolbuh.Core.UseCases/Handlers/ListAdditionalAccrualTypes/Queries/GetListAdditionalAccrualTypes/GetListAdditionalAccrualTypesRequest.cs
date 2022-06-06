using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Queries.GetListAdditionalAccrualTypes
{
    /// <summary>
    /// Объект запроса "Получить типы дополнительных начислений"
    /// </summary>
    public class GetListAdditionalAccrualTypesRequest : IRequest<List<ListAdditionalAccrualTypeDto>>
    {
    }
}
