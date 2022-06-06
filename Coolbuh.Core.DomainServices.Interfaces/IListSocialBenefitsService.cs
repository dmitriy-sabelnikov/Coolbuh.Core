using Coolbuh.Core.Entities.Models;
using System.Collections.Generic;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис cправочника "Социальные льготы"
    /// </summary>
    public interface IListSocialBenefitsService
    {
        /// <summary>
        /// Валидация социальной льготы
        /// </summary>
        /// <param name="socialBenefit">Социальная льгота</param>
        void ValidationEntity(ListSocialBenefit socialBenefit);

        /// <summary>
        /// Поиск пересечения
        /// </summary>
        /// <param name="socialBenefit">Социальная льгота</param>
        /// <param name="socialBenefits">Список социальных льгот с которыми ищется пересечение</param>
        /// <returns>Да/нет</returns>
        bool IsExistsPeriodIntersection(ListSocialBenefit socialBenefit, IEnumerable<ListSocialBenefit> socialBenefits);
    }
}