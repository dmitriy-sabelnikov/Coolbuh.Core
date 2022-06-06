using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис cправочника "Типы дополнительных начислений"
    /// </summary>
    public interface IListAdditionalAccrualTypesService
    {
        /// <summary>
        /// Валидация типа дополнительных начислений
        /// </summary>
        /// <param name="additionalAccrualType">Тип дополнительных начислений</param>
        void ValidationEntity(ListAdditionalAccrualType additionalAccrualType);
    }
}