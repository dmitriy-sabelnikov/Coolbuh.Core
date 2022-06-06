using System;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeSpecialSeniority
{
    /// <summary>
    /// DTO обновления "Спецстаж"
    /// </summary>
    public class UpdateEmployeeSpecialSeniorityDto
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
        /// Идентификатор типа спецстажа
        /// </summary>
        public int SpecialSeniorityId { get; set; }
    }
}
