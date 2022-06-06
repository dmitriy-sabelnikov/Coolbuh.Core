using Coolbuh.Core.Entities.Models;
using System.Collections.Generic;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис cправочника "Минимальные зарплаты"
    /// </summary>
    public interface IListMinimumSalariesService
    {
        /// <summary>
        /// Валидация минимальной зарплаты
        /// </summary>
        /// <param name="minimumSalary">Минимальная зарплата</param>
        void ValidationEntity(ListMinimumSalary minimumSalary);

        /// <summary>
        /// Поиск пересечения 
        /// </summary>
        /// <param name="minimumSalary">Минимальная зарплата</param>
        /// <param name="minimumSalaries">Список минимальных зарплат с которыми ищется пересечение</param>
        /// <returns>Да/нет</returns>
        bool IsExistsPeriodIntersection(ListMinimumSalary minimumSalary, IEnumerable<ListMinimumSalary> minimumSalaries);
    }
}
