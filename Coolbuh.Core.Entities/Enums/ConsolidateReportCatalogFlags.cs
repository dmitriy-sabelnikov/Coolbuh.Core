namespace Coolbuh.Core.Entities.Enums
{
    /// <summary>
    /// Флаги каталога объединенной ведомости 
    /// </summary>
    public enum ConsolidateReportCatalogFlags
    {
        /// <summary>
        /// Не рассчитывать
        /// </summary>
        IsNoCalculate = 0x01,

        /// <summary>
        /// Спрашивать о расчете
        /// </summary>
        IsAskAboutCalculate = 0x02,

        /// <summary>
        /// Рассчитывать
        /// </summary>
        IsCalculate = 0x04
    }
}