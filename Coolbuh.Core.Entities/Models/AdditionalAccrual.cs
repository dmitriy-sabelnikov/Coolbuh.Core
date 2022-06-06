using System;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Дополнительное начисление
    /// </summary>
    public class AdditionalAccrual
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
        /// Идентификатор типа начисления
        /// </summary>
        public int AdditionalAccrualTypeId { get; set; }

        /// <summary>
        /// Сумма начисления
        /// </summary>
        public decimal Sum { get; set; }

        /// <inheritdoc cref="Models.EmployeeCard"/>
        public virtual EmployeeCard EmployeeCard { get; set; }

        /// <inheritdoc cref="ListDepartment"/>
        public virtual ListDepartment Department { get; set; }

        /// <inheritdoc cref="ListAdditionalAccrualType"/>
        public virtual ListAdditionalAccrualType AdditionalAccrualType { get; set; }
    }
}
