using Coolbuh.Core.Entities.Models;
using System.Collections.Generic;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис cправочника "Прожиточные минимумы"
    /// </summary>
    public interface IListLivingWagesService
    {
        /// <summary>
        /// Валидация справочника "Прожиточный минимум"
        /// </summary>
        /// <param name="livingWage">Прожиточный минимум</param>
        void ValidationEntity(ListLivingWage livingWage);

        /// <summary>
        /// Поиск пересечения 
        /// </summary>
        /// <param name="livingWage">Прожиточный минимум</param>
        /// <param name="livingWages">Список прожиточных минимумов, с которыми ищется пересечение</param>
        /// <returns>Да/нет</returns>
        bool IsExistsPeriodIntersection(ListLivingWage livingWage, IEnumerable<ListLivingWage> livingWages);
    }
}
