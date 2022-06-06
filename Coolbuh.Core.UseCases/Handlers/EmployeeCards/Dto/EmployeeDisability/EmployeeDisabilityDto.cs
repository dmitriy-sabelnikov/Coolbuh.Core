using System;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeDisability
{
    /// <summary>
    /// DTO "Инвалидность"
    /// </summary>
    public class EmployeeDisabilityDto
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
        /// Тип инвалидности
        /// </summary>
        public int Type { get; set; }
    }
}