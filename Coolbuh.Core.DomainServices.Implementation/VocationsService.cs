using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IVocationsService"/>
    public class VocationsService : IVocationsService
    {
        public void ValidationEntity(Vocation vocation)
        {
            if (vocation == null) throw new ArgumentNullException(nameof(vocation));

            if (vocation.EmployeeCardId == 0)
                throw new NotValidEntityEntityException("Не обрана картка робітника");

            if (vocation.DepartmentId == 0)
                throw new NotValidEntityEntityException("Не обраний підрозділ");

            if (vocation.AccountingPeriod == DateTime.MinValue)
                throw new NotValidEntityEntityException("Не обраний обліковий період");

            if (vocation.AccrualPeriod == DateTime.MinValue)
                throw new NotValidEntityEntityException("Не обраний період, за який проводиться нарахування");
        }
    }
}
