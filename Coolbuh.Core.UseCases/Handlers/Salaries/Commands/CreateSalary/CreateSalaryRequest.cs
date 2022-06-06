using Coolbuh.Core.UseCases.Handlers.Salaries.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.Salaries.Commands.CreateSalary
{
    /// <summary>
    /// Объект команды "Создать зарплату"
    /// </summary>
    public class CreateSalaryRequest : IRequest<SalaryDto>
    {
        /// <inheritdoc cref="CreateSalaryDto"/>
        public CreateSalaryDto Salary { get; set; }
    }
}
