using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using MediatR;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Queries.GetEmployeeCards
{
    /// <summary>
    /// Объект запроса "Получить карточки работников"
    /// </summary>
    public class GetEmployeeCardsRequest : IRequest<List<EmployeeCardDto>>
    {
    }
}