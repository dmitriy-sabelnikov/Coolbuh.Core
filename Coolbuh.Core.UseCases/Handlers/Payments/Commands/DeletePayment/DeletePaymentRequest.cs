using Coolbuh.Core.UseCases.Handlers.Payments.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.Payments.Commands.DeletePayment
{
    /// <summary>
    /// Объект команды "Удалить выплату"
    /// </summary>
    public class DeletePaymentRequest : IRequest<PaymentDto>
    {
        /// <inheritdoc cref="DeletePaymentDto"/>
        public DeletePaymentDto Payment { get; set; }
    }
}
