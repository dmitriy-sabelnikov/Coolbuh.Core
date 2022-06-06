using System;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCardStatus
{
    /// <summary>
    /// DTO обновления "Статус"
    /// </summary>
    public class UpdateEmployeeCardStatusDto
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
        /// Идентификатор типа статуса
        /// </summary>
        public int CardStatusTypeId { get; set; }
    }
}
