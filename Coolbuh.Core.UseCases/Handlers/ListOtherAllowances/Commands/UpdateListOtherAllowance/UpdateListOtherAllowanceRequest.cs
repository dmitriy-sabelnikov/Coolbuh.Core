using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Commands.UpdateListOtherAllowance
{
    /// <summary>
    /// Объект команды "Обновить другую надбавку"
    /// </summary>
    public class UpdateListOtherAllowanceRequest : IRequest<ListOtherAllowanceDto>
    {
        /// <inheritdoc cref="UpdateListOtherAllowanceDto"/>
        public UpdateListOtherAllowanceDto OtherAllowance { get; set; }
    }
}
