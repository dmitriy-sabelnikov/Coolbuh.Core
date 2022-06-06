using System;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Договор ГПХ
    /// </summary>
    public class CivilLawContract
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
        /// Идентификатор подразделения
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Отчетный период
        /// </summary>
        public DateTime AccountingPeriod { get; set; }

        /// <summary>
        /// Период, за который проводится начисление
        /// </summary>
        public DateTime AccrualPeriod { get; set; }

        /// <summary>
        /// Дни
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Sum { get; set; }

        /// <inheritdoc cref="Models.EmployeeCard"/>
        public virtual EmployeeCard EmployeeCard { get; set; }

        /// <inheritdoc cref="ListDepartment"/>
        public virtual ListDepartment Department { get; set; }
    }
}
