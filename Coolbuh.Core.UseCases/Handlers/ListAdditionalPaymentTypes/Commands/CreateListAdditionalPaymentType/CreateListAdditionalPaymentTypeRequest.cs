using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Commands.CreateListAdditionalPaymentType
{
    /// <summary>
    /// Объект команды "Создать тип дополнительных выплат"
    /// </summary>
    public class CreateListAdditionalPaymentTypeRequest : IRequest<ListAdditionalPaymentTypeDto>
    {
        /// <inheritdoc cref="CreateListAdditionalPaymentTypeDto"/>
        public CreateListAdditionalPaymentTypeDto AdditionalPaymentType { get; set; }
    }
}
