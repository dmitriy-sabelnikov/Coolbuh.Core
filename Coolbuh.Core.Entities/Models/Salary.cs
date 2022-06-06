using System;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Зарплата
    /// </summary>
    public class Salary
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
        /// Отработанные дни
        /// </summary>
        public int Days { get; set; }

        /// <summary>
        /// Отработанные часы
        /// </summary>
        public decimal Hours { get; set; }

        /// <summary>
        /// Базовая сумма(ставка)
        /// </summary>
        public decimal BaseSum { get; set; }

        /// <summary>
        /// Идентификатор надбавки пенсионеру
        /// </summary>
        public int? PensionAllowanceId { get; set; }

        /// <summary>
        /// Сумма надбавки пенсионеру
        /// </summary>
        public decimal PensionAllowanceSum { get; set; }

        /// <summary>
        /// Идентификатор надбавки за классность
        /// </summary>
        public int? GradeAllowanceId { get; set; }

        /// <summary>
        /// Сумма надбавки за классность
        /// </summary>
        public decimal GradeAllowanceSum { get; set; }

        /// <summary>
        /// Идентификатор других надбавки 
        /// </summary>
        public int? OtherAllowanceId { get; set; }

        /// <summary>
        /// Сумма другой надбавки
        /// </summary>
        public decimal OtherAllowanceSum { get; set; }

        /// <summary>
        /// Итоговая сумма
        /// </summary>
        public decimal TotalSum { get; set; }

        ///<inheritdoc cref="Models.EmployeeCard"/>
        public virtual EmployeeCard EmployeeCard { get; set; }

        ///<inheritdoc cref="ListDepartment"/>
        public virtual ListDepartment Department { get; set; }

        ///<inheritdoc cref="ListPensionAllowance"/>
        public virtual ListPensionAllowance PensionAllowance { get; set; }

        ///<inheritdoc cref="ListGradeAllowance"/>
        public virtual ListGradeAllowance GradeAllowance { get; set; }

        ///<inheritdoc cref="ListOtherAllowance"/>
        public virtual ListOtherAllowance OtherAllowance { get; set; }
    }
}
