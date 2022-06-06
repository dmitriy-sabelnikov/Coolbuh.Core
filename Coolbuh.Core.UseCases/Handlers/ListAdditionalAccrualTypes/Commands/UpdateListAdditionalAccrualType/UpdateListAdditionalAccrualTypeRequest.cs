using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Commands.UpdateListAdditionalAccrualType
{
    /// <summary>
    /// Объект команды "Обновить тип дополнительных начислений"
    /// </summary>
    public class UpdateListAdditionalAccrualTypeRequest : IRequest<ListAdditionalAccrualTypeDto>
    {
        /// <inheritdoc cref="UpdateListAdditionalAccrualTypeDto"/> 
        public UpdateListAdditionalAccrualTypeDto AdditionalAccrualType { get; set; }
    }
}
