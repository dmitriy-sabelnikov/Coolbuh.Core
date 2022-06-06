using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис "Карточки работников"
    /// </summary>
    public interface IEmployeeCardsService
    {
        /// <summary>
        /// Валидация карточки работника 
        /// </summary>
        /// <param name="employeeCard">Карточка работника</param>
        void ValidationEntity(EmployeeCard employeeCard);
    }
}