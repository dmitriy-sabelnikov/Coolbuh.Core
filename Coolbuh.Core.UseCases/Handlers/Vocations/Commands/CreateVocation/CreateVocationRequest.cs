using Coolbuh.Core.UseCases.Handlers.Vocations.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.Vocations.Commands.CreateVocation
{
    /// <summary>
    /// Объект команды "Создать отпуск"
    /// </summary>
    public class CreateVocationRequest : IRequest<VocationDto>
    {
        /// <inheritdoc cref="CreateVocationDto"/> 
        public CreateVocationDto Vocation { get; set; }
    }
}
