using Coolbuh.Core.UseCases.Handlers.Vocations.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.Vocations.Commands.UpdateVocation
{
    /// <summary>
    /// Объект команды "Обновить отпуск"
    /// </summary>
    public class UpdateVocationRequest : IRequest<VocationDto>
    {
        /// <inheritdoc cref="UpdateVocationDto"/> 
        public UpdateVocationDto Vocation { get; set; }
    }
}
