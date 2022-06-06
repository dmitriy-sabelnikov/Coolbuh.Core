using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListAdministrations.Commands.CreateListAdministration
{
    /// <summary>
    /// Объект команды "Создать администрацию"
    /// </summary>
    public class CreateListAdministrationRequest : IRequest<ListAdministrationDto>
    {
        /// <inheritdoc cref="CreateListAdministrationDto"/>
        public CreateListAdministrationDto Administration { get; set; }
    }
}