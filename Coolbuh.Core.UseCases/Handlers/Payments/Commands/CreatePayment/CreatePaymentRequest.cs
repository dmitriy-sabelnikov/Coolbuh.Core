using Coolbuh.Core.UseCases.Handlers.Payments.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.Payments.Commands.CreatePayment
{
    /// <summary>
    /// Объект команды "Создать выплату"
    /// </summary>
    public class CreatePaymentRequest : IRequest<PaymentDto>
    {
        /// <inheritdoc cref="CreatePaymentDto"/>
        public CreatePaymentDto Payment { get; set; }
    }
}
