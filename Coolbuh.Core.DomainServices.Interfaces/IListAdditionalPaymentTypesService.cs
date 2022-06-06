using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис cправочника "Типы дополнительных выплат"
    /// </summary>
    public interface IListAdditionalPaymentTypesService
    {
        /// <summary>
        /// Валидация типа дополнительных выплат
        /// </summary>
        /// <param name="additionalPaymentType">Тип дополнительных выплат</param>
        void ValidationEntity(ListAdditionalPaymentType additionalPaymentType);
    }
}