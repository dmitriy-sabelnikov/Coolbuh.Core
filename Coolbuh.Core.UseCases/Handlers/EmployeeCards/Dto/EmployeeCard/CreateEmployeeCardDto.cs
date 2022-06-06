using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCardStatus;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeChildren;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeDisability;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeSpecialSeniority;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeTaxRelief;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard
{
    /// <summary>
    /// DTO создания "Карточка работника"
    /// </summary>
    public class CreateEmployeeCardDto
    {
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
        /// DTO создания "Дети"
        /// </summary>
        public List<CreateEmployeeChildrenDto> EmployeeChildren { get; set; }

        /// <summary>
        /// DTO создания "Налоговые льготы"
        /// </summary>
        public List<CreateEmployeeTaxReliefDto> EmployeeTaxReliefs { get; set; }

        /// <summary>
        /// DTO создания "Статус"
        /// </summary>
        public List<CreateEmployeeCardStatusDto> EmployeeCardStatuses { get; set; }

        /// <summary>
        /// DTO создания "Инвалидность"
        /// </summary>
        public List<CreateEmployeeDisabilityDto> EmployeeDisabilities { get; set; }

        /// <summary>
        /// DTO создания "Спецстаж"
        /// </summary>
        public List<CreateEmployeeSpecialSeniorityDto> EmployeeSpecialSeniorities { get; set; }
    }
}
