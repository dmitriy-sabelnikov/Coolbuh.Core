using System;

namespace Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto
{
    /// <summary>
    /// DTO обновления "Минимальные зарплаты"
    /// </summary>
    public class UpdateListMinimumSalaryDto
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
