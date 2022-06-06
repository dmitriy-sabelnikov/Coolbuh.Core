using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис "Выплаты"
    /// </summary>
    public interface IPaymentsService
    {
        /// <summary>
        /// Валидация "Выплаты"
        /// </summary>
        /// <param name="payment">Выплата</param>
        void ValidationEntity(Payment payment);
    }
}
