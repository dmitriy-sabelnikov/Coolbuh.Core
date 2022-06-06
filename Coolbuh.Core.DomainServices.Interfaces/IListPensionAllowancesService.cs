using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис cправочника "Надбавки за пенсию"
    /// </summary>
    public interface IListPensionAllowancesService
    {
        /// <summary>
        /// Валидация надбавки за пенсию
        /// </summary>
        /// <param name="pensionAllowance">Надбавка за пенсию</param>
        void ValidationEntity(ListPensionAllowance pensionAllowance);
    }
}