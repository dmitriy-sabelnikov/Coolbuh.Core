using System;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeChildren
{
    /// <summary>
    /// DTO создания "Дети"
    /// </summary>
    public class CreateEmployeeChildrenDto
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
        /// Количество детей
        /// </summary>
        public int Number { get; set; }
    }
}
