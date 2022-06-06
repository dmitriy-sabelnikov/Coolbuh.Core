using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Queries.GetListAdditionalPaymentTypes
{
    /// <summary>
    /// Объект запроса "Получить список типов дополнительных выплат"
    /// </summary>
    public class GetListAdditionalPaymentTypesRequest : IRequest<List<ListAdditionalPaymentTypeDto>>
    {
    }
}
