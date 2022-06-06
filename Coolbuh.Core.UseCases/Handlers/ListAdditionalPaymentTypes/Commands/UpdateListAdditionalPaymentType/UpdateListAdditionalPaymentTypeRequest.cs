using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Commands.UpdateListAdditionalPaymentType
{
    /// <summary>
    /// Объект команды "Обновить тип дополнительных выплат"
    /// </summary>
    public class UpdateListAdditionalPaymentTypeRequest : IRequest<ListAdditionalPaymentTypeDto>
    {
        /// <inheritdoc cref="UpdateListAdditionalPaymentTypeDto"/>
        public UpdateListAdditionalPaymentTypeDto AdditionalPaymentType { get; set; }
    }
}
