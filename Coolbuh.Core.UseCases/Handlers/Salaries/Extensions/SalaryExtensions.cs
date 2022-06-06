using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.Salaries.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.Salaries.Extensions
{
    /// <summary>
    /// Методы расширения зарплаты
    /// </summary>
    public static class SalaryExtensions
    {
        /// <summary>
        /// Маппинг зарплаты
        /// </summary>
        /// <param name="dto">DTO создания "Зарплата"</param>
        /// <returns>Зарплата</returns>
        public static Salary MapSalary(this CreateSalaryDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new Salary
            {
                EmployeeCardId = dto.EmployeeCardId,
                DepartmentId = dto.DepartmentId,
                AccountingPeriod = dto.AccountingPeriod,
                Days = dto.Days,
                Hours = dto.Hours,
                BaseSum = dto.BaseSum,
                PensionAllowanceId = dto.PensionAllowanceId,
                PensionAllowanceSum = dto.PensionAllowanceSum,
                GradeAllowanceId = dto.GradeAllowanceId,
                GradeAllowanceSum = dto.GradeAllowanceSum,
                OtherAllowanceId = dto.OtherAllowanceId,
                OtherAllowanceSum = dto.OtherAllowanceSum,
            };
        }

        /// <summary>
        /// Маппинг зарплаты
        /// </summary>
        /// <param name="dto">DTO обновления "Зарплата"</param>
        /// <returns>Зарплата</returns>
        public static Salary MapSalary(this UpdateSalaryDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new Salary
            {
                Id = dto.Id,
                EmployeeCardId = dto.EmployeeCardId,
                DepartmentId = dto.DepartmentId,
                AccountingPeriod = dto.AccountingPeriod,
                Days = dto.Days,
                Hours = dto.Hours,
                BaseSum = dto.BaseSum,
                PensionAllowanceId = dto.PensionAllowanceId,
                PensionAllowanceSum = dto.PensionAllowanceSum,
                GradeAllowanceId = dto.GradeAllowanceId,
                GradeAllowanceSum = dto.GradeAllowanceSum,
                OtherAllowanceId = dto.OtherAllowanceId,
                OtherAllowanceSum = dto.OtherAllowanceSum,
            };
        }

        /// <summary>
        /// Маппинг зарплаты
        /// </summary>
        /// <param name="salary">Зарплата</param>
        /// <returns>DTO обновления "Зарплата"</returns>
        public static SalaryDto MapSalaryDto(this Salary salary)
        {
            return new SalaryDto
            {
                Id = salary.Id,
                EmployeeCardId = salary.EmployeeCardId,
                EmployeeFullName = $"{salary.EmployeeCard?.LastName} " +
                                   $"{salary.EmployeeCard?.FirstName.FirstOrDefault()}. " +
                                   $"{salary.EmployeeCard?.MiddleName.FirstOrDefault()}.",
                EmployeeTaxIdentificationNumber = salary.EmployeeCard?.TaxIdentificationNumber,
                DepartmentId = salary.DepartmentId,
                DepartmentName = salary.Department?.Name,
                AccountingPeriod = salary.AccountingPeriod,
                Days = salary.Days,
                Hours = salary.Hours,
                BaseSum = salary.BaseSum,
                PensionAllowanceId = salary.PensionAllowanceId,
                PensionAllowanceSum = salary.PensionAllowanceSum,
                GradeAllowanceId = salary.GradeAllowanceId,
                GradeAllowanceSum = salary.GradeAllowanceSum,
                OtherAllowanceId = salary.OtherAllowanceId,
                OtherAllowanceSum = salary.OtherAllowanceSum,
                TotalSum = salary.TotalSum
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Зарплата"
        /// </summary>
        /// <param name="salaries">Запрос последовательности "Зарплата"</param>
        /// <returns>Запрос последовательности DTO "Зарплата"</returns>
        public static IQueryable<SalaryDto> SelectSalaryDtos(this IQueryable<Salary> salaries)
        {
            return salaries.Select(salary => new SalaryDto
            {
                Id = salary.Id,
                EmployeeCardId = salary.EmployeeCardId,
                EmployeeFullName = $"{salary.EmployeeCard.LastName} " +
                    $"{salary.EmployeeCard.FirstName.FirstOrDefault()}. " +
                    $"{salary.EmployeeCard.MiddleName.FirstOrDefault()}.",
                EmployeeTaxIdentificationNumber = salary.EmployeeCard.TaxIdentificationNumber,
                DepartmentId = salary.DepartmentId,
                DepartmentName = salary.Department.Name,
                AccountingPeriod = salary.AccountingPeriod,
                Days = salary.Days,
                Hours = salary.Hours,
                BaseSum = salary.BaseSum,
                PensionAllowanceId = salary.PensionAllowanceId,
                PensionAllowanceSum = salary.PensionAllowanceSum,
                GradeAllowanceId = salary.GradeAllowanceId,
                GradeAllowanceSum = salary.GradeAllowanceSum,
                OtherAllowanceId = salary.OtherAllowanceId,
                OtherAllowanceSum = salary.OtherAllowanceSum,
                TotalSum = salary.TotalSum
            });
        }

    }
}
