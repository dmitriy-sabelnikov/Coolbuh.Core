using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.UpdateEmployeeCard
{
    /// <summary>
    /// Объект команды "Обновить карточку работника"
    /// </summary>
    public class UpdateEmployeeCardRequest : IRequest<EmployeeCardDto>
    {
        ///<inheritdoc cref="UpdateEmployeeCardDto"/> 
        public UpdateEmployeeCardDto EmployeeCard { get; set; }
    }
}
