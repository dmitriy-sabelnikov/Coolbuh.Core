namespace Coolbuh.Core.UseCases.Handlers.ConsolidateReports.Dto
{
    /// <summary>
    /// DTO обновления "Каталог объединенной ведомости"
    /// </summary>
    public class UpdateConsolidateReportCatalogDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Не рассчитывать
        /// </summary>
        public bool IsNoCalculate { get; set; }

        /// <summary>
        /// Спрашивать о расчете
        /// </summary>
        public bool IsAskAboutCalculate { get; set; }

        /// <summary>
        /// Рассчитывать
        /// </summary>
        public bool IsCalculate { get; set; }
    }
}