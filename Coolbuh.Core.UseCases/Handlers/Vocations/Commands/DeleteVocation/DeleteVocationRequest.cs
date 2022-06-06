using Coolbuh.Core.UseCases.Handlers.Vocations.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.Vocations.Commands.DeleteVocation
{
    /// <summary>
    /// Объект команды "Удалить отпуск"
    /// </summary>
    public class DeleteVocationRequest : IRequest<VocationDto>
    {
        /// <inheritdoc cref="DeleteVocationDto"/> 
        public DeleteVocationDto Vocation { get; set; }
    }
}
