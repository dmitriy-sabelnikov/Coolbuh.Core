using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис cправочника "Надбавки за классность"
    /// </summary>
    public interface IListGradeAllowancesService
    {
        /// <summary>
        /// Валидация надбавки за классность
        /// </summary>
        /// <param name="gradeAllowance">Надбавка за классность</param>
        void ValidationEntity(ListGradeAllowance gradeAllowance);
    }
}