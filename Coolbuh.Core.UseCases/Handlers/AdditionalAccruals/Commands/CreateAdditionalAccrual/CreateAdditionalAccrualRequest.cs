using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Commands.CreateAdditionalAccrual
{
    /// <summary>
    /// Объект команды "Создать дополнительное начисление"
    /// </summary>
    public class CreateAdditionalAccrualRequest : IRequest<AdditionalAccrualDto>
    {
        /// <inheritdoc cref="CreateAdditionalAccrualDto"/>
        public CreateAdditionalAccrualDto AdditionalAccrual { get; set; }
    }
}
