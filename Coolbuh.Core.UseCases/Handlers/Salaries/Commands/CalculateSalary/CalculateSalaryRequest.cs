using Coolbuh.Core.UseCases.Handlers.Salaries.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.Salaries.Commands.CalculateSalary
{
    /// <summary>
    /// Объект команды "Рассчитать зарплату"
    /// </summary>
    public class CalculateSalaryRequest : IRequest<CalculatedSalaryDto>
    {
        /// <inheritdoc cref="CalculateSalaryDto"/>
        public CalculateSalaryDto Salary { get; set; }
    }
}
