using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис "Отпуска"
    /// </summary>
    public interface IVocationsService
    {
        /// <summary>
        /// Валидация отпуска
        /// </summary>
        /// <param name="vocation">Отпуск</param>
        void ValidationEntity(Vocation vocation);
    }
}
