using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Commands.DeleteListAdditionalAccrualType
{
    /// <summary>
    /// Объект команды "Удалить тип дополнительных начислений"
    /// </summary>
    public class DeleteListAdditionalAccrualTypeRequest : IRequest<ListAdditionalAccrualTypeDto>
    {
        /// <inheritdoc cref="DeleteListAdditionalAccrualTypeDto"/> 
        public DeleteListAdditionalAccrualTypeDto AdditionalAccrualType { get; set; }
    }
}
