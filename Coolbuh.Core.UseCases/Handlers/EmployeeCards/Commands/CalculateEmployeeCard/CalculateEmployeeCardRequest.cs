using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.CalculateEmployeeCard
{
    /// <summary>
    /// Объект команды "Рассчитать карточку работника"
    /// </summary>
    public class CalculateEmployeeCardRequest : IRequest<CalculatedEmployeeCardDto>
    {
        ///<inheritdoc cref="CalculateEmployeeCardDto"/>
        public CalculateEmployeeCardDto EmployeeCard { get; set; }
    }
}
