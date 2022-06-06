using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис "Больничные листы"
    /// </summary>
    public interface ISickListsService
    {
        /// <summary>
        /// Валидация больничного листа
        /// </summary>
        /// <param name="sickList">Больничный лист</param>
        void ValidationEntity(SickList sickList);
    }
}
