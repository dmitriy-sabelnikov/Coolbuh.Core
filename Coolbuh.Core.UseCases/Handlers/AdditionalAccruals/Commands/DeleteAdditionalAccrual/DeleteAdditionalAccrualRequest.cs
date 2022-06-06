using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Commands.DeleteAdditionalAccrual
{
    /// <summary>
    /// Объект команды "Удалить дополнительное начисление"
    /// </summary>
    public class DeleteAdditionalAccrualRequest : IRequest<AdditionalAccrualDto>
    {
        ///<inheritdoc cref="DeleteAdditionalAccrualDto"/>
        public DeleteAdditionalAccrualDto AdditionalAccrual { get; set; }
    }
}
