using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис "Дополнительные начисления"
    /// </summary>
    public interface IAdditionalAccrualsService
    {
        /// <summary>
        /// Валидация дополнительного начисления
        /// </summary>
        /// <param name="additionalAccrual">Дополнительное начисления</param>
        void ValidationEntity(AdditionalAccrual additionalAccrual);
    }
}
