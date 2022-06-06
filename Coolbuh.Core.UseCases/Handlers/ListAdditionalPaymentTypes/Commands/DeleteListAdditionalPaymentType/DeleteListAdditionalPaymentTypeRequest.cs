using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Commands.DeleteListAdditionalPaymentType
{
    /// <summary>
    /// Объект команды "Удалить тип дополнительных выплат"
    /// </summary>
    public class DeleteListAdditionalPaymentTypeRequest : IRequest<ListAdditionalPaymentTypeDto>
    {
        /// <inheritdoc cref="DeleteListAdditionalPaymentTypeDto"/>
        public DeleteListAdditionalPaymentTypeDto AdditionalPaymentType { get; set; }
    }
}
