using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.Vocations.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.Vocations.Extensions
{
    /// <summary>
    /// Методы расширения отпуска
    /// </summary>
    public static class VocationExtensions
    {
        /// <summary>
        /// Маппинг отпуска
        /// </summary>
        /// <param name="dto">DTO создания "Отпуск"</param>
        /// <returns>Отпуск</returns>
        public static Vocation MapVocation(this CreateVocationDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new Vocation
            {
                EmployeeCardId = dto.EmployeeCardId,
                DepartmentId = dto.DepartmentId,
                AccountingPeriod = dto.AccountingPeriod,
                AccrualPeriod = dto.AccrualPeriod,
                Days = dto.Days,
                Sum = dto.Sum
            };
        }

        /// <summary>
        /// Маппинг отпуска
        /// </summary>
        /// <param name="dto">DTO обновления "Отпуск"</param>
        /// <returns>Отпуск</returns>
        public static Vocation MapVocation(this UpdateVocationDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new Vocation
            {
                Id = dto.Id,
                EmployeeCardId = dto.EmployeeCardId,
                DepartmentId = dto.DepartmentId,
                AccountingPeriod = dto.AccountingPeriod,
                AccrualPeriod = dto.AccrualPeriod,
                Days = dto.Days,
                Sum = dto.Sum
            };
        }

        /// <summary>
        /// Маппинг отпуска
        /// </summary>
        /// <param name="vocation">Отпуск</param>
        /// <returns>DTO "Отпуск"</returns>
        public static VocationDto MapVocationDto(this Vocation vocation)
        {
            if (vocation == null) throw new ArgumentNullException(nameof(vocation));

            return new VocationDto
            {
                Id = vocation.Id,
                EmployeeCardId = vocation.EmployeeCardId,
                EmployeeFullName = $"{vocation.EmployeeCard?.LastName} " +
                                   $"{vocation.EmployeeCard?.FirstName.FirstOrDefault()}. " +
                                   $"{vocation.EmployeeCard?.MiddleName.FirstOrDefault()}.",
                EmployeeTaxIdentificationNumber = vocation.EmployeeCard?.TaxIdentificationNumber,
                DepartmentId = vocation.DepartmentId,
                DepartmentName = vocation.Department?.Name,
                AccountingPeriod = vocation.AccountingPeriod,
                AccrualPeriod = vocation.AccrualPeriod,
                Days = vocation.Days,
                Sum = vocation.Sum
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Отпуск"
        /// </summary>
        /// <param name="vocations">Запрос последовательности "Отпуск"</param>
        /// <returns>Запрос последовательности DTO "Отпуск"</returns>
        public static IQueryable<VocationDto> SelectVocationDtos(this IQueryable<Vocation> vocations)
        {
            return vocations.Select(vocation => new VocationDto
            {
                Id = vocation.Id,
                EmployeeCardId = vocation.EmployeeCardId,
                EmployeeFullName = $"{vocation.EmployeeCard.LastName} " +
                    $"{vocation.EmployeeCard.FirstName.FirstOrDefault()}. " +
                    $"{vocation.EmployeeCard.MiddleName.FirstOrDefault()}.",
                EmployeeTaxIdentificationNumber = vocation.EmployeeCard.TaxIdentificationNumber,
                DepartmentId = vocation.DepartmentId,
                DepartmentName = vocation.Department.Name,
                AccountingPeriod = vocation.AccountingPeriod,
                AccrualPeriod = vocation.AccrualPeriod,
                Days = vocation.Days,
                Sum = vocation.Sum
            });
        }
    }
}
