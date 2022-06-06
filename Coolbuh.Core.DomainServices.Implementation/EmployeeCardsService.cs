using Coolbuh.Core.DomainServices.Interfaces;
using Coolbuh.Core.Entities.Constants;
using Coolbuh.Core.Entities.Exceptions;
using Coolbuh.Core.Entities.Models;
using System;
using System.Collections.Generic;

namespace Coolbuh.Core.DomainServices.Implementation
{
    /// <inheritdoc cref="IEmployeeCardsService"/>
    public class EmployeeCardsService : IEmployeeCardsService
    {
        private readonly ITaxIdentificationNumberService _taxIdentificationNumberService;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="taxIdentificationNumberService">Сервис работы с ИНН</param>
        public EmployeeCardsService(ITaxIdentificationNumberService taxIdentificationNumberService)
        {
            _taxIdentificationNumberService = taxIdentificationNumberService;
        }

        /// <inheritdoc/>
        public void ValidationEntity(EmployeeCard employeeCard)
        {
            if (employeeCard == null) throw new ArgumentNullException(nameof(employeeCard));

            //=================================================Карточка работника==================================================================
            if (string.IsNullOrEmpty(employeeCard.FirstName))
                throw new NotValidEntityEntityException("Картка робітника: не заповнене ім'я");

            if (employeeCard.FirstName.Length > EmployeeCardConstants.FirstNameLength)
                throw new NotValidEntityEntityException($"Картка робітника: " +
                    $"довжина ім'я не повинна перевищувати {EmployeeCardConstants.FirstNameLength}");

            if (string.IsNullOrEmpty(employeeCard.MiddleName))
                throw new NotValidEntityEntityException("Картка робітника: не заповнене по батькові");

            if (employeeCard.MiddleName.Length > EmployeeCardConstants.MiddleNameLength)
                throw new NotValidEntityEntityException($"Картка робітника: " +
                    $"довжина по батькові не повинна перевищувати {EmployeeCardConstants.MiddleNameLength}");

            if (string.IsNullOrEmpty(employeeCard.LastName))
                throw new NotValidEntityEntityException("Картка робітника: не заповнене прізвище");

            if (employeeCard.LastName.Length > EmployeeCardConstants.LastNameLength)
                throw new NotValidEntityEntityException($"Картка робітника: " +
                    "довжина прізвища не повинна перевищувати {EmployeeCardConstants.LastNameLength}");

            _taxIdentificationNumberService.ValidationTaxIdentificationNumber(employeeCard.TaxIdentificationNumber);

            //=================================================Карточка работника. Статус============================================================
            if (employeeCard.EmployeeCardStatuses is { Count: > 0 })
            {
                foreach (var сardStatus in employeeCard.EmployeeCardStatuses)
                {
                    if (сardStatus.CardStatusTypeId == 0)
                        throw new NotValidEntityEntityException("Статус: не заповнений тип статуса");

                    if (сardStatus.PeriodEnd != null && сardStatus.PeriodBegin != null &&
                        сardStatus.PeriodBegin > сardStatus.PeriodEnd)
                        throw new NotValidEntityEntityException("Статус: дата початку більше за дату закінчення");
                }

                if (IsExistsPeriodIntersection(employeeCard.EmployeeCardStatuses))
                    throw new NotValidEntityEntityException("Статус: є періоди, що перетинається");
            }

            //=================================================Карточка работника. Дети============================================================
            if (employeeCard.EmployeeChildren is { Count: > 0 })
            {
                foreach (var child in employeeCard.EmployeeChildren)
                {
                    if (child.Number == 0)
                        throw new NotValidEntityEntityException("Діти: кількість дітей не заповнена");

                    if (child.PeriodEnd != null && child.PeriodBegin != null &&
                        child.PeriodBegin > child.PeriodEnd)
                        throw new NotValidEntityEntityException("Діти: дата початку більше за дату закінчення");
                }

                if (IsExistsPeriodIntersection(employeeCard.EmployeeChildren))
                    throw new NotValidEntityEntityException("Діти: є періоди, що перетинається");
            }

            //=================================================Карточка работника. Инвалидность====================================================
            if (employeeCard.EmployeeDisabilities is { Count: > 0 })
            {
                foreach (var disability in employeeCard.EmployeeDisabilities)
                {
                    if (disability.Type == 0)
                        throw new NotValidEntityEntityException("Iнвалідність: тип інвалідності не заповнений");

                    if (disability.PeriodEnd != null && disability.PeriodBegin != null &&
                        disability.PeriodBegin > disability.PeriodEnd)
                        throw new NotValidEntityEntityException("Iнвалідність: дата початку більше за дату закінчення");
                }

                if (IsExistsPeriodIntersection(employeeCard.EmployeeDisabilities))
                    throw new NotValidEntityEntityException("Iнвалідність: є періоди, що перетинається");
            }

            //=================================================Карточка работника. Спецстаж========================================================
            if (employeeCard.EmployeeSpecialSeniorities is { Count: > 0 })
            {
                foreach (var specialSeniority in employeeCard.EmployeeSpecialSeniorities)
                {
                    if (specialSeniority.SpecialSeniorityId == 0)
                        throw new NotValidEntityEntityException("Спецстаж: тип спецстажу не заповнений");

                    if (specialSeniority.PeriodEnd != null && specialSeniority.PeriodBegin != null &&
                        specialSeniority.PeriodBegin > specialSeniority.PeriodEnd)
                        throw new NotValidEntityEntityException("Спецстаж: дата початку більше за дату закінчення");
                }

                if (IsExistsPeriodIntersection(employeeCard.EmployeeSpecialSeniorities))
                    throw new NotValidEntityEntityException("Спецстаж: є періоди, що перетинається");
            }

            //=================================================Карточка работника. Налоговые льготы================================================
            if (employeeCard.EmployeeTaxReliefs is { Count: > 0 })
            {
                foreach (var taxRelief in employeeCard.EmployeeTaxReliefs)
                {
                    if (taxRelief.Сoefficient == 0)
                        throw new NotValidEntityEntityException("Податкові пільги: коефіцієнт пільги не заповнений");

                    if (taxRelief.PeriodEnd != null && taxRelief.PeriodBegin != null &&
                        taxRelief.PeriodBegin > taxRelief.PeriodEnd)
                        throw new NotValidEntityEntityException("Податкові пільги: дата початку більше за дату закінчення");
                }

                if (IsExistsPeriodIntersection(employeeCard.EmployeeTaxReliefs))
                    throw new NotValidEntityEntityException("Податкові пільги: є періоди, що перетинається");
            }
        }

        /// <summary>
        /// Поиск пересечения периодов 
        /// </summary>
        /// <param name="cardStatuses">Статусы карточки работника</param>
        /// <returns>Да/нет</returns>
        private static bool IsExistsPeriodIntersection(List<EmployeeCardStatus> cardStatuses)
        {
            if (cardStatuses == null) throw new ArgumentNullException(nameof(cardStatuses));
            if (cardStatuses.Count == 0)
                return false;

            for (var i = 0; i < cardStatuses.Count; i++)
            {
                var checkPeriodBegin = cardStatuses[i].PeriodBegin ?? DateTime.MinValue;
                var checkPeriodEnd = cardStatuses[i].PeriodEnd ?? DateTime.MaxValue;

                for (var j = 0; j < cardStatuses.Count; j++)
                {
                    if (i == j)
                        continue;

                    var periodBegin = cardStatuses[j].PeriodBegin ?? DateTime.MinValue;
                    var periodEnd = cardStatuses[j].PeriodEnd ?? DateTime.MaxValue;

                    if (checkPeriodEnd >= periodBegin && checkPeriodBegin <= periodEnd)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Поиск пересечения периодов
        /// </summary>
        /// <param name="children">Дети работника</param>
        /// <returns>Да/нет</returns>
        private static bool IsExistsPeriodIntersection(List<EmployeeChildren> children)
        {
            if (children == null) throw new ArgumentNullException(nameof(children));
            if (children.Count == 0)
                return false;

            for (var i = 0; i < children.Count; i++)
            {
                var checkPeriodBegin = children[i].PeriodBegin ?? DateTime.MinValue;
                var checkPeriodEnd = children[i].PeriodEnd ?? DateTime.MaxValue;
                for (var j = 0; j < children.Count; j++)
                {
                    if (i == j)
                        continue;

                    var periodBegin = children[j].PeriodBegin ?? DateTime.MinValue;
                    var periodEnd = children[j].PeriodEnd ?? DateTime.MaxValue;

                    if (checkPeriodEnd >= periodBegin && checkPeriodBegin <= periodEnd)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Поиск пересечения периодов
        /// </summary>
        /// <param name="disabilities">Инвалидности работника</param>
        /// <returns>Да/нет</returns>
        private static bool IsExistsPeriodIntersection(List<EmployeeDisability> disabilities)
        {
            if (disabilities == null) throw new ArgumentNullException(nameof(disabilities));
            if (disabilities.Count == 0)
                return false;

            for (var i = 0; i < disabilities.Count; i++)
            {
                var checkPeriodBegin = disabilities[i].PeriodBegin ?? DateTime.MinValue;
                var checkPeriodEnd = disabilities[i].PeriodEnd ?? DateTime.MaxValue;
                for (var j = 0; j < disabilities.Count; j++)
                {
                    if (i == j)
                        continue;

                    var periodBegin = disabilities[j].PeriodBegin ?? DateTime.MinValue;
                    var periodEnd = disabilities[j].PeriodEnd ?? DateTime.MaxValue;

                    if (checkPeriodEnd >= periodBegin && checkPeriodBegin <= periodEnd)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Поиск пересечения периодов
        /// </summary>
        /// <param name="specialSeniorities">Спецстажи работника</param>
        /// <returns>Да/нет</returns>
        private static bool IsExistsPeriodIntersection(List<EmployeeSpecialSeniority> specialSeniorities)
        {
            if (specialSeniorities == null) throw new ArgumentNullException(nameof(specialSeniorities));
            if (specialSeniorities.Count == 0)
                return false;

            for (var i = 0; i < specialSeniorities.Count; i++)
            {
                var checkPeriodBegin = specialSeniorities[i].PeriodBegin ?? DateTime.MinValue;
                var checkPeriodEnd = specialSeniorities[i].PeriodEnd ?? DateTime.MaxValue;
                for (var j = 0; j < specialSeniorities.Count; j++)
                {
                    if (i == j)
                        continue;

                    var periodBegin = specialSeniorities[j].PeriodBegin ?? DateTime.MinValue;
                    var periodEnd = specialSeniorities[j].PeriodEnd ?? DateTime.MaxValue;

                    if (checkPeriodEnd >= periodBegin && checkPeriodBegin <= periodEnd)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Поиск пересечения периодов
        /// </summary>
        /// <param name="taxReliefs">Налоговые льготы</param>
        /// <returns>Да/нет</returns>
        private static bool IsExistsPeriodIntersection(List<EmployeeTaxRelief> taxReliefs)
        {
            if (taxReliefs == null) throw new ArgumentNullException(nameof(taxReliefs));
            if (taxReliefs.Count == 0)
                return false;

            for (var i = 0; i < taxReliefs.Count; i++)
            {
                var checkPeriodBegin = taxReliefs[i].PeriodBegin ?? DateTime.MinValue;
                var checkPeriodEnd = taxReliefs[i].PeriodEnd ?? DateTime.MaxValue;
                for (var j = 0; j < taxReliefs.Count; j++)
                {
                    if (i == j)
                        continue;

                    var periodBegin = taxReliefs[j].PeriodBegin ?? DateTime.MinValue;
                    var periodEnd = taxReliefs[j].PeriodEnd ?? DateTime.MaxValue;

                    if (checkPeriodEnd >= periodBegin && checkPeriodBegin <= periodEnd)
                        return true;
                }
            }

            return false;
        }
    }
}