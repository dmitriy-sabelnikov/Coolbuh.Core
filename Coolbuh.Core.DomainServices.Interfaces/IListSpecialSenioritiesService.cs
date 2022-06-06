using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис cправочника "Спецстажи"
    /// </summary>
    public interface IListSpecialSenioritiesService
    {
        /// <summary>
        /// Валидация спецстажа
        /// </summary>
        /// <param name="specialSeniority">Спецстаж</param>
        void ValidationEntity(ListSpecialSeniority specialSeniority);
    }
}