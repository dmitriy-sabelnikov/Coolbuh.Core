using System;

namespace Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto
{
    /// <summary>
    /// DTO создания "Минимальные зарплаты"
    /// </summary>
    public class CreateListMinimumSalaryDto
    {
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
