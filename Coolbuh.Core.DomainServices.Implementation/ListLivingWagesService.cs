using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IListLivingWagesService"/>
    public class ListLivingWagesService : IListLivingWagesService
    {
        public void ValidationEntity(ListLivingWage livingWage)
        {
            if (livingWage == null) throw new ArgumentNullException(nameof(livingWage));


            if (livingWage.PeriodEnd != null && livingWage.PeriodBegin != null &&
                livingWage.PeriodEnd < livingWage.PeriodBegin)
                throw new NotValidEntityEntityException("Дата початку більше за дату закінчення");

            if (livingWage.Sum == 0)
                throw new NotValidEntityEntityException("Не заповнена сума");
        }

        public bool IsExistsPeriodIntersection(ListLivingWage livingWage, IEnumerable<ListLivingWage> livingWages)
        {
            if (livingWage == null) throw new ArgumentNullException(nameof(livingWage));
            if (livingWages == null) throw new ArgumentNullException(nameof(livingWages));

            var checkPeriodBegin = livingWage.PeriodBegin ?? DateTime.MinValue;
            var checkPeriodEnd = livingWage.PeriodEnd ?? DateTime.MaxValue;

            foreach (var entity in livingWages)
            {
                if (entity.Id == livingWage.Id)
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
