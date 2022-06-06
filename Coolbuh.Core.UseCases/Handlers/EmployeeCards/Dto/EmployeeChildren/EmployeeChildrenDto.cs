using System;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeChildren
{
    /// <summary>
    /// DTO "Дети"
    /// </summary>
    public class EmployeeChildrenDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор
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