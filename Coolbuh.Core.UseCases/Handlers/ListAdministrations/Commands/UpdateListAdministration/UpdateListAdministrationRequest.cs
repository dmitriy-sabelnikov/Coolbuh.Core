using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListAdministrations.Commands.UpdateListAdministration
{
    /// <summary>
    /// Объект команды "Обновить администрацию"
    /// </summary>
    public class UpdateListAdministrationRequest : IRequest<ListAdministrationDto>
    {
        /// <inheritdoc cref="UpdateListAdministrationDto"/>
        public UpdateListAdministrationDto Administration { get; set; }
    }
}