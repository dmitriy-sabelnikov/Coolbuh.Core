using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Commands.UpdateAdditionalAccrual
{
    /// <summary>
    /// Объект команды "Обновить дополнительное начисление"
    /// </summary>
    public class UpdateAdditionalAccrualRequest : IRequest<AdditionalAccrualDto>
    {
        /// <inheritdoc cref="UpdateAdditionalAccrualDto"/>
        public UpdateAdditionalAccrualDto AdditionalAccrual { get; set; }
    }
}
