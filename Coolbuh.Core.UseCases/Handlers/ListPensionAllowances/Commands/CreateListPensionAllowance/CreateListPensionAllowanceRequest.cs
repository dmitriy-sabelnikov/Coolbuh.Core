using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Commands.CreateListPensionAllowance
{
    /// <summary>
    /// Объект команды "Создать надбавку за пенсию"
    /// </summary>
    public class CreateListPensionAllowanceRequest : IRequest<ListPensionAllowanceDto>
    {
        /// <inheritdoc cref="CreateListPensionAllowanceDto"/>
        public CreateListPensionAllowanceDto PensionAllowance { get; set; }
    }
}
