namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Отчетный период
    /// </summary>
    public class AccountingPeriod
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
