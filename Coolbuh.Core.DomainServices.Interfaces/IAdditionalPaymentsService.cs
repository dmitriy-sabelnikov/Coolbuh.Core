using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис "Дополнительные выплаты"
    /// </summary>
    public interface IAdditionalPaymentsService
    {
        /// <summary>
        /// Валидация дополнительной выплаты
        /// </summary>
        /// <param name="additionalPayment">Дополнительная выплата</param>
        void ValidationEntity(AdditionalPayment additionalPayment);
    }
}
