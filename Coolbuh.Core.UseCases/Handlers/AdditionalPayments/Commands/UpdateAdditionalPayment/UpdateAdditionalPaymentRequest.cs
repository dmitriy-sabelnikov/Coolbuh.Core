using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Dto;
using MediatR;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Commands.UpdateAdditionalPayment
{
    /// <summary>
    /// Объект команды "Обновить дополнительную выплату"
    /// </summary>
    public class UpdateAdditionalPaymentRequest : IRequest<AdditionalPaymentDto>
    {
        ///<inheritdoc cref="UpdateAdditionalPaymentDto"/>
        public UpdateAdditionalPaymentDto AdditionalPayment { get; set; }
    }
}