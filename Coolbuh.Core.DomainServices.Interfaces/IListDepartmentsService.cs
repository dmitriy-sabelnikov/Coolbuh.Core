using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис cправочника "Подразделения"
    /// </summary>
    public interface IListDepartmentsService
    {
        /// <summary>
        /// Валидация подразделения
        /// </summary>
        /// <param name="department">Подразделение</param>
        void ValidationEntity(ListDepartment department);
    }
}