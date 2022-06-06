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
    /// DTO "Карточка работника"
    /// </summary>
    public class EmployeeCardDto
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
        /// DTO "Дети"
        /// </summary>
        public List<EmployeeChildrenDto> EmployeeChildren { get; set; }

        /// <summary>
        /// DTO "Налоговые льготы"
        /// </summary>
        public List<EmployeeTaxReliefDto> EmployeeTaxReliefs { get; set; }

        /// <summary>
        /// DTO "Статусы"
        /// </summary>
        public List<EmployeeCardStatusDto> EmployeeCardStatuses { get; set; }

        /// <summary>
        /// DTO "Инвалидности"
        /// </summary>
        public List<EmployeeDisabilityDto> EmployeeDisabilities { get; set; }

        /// <summary>
        /// DTO "Спецстажи"
        /// </summary>
        public List<EmployeeSpecialSeniorityDto> EmployeeSpecialSeniorities { get; set; }
    }
}