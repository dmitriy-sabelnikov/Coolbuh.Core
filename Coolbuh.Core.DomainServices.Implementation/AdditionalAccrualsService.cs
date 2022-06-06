using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IAdditionalAccrualsService"/>
    public class AdditionalAccrualsService : IAdditionalAccrualsService
    {
        public void ValidationEntity(AdditionalAccrual additionalAccrual)
        {
            if (additionalAccrual == null) throw new ArgumentNullException(nameof(additionalAccrual));

            if (additionalAccrual.EmployeeCardId == 0)
                throw new NotValidEntityEntityException("Не обрана картка робітника");

            if (additionalAccrual.DepartmentId == 0)
                throw new NotValidEntityEntityException("Не обраний підрозділ");

            if (additionalAccrual.AdditionalAccrualTypeId == 0)
                throw new NotValidEntityEntityException("Не обраний тип додаткового нарахування");

            if (additionalAccrual.AccountingPeriod == DateTime.MinValue)
                throw new NotValidEntityEntityException("Не обраний обліковий період");
        }
    }
}
