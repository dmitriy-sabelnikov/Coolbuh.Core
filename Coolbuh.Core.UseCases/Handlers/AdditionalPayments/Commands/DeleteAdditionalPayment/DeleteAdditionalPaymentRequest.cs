using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Commands.DeleteAdditionalPayment
{
    /// <summary>
    /// Объект команды "Удалить дополнительную выплату"
    /// </summary>
    public class DeleteAdditionalPaymentRequest : IRequest<AdditionalPaymentDto>
    {
        ///<inheritdoc cref="DeleteAdditionalPaymentDto"/>
        public DeleteAdditionalPaymentDto AdditionalPayment { get; set; }
    }
}
