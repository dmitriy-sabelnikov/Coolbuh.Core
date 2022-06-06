using Coolbuh.Core.UseCases.Handlers.Payments.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.Payments.Commands.UpdatePayment
{
    /// <summary>
    /// Объект команды "Обновить выплату"
    /// </summary>
    public class UpdatePaymentRequest : IRequest<PaymentDto>
    {
        /// <inheritdoc cref="UpdatePaymentDto"/>
        public UpdatePaymentDto Payment { get; set; }
    }
}
