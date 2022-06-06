using Coolbuh.Core.Entities.Models;

namespace Coolbuh.Core.DomainServices.Interfaces
{
    /// <summary>
    /// Доменный сервис cправочника "Каталог объединенной ведомости"
    /// </summary>
    public interface IConsolidateReportsService
    {
        /// <summary>
        /// Валидация каталога объединенной ведомости 
        /// </summary>
        /// <param name="сonsolidateReportCatalog">Каталог объединенной ведомости</param>
        void ValidationEntity(ConsolidateReportCatalog сonsolidateReportCatalog);
    }
}