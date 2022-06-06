using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Commands.UpdateListPensionAllowance
{
    /// <summary>
    /// Объект команды "Обновить надбавку за пенсию"
    /// </summary>
    public class UpdateListPensionAllowanceRequest : IRequest<ListPensionAllowanceDto>
    {
        /// <inheritdoc cref="UpdateListPensionAllowanceDto"/>
        public UpdateListPensionAllowanceDto PensionAllowance { get; set; }
    }
}
