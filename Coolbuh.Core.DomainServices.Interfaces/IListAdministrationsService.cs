using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис cправочника "Администрации"
    /// </summary>
    public interface IListAdministrationsService
    {
        /// <summary>
        /// Валидация администрации
        /// </summary>
        /// <param name="administration">Администрация</param>
        void ValidationEntity(ListAdministration administration);
    }
}