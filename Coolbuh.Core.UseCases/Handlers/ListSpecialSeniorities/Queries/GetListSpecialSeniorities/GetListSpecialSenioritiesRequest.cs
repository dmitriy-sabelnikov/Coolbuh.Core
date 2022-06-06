using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Dto;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Queries.GetListSpecialSeniorities
{
    /// <summary>
    /// Объект запроса "Получить список спецстажей"
    /// </summary>
    public class GetListSpecialSenioritiesRequest : IRequest<List<ListSpecialSeniorityDto>>
    {
    }
}
