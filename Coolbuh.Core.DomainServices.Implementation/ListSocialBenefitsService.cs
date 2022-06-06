using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IListSocialBenefitsService"/>
    public class ListSocialBenefitsService : IListSocialBenefitsService
    {
        public void ValidationEntity(ListSocialBenefit socialBenefit)
        {
            if (socialBenefit == null) throw new ArgumentNullException(nameof(socialBenefit));

            if (socialBenefit.PeriodEnd != null && socialBenefit.PeriodBegin != null &&
                socialBenefit.PeriodEnd < socialBenefit.PeriodBegin)
                throw new NotValidEntityEntityException("Дата початку більше за дату закінчення");

            if (socialBenefit.Sum == 0)
                throw new NotValidEntityEntityException("Не заповнена сума");
        }

        public bool IsExistsPeriodIntersection(ListSocialBenefit socialBenefit, IEnumerable<ListSocialBenefit> socialBenefits)
        {
            if (socialBenefit == null) throw new ArgumentNullException(nameof(socialBenefit));
            if (socialBenefits == null) throw new ArgumentNullException(nameof(socialBenefits));

            var checkPeriodBegin = socialBenefit.PeriodBegin ?? DateTime.MinValue;
            var checkPeriodEnd = socialBenefit.PeriodEnd ?? DateTime.MaxValue;

            foreach (var entity in socialBenefits)
            {
                if (entity.Id == socialBenefit.Id)
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