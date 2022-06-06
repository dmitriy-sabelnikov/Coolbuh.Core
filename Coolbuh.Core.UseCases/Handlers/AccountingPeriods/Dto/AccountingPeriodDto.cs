namespace Coolbuh.Core.UseCases.Handlers.AccountingPeriods.Dto
{
    /// <summary>
    /// DTO "Отчетный период"
    /// </summary>
    public class AccountingPeriodDto
    {
        /// <summary>
        /// Год
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Месяц
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Caption { get; set; }
    }
}
