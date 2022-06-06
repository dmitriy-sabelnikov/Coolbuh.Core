using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Commands.CreateListSpecialSeniority
{
    /// <summary>
    /// Объект команды "Создать спецстаж"
    /// </summary>
    public class CreateListSpecialSeniorityRequest : IRequest<ListSpecialSeniorityDto>
    {
        /// <inheritdoc cref="CreateListSpecialSeniorityDto"/>
        public CreateListSpecialSeniorityDto SpecialSeniority { get; set; }
    }
}
