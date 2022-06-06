using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Commands.DeleteListPensionAllowance
{
    /// <summary>
    /// Объект команды "Удалить надбавку за пенсию"
    /// </summary>
    public class DeleteListPensionAllowanceRequest : IRequest<ListPensionAllowanceDto>
    {
        /// <inheritdoc cref="DeleteListPensionAllowanceDto"/>
        public DeleteListPensionAllowanceDto PensionAllowance { get; set; }
    }
}
