using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Commands.CreateListAdditionalAccrualType
{
    /// <summary>
    /// Объект команды "Создать тип дополнительных начислений"
    /// </summary>
    public class CreateListAdditionalAccrualTypeRequest : IRequest<ListAdditionalAccrualTypeDto>
    {
        /// <inheritdoc cref="CreateListAdditionalAccrualTypeDto"/> 
        public CreateListAdditionalAccrualTypeDto AdditionalAccrualType { get; set; }
    }
}
