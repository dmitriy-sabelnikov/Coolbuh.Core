using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="ISalariesService"/>
    public class SalariesService : ISalariesService
    {
        public void ValidationEntity(Salary salary)
        {
            if (salary == null) throw new ArgumentNullException(nameof(salary));

            if (salary.EmployeeCardId == 0)
                throw new NotValidEntityEntityException("Не обрана картка робітника");

            if (salary.DepartmentId == 0)
                throw new NotValidEntityEntityException("Не обраний підрозділ");

            if (salary.AccountingPeriod == DateTime.MinValue)
                throw new NotValidEntityEntityException("Не обраний обліковий період");
        }

        public decimal CalculatePensionAllowanceSum(decimal sum, decimal percent)
            => Math.Round(sum * percent / 100, 2);

        public decimal CalculateGradeAllowanceSum(decimal sum, decimal percent)
            => Math.Round(sum * percent / 100, 2);

        public decimal CalculateOtherAllowanceSum(decimal sum, decimal percent)
            => Math.Round(sum * percent / 100, 2);

        public decimal CalculateSalaryResultSum(decimal sum, decimal pensionAllowanceSum,
            decimal gradeAllowanceSum, decimal otherAllowanceSum)
            => sum + pensionAllowanceSum + gradeAllowanceSum + otherAllowanceSum;
    }
}
