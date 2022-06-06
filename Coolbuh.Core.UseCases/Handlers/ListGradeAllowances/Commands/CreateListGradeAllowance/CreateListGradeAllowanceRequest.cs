using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Commands.CreateListGradeAllowance
{
    /// <summary>
    /// Объект команды "Создать надбавку за классность"
    /// </summary>
    public class CreateListGradeAllowanceRequest : IRequest<ListGradeAllowanceDto>
    {
        /// <inheritdoc cref="CreateListGradeAllowanceDto"/>
        public CreateListGradeAllowanceDto GradeAllowance { get; set; }
    }
}
