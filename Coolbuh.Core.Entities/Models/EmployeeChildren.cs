using System;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Карточка работника. Дети
    /// </summary>
    public class EmployeeChildren
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
        /// Количество детей
        /// </summary>
        public int Number { get; set; }

        /// <inheritdoc cref="Models.EmployeeCard"/>
        public virtual EmployeeCard EmployeeCard { get; set; }
    }
}
