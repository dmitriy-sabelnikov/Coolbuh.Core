using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Commands.UpdateListGradeAllowance
{
    /// <summary>
    /// Объект команды "Обновить надбавку за классность"
    /// </summary>
    public class UpdateListGradeAllowanceRequest : IRequest<ListGradeAllowanceDto>
    {
        /// <inheritdoc cref="UpdateListGradeAllowanceDto"/>
        public UpdateListGradeAllowanceDto GradeAllowance { get; set; }
    }
}
