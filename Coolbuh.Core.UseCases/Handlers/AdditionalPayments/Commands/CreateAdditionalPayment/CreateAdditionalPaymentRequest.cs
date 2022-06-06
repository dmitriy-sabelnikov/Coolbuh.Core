using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Commands.CreateAdditionalPayment
{
    /// <summary>
    /// Объект команды "Создать дополнительную выплату"
    /// </summary>
    public class CreateAdditionalPaymentRequest : IRequest<AdditionalPaymentDto>
    {
        ///<inheritdoc cref="CreateAdditionalPaymentDto"/> 
        public CreateAdditionalPaymentDto AdditionalPayment { get; set; }
    }
}
