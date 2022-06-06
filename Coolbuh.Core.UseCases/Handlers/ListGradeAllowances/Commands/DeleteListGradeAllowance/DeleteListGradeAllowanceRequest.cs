using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Commands.DeleteListGradeAllowance
{
    /// <summary>
    /// Объект команды "Удалить надбавку за классность"
    /// </summary>
    public class DeleteListGradeAllowanceRequest : IRequest<ListGradeAllowanceDto>
    {
        /// <inheritdoc cref="DeleteListGradeAllowanceDto"/>
        public DeleteListGradeAllowanceDto GradeAllowance { get; set; }
    }
}
