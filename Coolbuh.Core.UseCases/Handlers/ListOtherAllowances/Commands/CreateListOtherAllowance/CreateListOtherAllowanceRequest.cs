using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Commands.CreateListOtherAllowance
{
    /// <summary>
    /// Объект команды "Создать другую надбавку"
    /// </summary>
    public class CreateListOtherAllowanceRequest : IRequest<ListOtherAllowanceDto>
    {
        /// <inheritdoc cref="CreateListOtherAllowanceDto"/>
        public CreateListOtherAllowanceDto OtherAllowance { get; set; }
    }
}
