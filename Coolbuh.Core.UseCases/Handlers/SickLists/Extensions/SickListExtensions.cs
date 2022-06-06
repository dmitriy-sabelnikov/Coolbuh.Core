using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.SickLists.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.SickLists.Extensions
{
    /// <summary>
    /// Методы расширения больничного листа
    /// </summary>
    public static class SickListExtensions
    {
        /// <summary>
        /// Маппинг больничного листа
        /// </summary>
        /// <param name="dto">DTO создания "Больничный лист"</param>
        /// <returns>Больничный лист</returns>
        public static SickList MapSickList(this CreateSickListDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new SickList
            {
                EmployeeCardId = dto.EmployeeCardId,
                DepartmentId = dto.DepartmentId,
                AccountingPeriod = dto.AccountingPeriod,
                AccrualPeriod = dto.AccrualPeriod,
                EnterpriseDays = dto.EnterpriseDays,
                EnterpriseSum = dto.EnterpriseSum,
                SocialInsuranceDays = dto.SocialInsuranceDays,
                SocialInsuranceSum = dto.SocialInsuranceSum
            };
        }

        /// <summary>
        /// Маппинг больничного листа
        /// </summary>
        /// <param name="dto">DTO обновления "Больничный лист"</param>
        /// <returns>Больничный лист</returns>
        public static SickList MapSickList(this UpdateSickListDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new SickList
            {
                Id = dto.Id,
                EmployeeCardId = dto.EmployeeCardId,
                DepartmentId = dto.DepartmentId,
                AccountingPeriod = dto.AccountingPeriod,
                AccrualPeriod = dto.AccrualPeriod,
                EnterpriseDays = dto.EnterpriseDays,
                EnterpriseSum = dto.EnterpriseSum,
                SocialInsuranceDays = dto.SocialInsuranceDays,
                SocialInsuranceSum = dto.SocialInsuranceSum
            };
        }

        /// <summary>
        /// Маппинг больничного листа
        /// </summary>
        /// <param name="sickList">Больничный лист</param>
        /// <returns>DTO "Больничный лист"</returns>
        public static SickListDto MapSickListDto(this SickList sickList)
        {
            if (sickList == null) throw new NullReferenceException(nameof(sickList));

            return new SickListDto
            {
                Id = sickList.Id,
                EmployeeCardId = sickList.EmployeeCardId,
                EmployeeFullName = $"{sickList.EmployeeCard?.LastName} " +
                                   $"{sickList.EmployeeCard?.FirstName.FirstOrDefault()}. " +
                                   $"{sickList.EmployeeCard?.MiddleName.FirstOrDefault()}.",
                EmployeeTaxIdentificationNumber = sickList.EmployeeCard?.TaxIdentificationNumber,
                DepartmentId = sickList.DepartmentId,
                DepartmentName = sickList.Department?.Name,
                AccountingPeriod = sickList.AccountingPeriod,
                AccrualPeriod = sickList.AccrualPeriod,
                EnterpriseDays = sickList.EnterpriseDays,
                EnterpriseSum = sickList.EnterpriseSum,
                SocialInsuranceDays = sickList.SocialInsuranceDays,
                SocialInsuranceSum = sickList.SocialInsuranceSum,
                TotalDays = sickList.EnterpriseDays + sickList.SocialInsuranceDays,
                TotalSum = sickList.EnterpriseSum + sickList.SocialInsuranceSum
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Больничный лист"
        /// </summary>
        /// <param name="sickLists">Запрос последовательности "Больничный лист"</param>
        /// <returns>Запрос последовательности DTO "Больничный лист"</returns>
        public static IQueryable<SickListDto> SelectSickListDtos(this IQueryable<SickList> sickLists)
        {
            return sickLists.Select(sickList => new SickListDto
            {
                Id = sickList.Id,
                EmployeeCardId = sickList.EmployeeCardId,
                EmployeeFullName = $"{sickList.EmployeeCard.LastName} " +
                    $"{sickList.EmployeeCard.FirstName.FirstOrDefault()}. " +
                    $"{sickList.EmployeeCard.MiddleName.FirstOrDefault()}.",
                EmployeeTaxIdentificationNumber = sickList.EmployeeCard.TaxIdentificationNumber,
                DepartmentId = sickList.DepartmentId,
                DepartmentName = sickList.Department.Name,
                AccountingPeriod = sickList.AccountingPeriod,
                AccrualPeriod = sickList.AccrualPeriod,
                EnterpriseDays = sickList.EnterpriseDays,
                EnterpriseSum = sickList.EnterpriseSum,
                SocialInsuranceDays = sickList.SocialInsuranceDays,
                SocialInsuranceSum = sickList.SocialInsuranceSum,
                TotalDays = sickList.EnterpriseDays + sickList.SocialInsuranceDays,
                TotalSum = sickList.EnterpriseSum + sickList.SocialInsuranceSum
            });
        }
    }
}
