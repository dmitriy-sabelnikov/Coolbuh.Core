using System;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Карточка работника. Статус
    /// </summary>
    public class EmployeeCardStatus
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор карточки работника
        /// </summary>
        public int EmployeeCardId { get; set; }

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

        /// <inheritdoc cref="Models.EmployeeCard"/>
        public virtual EmployeeCard EmployeeCard { get; set; }

        /// <inheritdoc cref="ListCardStatusType"/>
        public virtual ListCardStatusType CardStatusType { get; set; }
    }
}
