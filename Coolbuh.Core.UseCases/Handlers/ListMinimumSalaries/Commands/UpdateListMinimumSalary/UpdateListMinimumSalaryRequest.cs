using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Commands.UpdateListMinimumSalary
{
    /// <summary>
    /// Объект команды "Обновить минимальную зарплату"
    /// </summary>
    public class UpdateListMinimumSalaryRequest : IRequest<ListMinimumSalaryDto>
    {
        /// <inheritdoc cref="UpdateListMinimumSalaryDto"/>
        public UpdateListMinimumSalaryDto MinimumSalary { get; set; }
    }
}
