using Coolbuh.Core.UseCases.Handlers.Salaries.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.Salaries.Commands.DeleteSalary
{
    /// <summary>
    /// Объект команды "Удалить зарплату"
    /// </summary>
    public class DeleteSalaryRequest : IRequest<SalaryDto>
    {
        /// <inheritdoc cref="DeleteSalaryDto"/>
        public DeleteSalaryDto Salary { get; set; }
    }
}
