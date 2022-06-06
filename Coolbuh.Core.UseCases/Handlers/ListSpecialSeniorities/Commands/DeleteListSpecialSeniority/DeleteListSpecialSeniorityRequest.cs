using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Commands.DeleteListSpecialSeniority
{
    /// <summary>
    /// Объект команды "Удалить спецстаж"
    /// </summary>
    public class DeleteListSpecialSeniorityRequest : IRequest<ListSpecialSeniorityDto>
    {
        /// <inheritdoc cref="DeleteListSpecialSeniorityDto"/>
        public DeleteListSpecialSeniorityDto SpecialSeniority { get; set; }
    }
}
