using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCardStatus;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeChildren;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeDisability;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeSpecialSeniority;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeTaxRelief;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Extensions
{
    /// <summary>
    /// Методы расширения карточки работника
    /// </summary>
    public static class EmployeeCardExtension
    {
        /// <summary>
        /// Маппинг карточки работника
        /// </summary>
        /// <param name="dto">DTO создания "Карточка работника"</param>
        /// <returns>Карточка работника</returns>
        public static EmployeeCard MapEmployeeCard(this CreateEmployeeCardDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            List<EmployeeChildren> employeeChildren = dto.EmployeeChildren != null 
                ? dto.EmployeeChildren.MapEmployeeChildren()
                : null;

            List<EmployeeTaxRelief> employeeTaxReliefs = dto.EmployeeTaxReliefs != null
                ? dto.EmployeeTaxReliefs.MapEmployeeTaxRelief()
                : null; 

            List<EmployeeCardStatus> employeeCardStatuses = dto.EmployeeCardStatuses != null
                ? dto.EmployeeCardStatuses.MapEmployeeCardStatus() 
                : null;

            List<EmployeeDisability> employeeDisabilities = dto.EmployeeDisabilities != null
                ? dto.EmployeeDisabilities.MapEmployeeDisability()
                : null;

            List<EmployeeSpecialSeniority> employeeSpecialSeniorities = dto.EmployeeSpecialSeniorities != null
                ? dto.EmployeeSpecialSeniorities.MapEmployeeSpecialSeniority()
                : null;

            return new EmployeeCard
            {
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                TaxIdentificationNumber = dto.TaxIdentificationNumber,
                Seniority = dto.Seniority,
                Grade = dto.Grade,
                BirthDate = dto.BirthDate,
                EntryDate = dto.EntryDate,
                DismissalDate = dto.DismissalDate,
                PensionDate = dto.PensionDate,
                Sex = dto.Sex,
                EmployeeChildren = employeeChildren,
                EmployeeTaxReliefs = employeeTaxReliefs,
                EmployeeCardStatuses = employeeCardStatuses,
                EmployeeDisabilities = employeeDisabilities,
                EmployeeSpecialSeniorities = employeeSpecialSeniorities
            };
        }

        /// <summary>
        /// Маппинг карточки работника
        /// </summary>
        /// <param name="dto">DTO обновления "Карточка работника"</param>
        /// <returns>Карточка работника</returns>
        public static EmployeeCard MapEmployeeCard(this UpdateEmployeeCardDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            List<EmployeeChildren> employeeChildren = dto.EmployeeChildren != null 
                ? dto.EmployeeChildren.MapEmployeeChildren(dto.Id) : null;

            List<EmployeeTaxRelief> employeeTaxReliefs = dto.EmployeeTaxReliefs != null
                ? dto.EmployeeTaxReliefs.MapEmployeeTaxRelief(dto.Id) : null;

            List<EmployeeCardStatus> employeeCardStatuses = dto.EmployeeCardStatuses != null
                ? dto.EmployeeCardStatuses.MapEmployeeCardStatus(dto.Id)
                : null;
            
            List<EmployeeDisability> employeeDisabilities = dto.EmployeeDisabilities != null
                ? dto.EmployeeDisabilities.MapEmployeeDisability(dto.Id)
                : null;

            List<EmployeeSpecialSeniority> employeeSpecialSeniorities = dto.EmployeeSpecialSeniorities != null
                ? dto.EmployeeSpecialSeniorities.MapEmployeeSpecialSeniority(dto.Id)
                : null;

            return new EmployeeCard
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                MiddleName = dto.MiddleName,
                LastName = dto.LastName,
                TaxIdentificationNumber = dto.TaxIdentificationNumber,
                Seniority = dto.Seniority,
                Grade = dto.Grade,
                BirthDate = dto.BirthDate,
                EntryDate = dto.EntryDate,
                DismissalDate = dto.DismissalDate,
                PensionDate = dto.PensionDate,
                Sex = dto.Sex,
                EmployeeChildren = employeeChildren,
                EmployeeTaxReliefs = employeeTaxReliefs,
                EmployeeCardStatuses = employeeCardStatuses,
                EmployeeDisabilities = employeeDisabilities,
                EmployeeSpecialSeniorities = employeeSpecialSeniorities
            };
        }

        /// <summary>
        /// Маппинг ребенка работника 
        /// </summary>
        /// <param name="dto">DTO создания "Дети"</param>
        /// <returns>Ребенок работника</returns>
        public static EmployeeChildren MapEmployeeChildren(this CreateEmployeeChildrenDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new EmployeeChildren
            { 
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Number = dto.Number
            };
        }

        /// <summary>
        /// Маппинг детей работника 
        /// </summary>
        /// <param name="dtos">Список DTO обновления "Дети"</param>
        /// <returns>Список детей работника</returns>
        public static List<EmployeeChildren> MapEmployeeChildren(this List<CreateEmployeeChildrenDto> dtos)
        {
            if (dtos == null)
                throw new ArgumentNullException(nameof(dtos));

            var children = new List<EmployeeChildren>();

            foreach (var dto in dtos)
                children.Add(dto.MapEmployeeChildren());

            return children;
        }

        /// <summary>
        /// Маппинг ребенка работника 
        /// </summary>
        /// <param name="dto">DTO обновления "Дети"</param>
        /// <param name="employeeCardId">Идентификатор карточки работника</param> 
        /// <returns>Ребенок работника</returns>
        public static EmployeeChildren MapEmployeeChildren(this UpdateEmployeeChildrenDto dto, int employeeCardId)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new EmployeeChildren
            {
                Id = dto.Id,
                EmployeeCardId = employeeCardId,
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Number = dto.Number
            };
        }

        /// <summary>
        /// Маппинг детей работника 
        /// </summary>
        /// <param name="dtos">Список DTO обновления "Дети"</param>
        /// <param name="employeeCardId">Идентификатор карточки работника</param> 
        /// <returns>Список детей работника</returns>
        public static List<EmployeeChildren> MapEmployeeChildren(this List<UpdateEmployeeChildrenDto> dtos, int employeeCardId)
        {
            if (dtos == null)
                throw new ArgumentNullException(nameof(dtos));

            var children = new List<EmployeeChildren>();

            foreach (var dto in dtos)
                children.Add(dto.MapEmployeeChildren(employeeCardId));

            return children;
        }

        /// <summary>
        /// Маппинг ребенка работника 
        /// </summary>
        /// <param name="child">Ребенок работника</param>
        /// <returns>DTO "Дети"</returns>
        public static EmployeeChildrenDto MapEmployeeChildren(this EmployeeChildren child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));

            return new EmployeeChildrenDto
            {
                Id = child.Id,
                PeriodBegin = child.PeriodBegin,
                PeriodEnd = child.PeriodEnd,
                Number = child.Number
            };
        }

        /// <summary>
        /// Маппинг детей работника 
        /// </summary>
        /// <param name="children">Список детей работника</param>
        /// <returns>Список DTO "Дети"</returns>
        public static List<EmployeeChildrenDto> MapEmployeeChildren(this List<EmployeeChildren> children)
        {
            if (children == null)
                throw new ArgumentNullException(nameof(children));

            var dtos = new List<EmployeeChildrenDto>();

            foreach (var child in children)
                dtos.Add(child.MapEmployeeChildren());

            return dtos;
        }

        /// <summary>
        /// Маппинг налоговой льготы
        /// </summary>
        /// <param name="dto">DTO создания "Налоговая льгота"</param>
        /// <returns>Налоговая льгота</returns>
        public static EmployeeTaxRelief MapEmployeeTaxRelief(this CreateEmployeeTaxReliefDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new EmployeeTaxRelief
            {
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Сoefficient = dto.Сoefficient
            };
        }

        /// <summary>
        /// Маппинг налоговых льгот работника 
        /// </summary>
        /// <param name="dtos">Список DTO обновления "Налоговые льготы"</param>
        /// <returns>Список налоговых льгот</returns>
        public static List<EmployeeTaxRelief> MapEmployeeTaxRelief(this List<CreateEmployeeTaxReliefDto> dtos)
        {
            if (dtos == null)
                throw new ArgumentNullException(nameof(dtos));

            var taxReliefs = new List<EmployeeTaxRelief>();

            foreach (var dto in dtos)
                taxReliefs.Add(dto.MapEmployeeTaxRelief());

            return taxReliefs;
        }

        /// <summary>
        /// Маппинг налоговой льготы
        /// </summary>
        /// <param name="dto">DTO обновления "Налоговая льгота"</param>
        /// <param name="employeeCardId">Идентификатор карточки работника</param>
        /// <returns>Налоговая льгота</returns>
        public static EmployeeTaxRelief MapEmployeeTaxRelief(this UpdateEmployeeTaxReliefDto dto, int employeeCardId)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new EmployeeTaxRelief
            {
                Id = dto.Id,
                EmployeeCardId = employeeCardId,
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Сoefficient = dto.Сoefficient
            };
        }

        /// <summary>
        /// Маппинг налоговых льгот работника 
        /// </summary>
        /// <param name="dtos">Список DTO обновления "Налоговые льготы"</param>
        /// <param name="employeeCardId">Идентификатор карточки работника</param>
        /// <returns>Список налоговых льгот</returns>
        public static List<EmployeeTaxRelief> MapEmployeeTaxRelief(this List<UpdateEmployeeTaxReliefDto> dtos, int employeeCardId)
        {
            if (dtos == null)
                throw new ArgumentNullException(nameof(dtos));

            var taxReliefs = new List<EmployeeTaxRelief>();

            foreach (var dto in dtos)
                taxReliefs.Add(dto.MapEmployeeTaxRelief(employeeCardId));

            return taxReliefs;
        }

        /// <summary>
        /// Маппинг налоговой льготы
        /// </summary>
        /// <param name="taxRelief">Налоговая льгота</param>
        /// <returns>DTO "Налоговая льгота"</returns>
        public static EmployeeTaxReliefDto MapEmployeeTaxRelief(this EmployeeTaxRelief taxRelief)
        {
            if (taxRelief == null) throw new ArgumentNullException(nameof(taxRelief));

            return new EmployeeTaxReliefDto
            {
                Id = taxRelief.Id,
                PeriodBegin = taxRelief.PeriodBegin,
                PeriodEnd = taxRelief.PeriodEnd,
                Сoefficient = taxRelief.Сoefficient
            };
        }

        /// <summary>
        /// Маппинг налоговых льгот
        /// </summary>
        /// <param name="taxReliefs">Список налоговых льгот</param>
        /// <returns>Список DTO "Налоговая льгота"</returns>
        public static List<EmployeeTaxReliefDto> MapEmployeeTaxRelief(this List<EmployeeTaxRelief> taxReliefs)
        {
            if (taxReliefs == null)
                throw new ArgumentNullException(nameof(taxReliefs));

            var dtos = new List<EmployeeTaxReliefDto>();

            foreach (var taxRelief in taxReliefs)
                dtos.Add(taxRelief.MapEmployeeTaxRelief());

            return dtos;
        }

        /// <summary>
        /// Маппинг статуса работника
        /// </summary>
        /// <param name="dto">DTO создания "Статус"</param>
        /// <returns>Статус работника</returns>
        public static EmployeeCardStatus MapEmployeeCardStatus(this CreateEmployeeCardStatusDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new EmployeeCardStatus
            {
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                CardStatusTypeId = dto.CardStatusTypeId
            };
        }

        /// <summary>
        /// Маппинг статусов работника
        /// </summary>
        /// <param name="dtos">Список DTO обновления "Статус"</param>
        /// <returns>Список статусов работника</returns>
        public static List<EmployeeCardStatus> MapEmployeeCardStatus(this List<CreateEmployeeCardStatusDto> dtos)
        {
            if (dtos == null)
                throw new ArgumentNullException(nameof(dtos));

            var cardStatuses = new List<EmployeeCardStatus>();

            foreach (var dto in dtos)
                cardStatuses.Add(dto.MapEmployeeCardStatus());

            return cardStatuses;
        }

        /// <summary>
        /// Маппинг статуса работника
        /// </summary>
        /// <param name="dto">DTO обновления "Статус"</param>
        /// <param name="employeeCardId">Идентификатор карточки работника</param>
        /// <returns>Статус работника</returns>
        public static EmployeeCardStatus MapEmployeeCardStatus(this UpdateEmployeeCardStatusDto dto, int employeeCardId)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new EmployeeCardStatus
            {
                Id = dto.Id,
                EmployeeCardId = employeeCardId,
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                CardStatusTypeId = dto.CardStatusTypeId
            };
        }

        /// <summary>
        /// Маппинг статусов работника
        /// </summary>
        /// <param name="dtos">Список DTO обновления "Статус"</param>
        /// <param name="employeeCardId">Идентификатор карточки работника</param>
        /// <returns>Список статусов работника</returns>
        public static List<EmployeeCardStatus> MapEmployeeCardStatus(this List<UpdateEmployeeCardStatusDto> dtos, int employeeCardId)
        {
            if (dtos == null)
                throw new ArgumentNullException(nameof(dtos));

            var cardStatuses = new List<EmployeeCardStatus>();

            foreach (var dto in dtos)
                cardStatuses.Add(dto.MapEmployeeCardStatus(employeeCardId));

            return cardStatuses;
        }

        /// <summary>
        /// Маппинг статуса работника
        /// </summary>
        /// <param name="cardStatus">Статус работника</param>
        /// <returns>DTO "Статус"</returns>
        public static EmployeeCardStatusDto MapEmployeeCardStatus(this EmployeeCardStatus cardStatus)
        {
            if (cardStatus == null) throw new ArgumentNullException(nameof(cardStatus));

            return new EmployeeCardStatusDto
            {
                Id = cardStatus.Id,
                PeriodBegin = cardStatus.PeriodBegin,
                PeriodEnd = cardStatus.PeriodEnd,
                CardStatusTypeId = cardStatus.CardStatusTypeId
            };
        }

        /// <summary>
        /// Маппинг статусов работника
        /// </summary>
        /// <param name="cardStatuses">Список статусов работника</param>
        /// <returns>Список DTO "Статус"</returns>
        public static List<EmployeeCardStatusDto> MapEmployeeCardStatus(this List<EmployeeCardStatus> cardStatuses)
        {
            if (cardStatuses == null)
                throw new ArgumentNullException(nameof(cardStatuses));

            var dtos = new List<EmployeeCardStatusDto>();

            foreach (var cardStatus in cardStatuses)
                dtos.Add(cardStatus.MapEmployeeCardStatus());

            return dtos;
        }

        /// <summary>
        /// Маппинг инвалидности работника
        /// </summary>
        /// <param name="dto">DTO создания "Инвалидность"</param>
        /// <returns>Инвалидность работника</returns>
        public static EmployeeDisability MapEmployeeDisability(this CreateEmployeeDisabilityDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new EmployeeDisability
            {
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Type = dto.Type
            };
        }

        /// <summary>
        /// Маппинг инвалидностей работника
        /// </summary>
        /// <param name="dtos">Список DTO обновления "Инвалидность"</param>
        /// <returns>Список инвалидностей работника</returns>
        public static List<EmployeeDisability> MapEmployeeDisability(this List<CreateEmployeeDisabilityDto> dtos)
        {
            if (dtos == null)
                throw new ArgumentNullException(nameof(dtos));

            var disability = new List<EmployeeDisability>();

            foreach (var dto in dtos)
                disability.Add(dto.MapEmployeeDisability());

            return disability;
        }

        /// <summary>
        /// Маппинг инвалидности работника
        /// </summary>
        /// <param name="dto">DTO обновления "Инвалидность"</param>
        /// <param name="employeeCardId">Идентификатор карточки работника</param>         
        /// <returns>Инвалидность работника</returns>
        public static EmployeeDisability MapEmployeeDisability(this UpdateEmployeeDisabilityDto dto, int employeeCardId)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new EmployeeDisability
            {
                Id = dto.Id,
                EmployeeCardId = employeeCardId,
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Type = dto.Type
            };
        }

        /// <summary>
        /// Маппинг инвалидностей работника
        /// </summary>
        /// <param name="dtos">Список DTO обновления "Инвалидность"</param>
        /// <param name="employeeCardId">Идентификатор карточки работника</param> 
        /// <returns>Список инвалидностей работника</returns>
        public static List<EmployeeDisability> MapEmployeeDisability(this List<UpdateEmployeeDisabilityDto> dtos, int employeeCardId)
        {
            if (dtos == null)
                throw new ArgumentNullException(nameof(dtos));

            var disability = new List<EmployeeDisability>();

            foreach (var dto in dtos)
                disability.Add(dto.MapEmployeeDisability(employeeCardId));

            return disability;
        }

        /// <summary>
        /// Маппинг инвалидности работника
        /// </summary>
        /// <param name="disability">Инвалидность работника</param>
        /// <returns>DTO "Инвалидность"</returns>
        public static EmployeeDisabilityDto MapEmployeeDisability(this EmployeeDisability disability)
        {
            if (disability == null) throw new ArgumentNullException(nameof(disability));

            return new EmployeeDisabilityDto
            {
                Id = disability.Id,
                PeriodBegin = disability.PeriodBegin,
                PeriodEnd = disability.PeriodEnd,
                Type = disability.Type
            };
        }

        /// <summary>
        /// Маппинг инвалидностей работника
        /// </summary>
        /// <param name="disabilities">Список инвалидностей работника</param>
        /// <returns>Список DTO "Инвалидность"</returns>
        public static List<EmployeeDisabilityDto> MapEmployeeDisability(this List<EmployeeDisability> disabilities)
        {
            if (disabilities == null)
                throw new ArgumentNullException(nameof(disabilities));

            var dtos = new List<EmployeeDisabilityDto>();

            foreach (var disability in disabilities)
                dtos.Add(disability.MapEmployeeDisability());

            return dtos;
        }

        /// <summary>
        /// Маппинг спецстажа
        /// </summary>
        /// <param name="dto">DTO создания "Спецстаж"</param>
        /// <returns>Спецстаж</returns>
        public static EmployeeSpecialSeniority MapEmployeeSpecialSeniority(this CreateEmployeeSpecialSeniorityDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new EmployeeSpecialSeniority
            {
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                SpecialSeniorityId = dto.SpecialSeniorityId
            };
        }

        /// <summary>
        /// Маппинг спецстажа
        /// </summary>
        /// <param name="dtos">Список DTO обновления "Спецстаж"</param>
        /// <returns>Список спецстажей</returns>
        public static List<EmployeeSpecialSeniority> MapEmployeeSpecialSeniority(this List<CreateEmployeeSpecialSeniorityDto> dtos)
        {
            if (dtos == null)
                throw new ArgumentNullException(nameof(dtos));

            var specialSeniorities = new List<EmployeeSpecialSeniority>();

            foreach (var dto in dtos)
                specialSeniorities.Add(dto.MapEmployeeSpecialSeniority());

            return specialSeniorities;
        }

        /// <summary>
        /// Маппинг спецстажа
        /// </summary>
        /// <param name="dto">DTO обновления "Спецстаж"</param>
        /// <param name="employeeCardId">Идентификатор карточки работника</param> 
        /// <returns>Спецстаж</returns>
        public static EmployeeSpecialSeniority MapEmployeeSpecialSeniority(this UpdateEmployeeSpecialSeniorityDto dto, int employeeCardId)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new EmployeeSpecialSeniority
            {
                Id = dto.Id,
                EmployeeCardId = employeeCardId,
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                SpecialSeniorityId = dto.SpecialSeniorityId
            };
        }

        /// <summary>
        /// Маппинг спецстажа
        /// </summary>
        /// <param name="dtos">Список DTO обновления "Спецстаж"</param>
        /// <param name="employeeCardId">Идентификатор карточки работника</param> 
        /// <returns>Список спецстажей</returns>
        public static List<EmployeeSpecialSeniority> MapEmployeeSpecialSeniority(this List<UpdateEmployeeSpecialSeniorityDto> dtos, int employeeCardId)
        {
            if (dtos == null)
                throw new ArgumentNullException(nameof(dtos));

            var specialSeniorities = new List<EmployeeSpecialSeniority>();

            foreach (var dto in dtos)
                specialSeniorities.Add(dto.MapEmployeeSpecialSeniority(employeeCardId));

            return specialSeniorities;
        }

        /// <summary>
        /// Маппинг спецстажа
        /// </summary>
        /// <param name="specialSeniority">Спецстаж</param>
        /// <returns>DTO "Спецстаж"</returns>
        public static EmployeeSpecialSeniorityDto MapEmployeeSpecialSeniority(this EmployeeSpecialSeniority specialSeniority)
        {
            if (specialSeniority == null) throw new ArgumentNullException(nameof(specialSeniority));

            return new EmployeeSpecialSeniorityDto
            {
                Id = specialSeniority.Id,
                PeriodBegin = specialSeniority.PeriodBegin,
                PeriodEnd = specialSeniority.PeriodEnd,
                SpecialSeniorityId = specialSeniority.SpecialSeniorityId
            };
        }

        /// <summary>
        /// Маппинг спецстажей работника
        /// </summary>
        /// <param name="specialSeniorities">Список спецстажей</param>
        /// <returns>Список DTO "Спецстаж"</returns>
        public static List<EmployeeSpecialSeniorityDto> MapEmployeeSpecialSeniority(
            this List<EmployeeSpecialSeniority> specialSeniorities)
        {
            if (specialSeniorities == null)
                throw new ArgumentNullException(nameof(specialSeniorities));

            var dtos = new List<EmployeeSpecialSeniorityDto>();

            foreach (var specialSeniority in specialSeniorities)
                dtos.Add(specialSeniority.MapEmployeeSpecialSeniority());

            return dtos;
        }

        /// <summary>
        /// Маппинг карточки работника
        /// </summary>
        /// <param name="employeeCard">Карточка работника</param>
        /// <returns>DTO "Карточка работника"</returns>
        public static EmployeeCardDto MapEmployeeCardDto(this EmployeeCard employeeCard)
        {
            if (employeeCard == null) throw new ArgumentNullException(nameof(employeeCard));

            List<EmployeeChildrenDto> employeeChildren = employeeCard.EmployeeChildren != null 
                ? employeeCard.EmployeeChildren.MapEmployeeChildren()
                : null;

            List<EmployeeCardStatusDto> employeeCardStatuses = employeeCard.EmployeeCardStatuses != null 
                ? employeeCard.EmployeeCardStatuses.MapEmployeeCardStatus()
                : null;

            List<EmployeeTaxReliefDto> employeeTaxReliefs = employeeCard.EmployeeTaxReliefs != null
                ? employeeCard.EmployeeTaxReliefs.MapEmployeeTaxRelief()
                : null;

            List<EmployeeDisabilityDto> employeeDisabilities = employeeCard.EmployeeDisabilities != null 
                ? employeeCard.EmployeeDisabilities.MapEmployeeDisability()
                : null;
            
            List<EmployeeSpecialSeniorityDto> employeeSpecialSeniorities = employeeCard.EmployeeSpecialSeniorities != null
                ? employeeCard.EmployeeSpecialSeniorities.MapEmployeeSpecialSeniority()
                : null;

            return new EmployeeCardDto
            {
                Id = employeeCard.Id,
                FirstName = employeeCard.FirstName,
                MiddleName = employeeCard.MiddleName,
                LastName = employeeCard.LastName,
                TaxIdentificationNumber = employeeCard.TaxIdentificationNumber,
                Seniority = employeeCard.Seniority,
                Grade = employeeCard.Grade,
                BirthDate = employeeCard.BirthDate,
                EntryDate = employeeCard.EntryDate,
                DismissalDate = employeeCard.DismissalDate,
                PensionDate = employeeCard.PensionDate,
                Sex = employeeCard.Sex,
                EmployeeChildren = employeeChildren,
                EmployeeTaxReliefs = employeeTaxReliefs,
                EmployeeCardStatuses = employeeCardStatuses,
                EmployeeDisabilities = employeeDisabilities,
                EmployeeSpecialSeniorities = employeeSpecialSeniorities
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Карточки работника"
        /// </summary>
        /// <param name="employeeCards">Запрос последовательности "Карточки работника"</param>
        /// <returns>Запрос последовательности DTO "Карточки работника"</returns>
        public static IQueryable<EmployeeCardDto> SelectEmployeeCardDtos(this IQueryable<EmployeeCard> employeeCards)
        {
            return employeeCards.Select(employeeCard => new EmployeeCardDto
            {
                Id = employeeCard.Id,
                FirstName = employeeCard.FirstName,
                MiddleName = employeeCard.MiddleName,
                LastName = employeeCard.LastName,
                TaxIdentificationNumber = employeeCard.TaxIdentificationNumber,
                Seniority = employeeCard.Seniority,
                Grade = employeeCard.Grade,
                BirthDate = employeeCard.BirthDate,
                EntryDate = employeeCard.EntryDate,
                DismissalDate = employeeCard.DismissalDate,
                PensionDate = employeeCard.PensionDate,
                Sex = employeeCard.Sex
            });
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Карточки работника"
        /// </summary>
        /// <param name="employeeCards">Запрос последовательности "Карточки работника"</param>
        /// <param name="id">Идентификатор карточки</param>
        /// <returns>Запрос последовательности DTO "Карточки работника"</returns>
        public static IQueryable<EmployeeCardDto> SelectEmployeeCardDtos(this IQueryable<EmployeeCard> employeeCards, int id)
        {
            return employeeCards.Where(rec => rec.Id == id).Select(employeeCard => new EmployeeCardDto
            {
                Id = employeeCard.Id,
                FirstName = employeeCard.FirstName,
                MiddleName = employeeCard.MiddleName,
                LastName = employeeCard.LastName,
                TaxIdentificationNumber = employeeCard.TaxIdentificationNumber,
                Seniority = employeeCard.Seniority,
                Grade = employeeCard.Grade,
                BirthDate = employeeCard.BirthDate,
                EntryDate = employeeCard.EntryDate,
                DismissalDate = employeeCard.DismissalDate,
                PensionDate = employeeCard.PensionDate,
                Sex = employeeCard.Sex,
                EmployeeChildren = employeeCard.EmployeeChildren.Select(children => new EmployeeChildrenDto
                {
                    Id = children.Id,
                    Number = children.Number,
                    PeriodBegin = children.PeriodBegin,
                    PeriodEnd = children.PeriodEnd
                }).ToList(),
                EmployeeCardStatuses = employeeCard.EmployeeCardStatuses.Select(cardStatus => new EmployeeCardStatusDto
                {
                    Id = cardStatus.Id,
                    PeriodBegin = cardStatus.PeriodBegin,
                    PeriodEnd = cardStatus.PeriodEnd,
                    CardStatusTypeId = cardStatus.CardStatusTypeId,
                    CardStatusTypeName = cardStatus.CardStatusType.Name
                }).ToList(),
                EmployeeDisabilities = employeeCard.EmployeeDisabilities.Select(disability => new EmployeeDisabilityDto
                {
                    Id = disability.Id,
                    PeriodBegin = disability.PeriodBegin,
                    PeriodEnd = disability.PeriodEnd,
                    Type = disability.Type
                }).ToList(),
                EmployeeSpecialSeniorities = employeeCard.EmployeeSpecialSeniorities.Select(specialSeniority => new EmployeeSpecialSeniorityDto
                {
                    Id = specialSeniority.Id,
                    PeriodBegin = specialSeniority.PeriodBegin,
                    PeriodEnd = specialSeniority.PeriodEnd,
                    SpecialSeniorityId = specialSeniority.SpecialSeniorityId,
                    SpecialSeniorityName = specialSeniority.SpecialSeniority.Name
                }).ToList(),
                EmployeeTaxReliefs = employeeCard.EmployeeTaxReliefs.Select(taxRelief => new EmployeeTaxReliefDto
                {
                    Id = taxRelief.Id,
                    PeriodBegin = taxRelief.PeriodBegin,
                    PeriodEnd = taxRelief.PeriodEnd,
                    Сoefficient = taxRelief.Сoefficient
                }).ToList()
            });
        }    
    }
}
