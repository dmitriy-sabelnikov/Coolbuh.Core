using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Commands.DeleteListMinimumSalary
{
    /// <summary>
    /// Объект команды "Удалить минимальную зарплату"
    /// </summary>
    public class DeleteListMinimumSalaryRequest : IRequest<ListMinimumSalaryDto>
    {
        /// <inheritdoc cref="DeleteListMinimumSalaryDto"/>
        public DeleteListMinimumSalaryDto MinimumSalary { get; set; }
    }
}
