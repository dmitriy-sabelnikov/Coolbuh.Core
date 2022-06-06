using System;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeDisability
{
    /// <summary>
    /// DTO создания "Инвалидность"
    /// </summary>
    public class CreateEmployeeDisabilityDto
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
        /// Тип инвалидности
        /// </summary>
        public int Type { get; set; }
    }
}
