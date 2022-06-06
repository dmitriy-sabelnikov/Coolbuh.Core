using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Queries.GetEmployeeCardById
{
    /// <summary>
    /// Объект запроса "Получить карточку работника"
    /// </summary>
    public class GetEmployeeCardByIdRequest : IRequest<EmployeeCardDto>
    {
        /// <summary>
        /// Идентификатор работника
        /// </summary>
        public int Id { get; set; }
    }
}