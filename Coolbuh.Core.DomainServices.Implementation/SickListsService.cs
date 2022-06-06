using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="ISickListsService"/>
    public class SickListsService : ISickListsService
    {
        public void ValidationEntity(SickList sickList)
        {
            if (sickList == null) throw new ArgumentNullException(nameof(sickList));

            if (sickList.EmployeeCardId == 0)
                throw new NotValidEntityEntityException("Не обрана картка робітника");

            if (sickList.DepartmentId == 0)
                throw new NotValidEntityEntityException("Не обраний підрозділ");

            if (sickList.AccountingPeriod == DateTime.MinValue)
                throw new NotValidEntityEntityException("Не обраний обліковий період");

            if (sickList.AccrualPeriod == DateTime.MinValue)
                throw new NotValidEntityEntityException("Не обраний період, за який проводиться нарахування");
        }
    }
}
