using System;

namespace Coolbuh.Core.UseCases.Handlers.ListLivingWages.Dto
{
    /// <summary>
    /// DTO создания "Прожиточные минимумы"
    /// </summary>
    public class CreateListLivingWageDto
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
