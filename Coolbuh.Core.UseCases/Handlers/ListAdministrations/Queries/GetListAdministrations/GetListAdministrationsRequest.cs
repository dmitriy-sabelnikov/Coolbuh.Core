using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ListAdministrations.Queries.GetListAdministrations
{
    /// <summary>
    /// Объект запроса "Получить список администрации"
    /// </summary>
    public class GetListAdministrationsRequest : IRequest<List<ListAdministrationDto>>
    {
    }
}