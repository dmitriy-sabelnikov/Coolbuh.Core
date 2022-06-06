using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalAccruals.Extensions
{
    /// <summary>
    /// Методы расширения дополнительного начисления
    /// </summary>
    public static class AdditionalAccrualExtensions
    {
        /// <summary>
        /// Маппинг дополнительного начисления
        /// </summary>
        /// <param name="dto">DTO создания "Дополнительное начисление"</param>
        /// <returns>Дополнительное начисление</returns>
        public static AdditionalAccrual MapAdditionalAccrual(this CreateAdditionalAccrualDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new AdditionalAccrual
            {
                EmployeeCardId = dto.EmployeeCardId,
                DepartmentId = dto.DepartmentId,
                AccountingPeriod = dto.AccountingPeriod,
                AdditionalAccrualTypeId = dto.AdditionalAccrualTypeId,
                Sum = dto.Sum
            };
        }

        /// <summary>
        /// Маппинг дополнительного начисления
        /// </summary>
        /// <param name="dto">DTO обновления "Дополнительное начисление"</param>
        /// <returns>Дополнительное начисление</returns>
        public static AdditionalAccrual MapAdditionalAccrual(this UpdateAdditionalAccrualDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new AdditionalAccrual
            {
                Id = dto.Id,
                EmployeeCardId = dto.EmployeeCardId,
                DepartmentId = dto.DepartmentId,
                AccountingPeriod = dto.AccountingPeriod,
                AdditionalAccrualTypeId = dto.AdditionalAccrualTypeId,
                Sum = dto.Sum
            };
        }

        /// <summary>
        /// Маппинг дополнительного начисления
        /// </summary>
        /// <param name="additionalAccrual">Дополнительное начисление</param>
        /// <returns>DTO "Дополнительное начисление"</returns>
        public static AdditionalAccrualDto MapAdditionalAccrualDto(this AdditionalAccrual additionalAccrual)
        {
            if (additionalAccrual == null) throw new NullReferenceException(nameof(additionalAccrual));

            return new AdditionalAccrualDto
            {
                Id = additionalAccrual.Id,
                EmployeeCardId = additionalAccrual.EmployeeCardId,
                EmployeeFullName = $"{additionalAccrual.EmployeeCard?.LastName} " +
                                   $"{additionalAccrual.EmployeeCard?.FirstName.FirstOrDefault()}. " +
                                   $"{additionalAccrual.EmployeeCard?.MiddleName.FirstOrDefault()}.",
                EmployeeTaxIdentificationNumber = additionalAccrual.EmployeeCard?.TaxIdentificationNumber,
                DepartmentId = additionalAccrual.DepartmentId,
                DepartmentName = additionalAccrual.Department?.Name,
                AccountingPeriod = additionalAccrual.AccountingPeriod,
                AdditionalAccrualTypeId = additionalAccrual.AdditionalAccrualTypeId,
                AdditionalAccrualTypeName = additionalAccrual.AdditionalAccrualType?.Name,
                Sum = additionalAccrual.Sum
            };
        }


        /// <summary>
        /// Получить запрос последовательности DTO "Дополнительное начисление"
        /// </summary>
        /// <param name="additionalAccruals">Запрос последовательности "Дополнительное начисление"</param>
        /// <returns>Запрос последовательности DTO "Дополнительное начисление"</returns>
        public static IQueryable<AdditionalAccrualDto> SelectAdditionalAccrualDtos(
            this IQueryable<AdditionalAccrual> additionalAccruals)
        {
            return additionalAccruals.Select(additionalAccrual => new AdditionalAccrualDto
            {
                Id = additionalAccrual.Id,
                EmployeeCardId = additionalAccrual.EmployeeCardId,
                EmployeeFullName = $"{additionalAccrual.EmployeeCard.LastName} " +
                                   $"{additionalAccrual.EmployeeCard.FirstName.FirstOrDefault()}. " +
                                   $"{additionalAccrual.EmployeeCard.MiddleName.FirstOrDefault()}.",
                EmployeeTaxIdentificationNumber = additionalAccrual.EmployeeCard.TaxIdentificationNumber,
                DepartmentId = additionalAccrual.DepartmentId,
                DepartmentName = additionalAccrual.Department.Name,
                AccountingPeriod = additionalAccrual.AccountingPeriod,
                AdditionalAccrualTypeId = additionalAccrual.AdditionalAccrualTypeId,
                AdditionalAccrualTypeName = additionalAccrual.AdditionalAccrualType.Name,
                Sum = additionalAccrual.Sum
            });
        }
    }
}
