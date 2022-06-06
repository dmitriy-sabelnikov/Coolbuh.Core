using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IPaymentsService"/>
    public class PaymentsService : IPaymentsService
    {
        public void ValidationEntity(Payment payment)
        {
            if (payment == null) throw new ArgumentNullException(nameof(payment));

            if (payment.EmployeeCardId == 0)
                throw new NotValidEntityEntityException("Не обрана картка робітника");

            if (payment.AccountingPeriod == DateTime.MinValue)
                throw new NotValidEntityEntityException("Не обраний обліковий період");
        }
    }
}
