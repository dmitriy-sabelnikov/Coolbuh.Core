using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IListMinimumSalariesService"/>
    public class ListMinimumSalariesService : IListMinimumSalariesService
    {
        public void ValidationEntity(ListMinimumSalary minimumSalary)
        {
            if (minimumSalary == null) throw new ArgumentNullException(nameof(minimumSalary));


            if (minimumSalary.PeriodEnd != null && minimumSalary.PeriodBegin != null &&
                minimumSalary.PeriodEnd < minimumSalary.PeriodBegin)
                throw new NotValidEntityEntityException("Дата початку більше за дату закінчення");

            if (minimumSalary.Sum == 0)
                throw new NotValidEntityEntityException("Не заповнена сума");
        }

        public bool IsExistsPeriodIntersection(ListMinimumSalary minimumSalary, IEnumerable<ListMinimumSalary> minimumSalaries)
        {
            if (minimumSalary == null) throw new ArgumentNullException(nameof(minimumSalary));
            if (minimumSalaries == null) throw new ArgumentNullException(nameof(minimumSalaries));

            var checkPeriodBegin = minimumSalary.PeriodBegin ?? DateTime.MinValue;
            var checkPeriodEnd = minimumSalary.PeriodEnd ?? DateTime.MaxValue;

            foreach (var entity in minimumSalaries)
            {
                if (entity.Id == minimumSalary.Id)
                    continue;

                var periodBegin = entity.PeriodBegin ?? DateTime.MinValue;
                var periodEnd = entity.PeriodEnd ?? DateTime.MaxValue;

                if (checkPeriodEnd >= periodBegin && checkPeriodBegin <= periodEnd)
                    return true;
            }

            return false;
        }
    }
}
