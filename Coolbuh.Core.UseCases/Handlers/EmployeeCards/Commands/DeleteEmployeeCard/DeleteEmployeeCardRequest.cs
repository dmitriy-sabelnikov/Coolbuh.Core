using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.DeleteEmployeeCard
{
    /// <summary>
    /// Объект команды "Удалить карточку работника"
    /// </summary>
    public class DeleteEmployeeCardRequest : IRequest<EmployeeCardDto>
    {
        ///<inheritdoc cref="DeleteEmployeeCardDto"/> 
        public DeleteEmployeeCardDto EmployeeCard { get; set; }
    }
}
