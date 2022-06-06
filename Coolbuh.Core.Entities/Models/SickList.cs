﻿using System;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Больничный лист
    /// </summary>
    public class SickList
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
        /// Дни, оплачиваемые предприятием
        /// </summary>
        public int EnterpriseDays { get; set; }

        /// <summary>
        /// Сумма, оплачиваемая предприятием
        /// </summary>
        public decimal EnterpriseSum { get; set; }

        /// <summary>
        /// Дни, оплачиваемые соцстрахом
        /// </summary>
        public int SocialInsuranceDays { get; set; }

        /// <summary>
        /// Сумма, оплачиваемая соцстрахом
        /// </summary>
        public decimal SocialInsuranceSum { get; set; }

        ///<inheritdoc cref="Models.EmployeeCard"/>
        public virtual EmployeeCard EmployeeCard { get; set; }

        ///<inheritdoc cref="ListDepartment"/>
        public virtual ListDepartment Department { get; set; }
    }
}