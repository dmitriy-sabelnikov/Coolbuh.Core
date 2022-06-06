using System;

namespace Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto
{
    /// <summary>
    /// DTO "Минимальные зарплаты"
    /// </summary>
    public class ListMinimumSalaryDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Период. Начало
        /// </summary>
        public DateTime? PeriodBegin { get; set; }

        /// <summary>
        /// Период. Конец
        /// </summary>
        public DateTime? PeriodEnd { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Sum { get; set; }
    }
}
