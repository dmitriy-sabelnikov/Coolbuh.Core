using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Extensions
{
    /// <summary>
    /// Методы расширения договора ГПХ
    /// </summary>
    public static class CivilLawContractExtensions
    {
        /// <summary>
        /// Маппинг договора ГПХ
        /// </summary>
        /// <param name="dto">DTO создания "Договор ГПХ"</param>
        /// <returns>Договор ГПХ</returns>
        public static CivilLawContract MapCivilLawContract(this CreateCivilLawContractDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new CivilLawContract
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
        /// Маппинг договора ГПХ
        /// </summary>
        /// <param name="dto">DTO обновления "Договор ГПХ"</param>
        /// <returns>Договор ГПХ</returns>
        public static CivilLawContract MapCivilLawContract(this UpdateCivilLawContractDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new CivilLawContract
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
        /// Маппинг договора ГПХ
        /// </summary>
        /// <param name="civilLawContract">Договор ГПХ</param>
        /// <returns>DTO "Договор ГПХ"</returns>
        public static CivilLawContractDto MapCivilLawContractDto(this CivilLawContract civilLawContract)
        {
            if (civilLawContract == null) throw new ArgumentNullException(nameof(civilLawContract));

            return new CivilLawContractDto
            {
                Id = civilLawContract.Id,
                EmployeeCardId = civilLawContract.EmployeeCardId,
                EmployeeFullName = $"{civilLawContract.EmployeeCard?.LastName} " +
                                   $"{civilLawContract.EmployeeCard?.FirstName.FirstOrDefault()}. " +
                                   $"{civilLawContract.EmployeeCard?.MiddleName.FirstOrDefault()}.",
                EmployeeTaxIdentificationNumber = civilLawContract.EmployeeCard?.TaxIdentificationNumber,
                DepartmentId = civilLawContract.DepartmentId,
                DepartmentName = civilLawContract.Department?.Name,
                AccountingPeriod = civilLawContract.AccountingPeriod,
                AccrualPeriod = civilLawContract.AccrualPeriod,
                Days = civilLawContract.Days,
                Sum = civilLawContract.Sum
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Договор ГПХ"
        /// </summary>
        /// <param name="civilLawContracts">Запрос последовательности "Договор ГПХ"</param>
        /// <returns>Запрос последовательности DTO "Договор ГПХ"</returns>
        public static IQueryable<CivilLawContractDto> SelectCivilLawContractDtos(
            this IQueryable<CivilLawContract> civilLawContracts)
        {
            return civilLawContracts.Select(civilLawContract => new CivilLawContractDto
            {
                Id = civilLawContract.Id,
                EmployeeCardId = civilLawContract.EmployeeCardId,
                EmployeeFullName = $"{civilLawContract.EmployeeCard.LastName} " +
                                   $"{civilLawContract.EmployeeCard.FirstName.FirstOrDefault()}. " +
                                   $"{civilLawContract.EmployeeCard.MiddleName.FirstOrDefault()}.",
                EmployeeTaxIdentificationNumber = civilLawContract.EmployeeCard.TaxIdentificationNumber,
                DepartmentId = civilLawContract.DepartmentId,
                DepartmentName = civilLawContract.Department.Name,
                AccountingPeriod = civilLawContract.AccountingPeriod,
                AccrualPeriod = civilLawContract.AccrualPeriod,
                Days = civilLawContract.Days,
                Sum = civilLawContract.Sum
            });
        }
    }
}
