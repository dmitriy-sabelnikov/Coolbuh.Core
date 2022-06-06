using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.CreateEmployeeCard
{
    /// <summary>
    /// Объект команды "Создать карточку работника"
    /// </summary>
    public class CreateEmployeeCardRequest : IRequest<EmployeeCardDto>
    {
        ///<inheritdoc cref="CreateEmployeeCardDto"/>
        public CreateEmployeeCardDto EmployeeCard { get; set; }
    }
}
