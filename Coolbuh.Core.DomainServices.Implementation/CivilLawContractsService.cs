using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="ICivilLawContractsService"/>
    public class CivilLawContractsService : ICivilLawContractsService
    {
        public void ValidationEntity(CivilLawContract civilLawContract)
        {
            if (civilLawContract == null) throw new ArgumentNullException(nameof(civilLawContract));

            if (civilLawContract.EmployeeCardId == 0)
                throw new NotValidEntityEntityException("Не обрана картка робітника");

            if (civilLawContract.DepartmentId == 0)
                throw new NotValidEntityEntityException("Не обраний підрозділ");

            if (civilLawContract.AccountingPeriod == DateTime.MinValue)
                throw new NotValidEntityEntityException("Не обраний обліковий період");

            if (civilLawContract.AccrualPeriod == DateTime.MinValue)
                throw new NotValidEntityEntityException("Не обраний період, за який проводиться нарахування");
        }
    }
}