using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IAdditionalPaymentsService"/>
    public class AdditionalPaymentsService : IAdditionalPaymentsService
    {
        public void ValidationEntity(AdditionalPayment additionalPayment)
        {
            if (additionalPayment == null) throw new ArgumentNullException(nameof(additionalPayment));

            if (additionalPayment.EmployeeCardId == 0)
                throw new NotValidEntityEntityException("Не обрана картка робітника");

            if (additionalPayment.AdditionalPaymentTypeId == 0)
                throw new NotValidEntityEntityException("Не обраний тип додаткової виплати");

            if (additionalPayment.AccountingPeriod == DateTime.MinValue)
                throw new NotValidEntityEntityException("Не обраний обліковий період");
        }
    }
}
