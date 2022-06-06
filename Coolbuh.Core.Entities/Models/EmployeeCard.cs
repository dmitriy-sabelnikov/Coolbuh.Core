using Coolbuh.Core.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.Entities.Models
{
    /// <summary>
    /// Карточка работника
    /// </summary>
    public class EmployeeCard
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string TaxIdentificationNumber { get; set; }

        /// <summary>
        /// Стаж
        /// </summary>
        public int? Seniority { get; set; }

        /// <summary>
        /// Классность
        /// </summary>
        public int? Grade { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Дата прийома на работу
        /// </summary>
        public DateTime? EntryDate { get; set; }

        /// <summary>
        /// Дата увольнения
        /// </summary>
        public DateTime? DismissalDate { get; set; }

        /// <summary>
        /// Дата выхода на пенсию
        /// </summary>
        public DateTime? PensionDate { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public EmployeeCardSex Sex { get; set; }

        /// <summary>
        /// Список детей
        /// </summary>
        public virtual List<EmployeeChildren> EmployeeChildren { get; set; }

        /// <summary>
        /// Список налоговых льгот
        /// </summary>
        public virtual List<EmployeeTaxRelief> EmployeeTaxReliefs { get; set; }

        /// <summary>
        /// Список статусов
        /// </summary>
        public virtual List<EmployeeCardStatus> EmployeeCardStatuses { get; set; }

        /// <summary>
        /// Список инвалидностей
        /// </summary>
        public virtual List<EmployeeDisability> EmployeeDisabilities { get; set; }

        /// <summary>
        /// Список спецстажей
        /// </summary>
        public virtual List<EmployeeSpecialSeniority> EmployeeSpecialSeniorities { get; set; }

        /// <summary>
        /// Список отпусков
        /// </summary>
        public virtual List<Vocation> Vocations { get; set; }

        /// <summary>
        /// Список больничных листов
        /// </summary>
        public virtual List<SickList> SickLists { get; set; }

        /// <summary>
        /// Список договоров ГПХ
        /// </summary>
        public virtual List<CivilLawContract> CivilLawContracts { get; set; }

        /// <summary>
        /// Список дополнительных начислений
        /// </summary>
        public virtual List<AdditionalAccrual> AdditionalAccruals { get; set; }

        /// <summary>
        /// Список выплат
        /// </summary>
        public virtual List<Payment> Payments { get; set; }

        /// <summary>
        /// Список дополнительных выплат
        /// </summary>
        public virtual List<AdditionalPayment> AdditionalPayments { get; set; }

        /// <summary>
        /// Список зарплат
        /// </summary>
        public virtual List<Salary> Salaries { get; set; }
    }
}