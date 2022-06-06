using System;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeSpecialSeniority
{
    /// <summary>
    /// DTO создания "Спецстаж"
    /// </summary>
    public class CreateEmployeeSpecialSeniorityDto
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
        /// Идентификатор типа спецстажа
        /// </summary>
        public int SpecialSeniorityId { get; set; }
    }
}
