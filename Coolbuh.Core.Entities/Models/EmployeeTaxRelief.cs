using System;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Карточка работника. Налоговая льгота
    /// </summary>
    public class EmployeeTaxRelief
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
        /// Коэффициент льготы
        /// </summary>
        public decimal Сoefficient { get; set; }

        /// <inheritdoc cref="Models.EmployeeCard"/>
        public virtual EmployeeCard EmployeeCard { get; set; }
    }
}
