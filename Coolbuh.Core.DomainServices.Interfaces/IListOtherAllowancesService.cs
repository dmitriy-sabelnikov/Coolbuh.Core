using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис cправочника "Другие надбавки"
    /// </summary>
    public interface IListOtherAllowancesService
    {
        /// <summary>
        /// Валидация другой надбавки
        /// </summary>
        /// <param name="otherAllowance">Другая надбавка</param>
        void ValidationEntity(ListOtherAllowance otherAllowance);
    }
}