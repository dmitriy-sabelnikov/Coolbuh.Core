using Coolbuh.Core.UseCases.Handlers.Salaries.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.Salaries.Commands.UpdateSalary
{
    /// <summary>
    /// Объект команды "Обновить зарплату"
    /// </summary>
    public class UpdateSalaryRequest : IRequest<SalaryDto>
    {
        /// <inheritdoc cref="UpdateSalaryDto"/>
        public UpdateSalaryDto Salary { get; set; }

    }
}
