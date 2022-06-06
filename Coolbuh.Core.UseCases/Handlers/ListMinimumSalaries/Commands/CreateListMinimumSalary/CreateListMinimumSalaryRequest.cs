using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Commands.CreateListMinimumSalary
{
    /// <summary>
    /// Объект команды "Создать минимальную зарплату"
    /// </summary>
    public class CreateListMinimumSalaryRequest : IRequest<ListMinimumSalaryDto>
    {
        /// <inheritdoc cref="CreateListMinimumSalaryDto"/>
        public CreateListMinimumSalaryDto MinimumSalary { get; set; }
    }
}
