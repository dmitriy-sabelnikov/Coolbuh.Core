using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Commands.UpdateListSpecialSeniority
{
    /// <summary>
    /// Объект команды "Обновить спецстаж"
    /// </summary>
    public class UpdateListSpecialSeniorityRequest : IRequest<ListSpecialSeniorityDto>
    {
        /// <inheritdoc cref="UpdateListSpecialSeniorityDto"/>
        public UpdateListSpecialSeniorityDto SpecialSeniority { get; set; }
    }
}
