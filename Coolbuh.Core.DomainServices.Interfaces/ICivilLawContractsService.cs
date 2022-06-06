using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис "Договора ГПХ"
    /// </summary>
    public interface ICivilLawContractsService
    {
        /// <summary>
        /// Валидация договора ГПХ
        /// </summary>
        /// <param name="civilLawContract">Договор ГПХ</param>
        void ValidationEntity(CivilLawContract civilLawContract);
    }
}
