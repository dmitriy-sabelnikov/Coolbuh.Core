using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Commands.DeleteListOtherAllowance
{
    /// <summary>
    /// Объект команды "Удалить другую надбавку"
    /// </summary>
    public class DeleteListOtherAllowanceRequest : IRequest<ListOtherAllowanceDto>
    {
        /// <inheritdoc cref="DeleteListOtherAllowanceDto"/>
        public DeleteListOtherAllowanceDto OtherAllowance { get; set; }
    }
}
