using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListAdministrations.Commands.DeleteListAdministration
{
    /// <summary>
    /// Объект команды "Удалить администрацию"
    /// </summary>
    public class DeleteListAdministrationRequest : IRequest<ListAdministrationDto>
    {
        /// <inheritdoc cref="DeleteListAdministrationDto"/>
        public DeleteListAdministrationDto Administration { get; set; }
    }
}