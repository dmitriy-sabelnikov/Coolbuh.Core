using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.AdditionalPayments.Extensions
{
    /// <summary>
    /// Методы расширения дополнительной выплаты
    /// </summary>
    public static class AdditionalPaymentExtensions
    {
        /// <summary>
        /// Маппинг дополнительной выплаты
        /// </summary>
        /// <param name="dto">DTO создания "Дополнительная выплата"</param>
        /// <returns>Дополнительная выплата</returns>
        public static AdditionalPayment MapAdditionalPayment(this CreateAdditionalPaymentDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new AdditionalPayment
            {
                EmployeeCardId = dto.EmployeeCardId,
                AdditionalPaymentTypeId = dto.AdditionalPaymentTypeId,
                AccountingPeriod = dto.AccountingPeriod,
                Sum = dto.Sum
            };
        }

        /// <summary>
        /// Маппинг дополнительной выплаты
        /// </summary>
        /// <param name="dto">DTO обновления "Дополнительная выплата"</param>
        /// <returns>Дополнительная выплата</returns>
        public static AdditionalPayment MapAdditionalPayment(this UpdateAdditionalPaymentDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new AdditionalPayment
            {
                Id = dto.Id,
                EmployeeCardId = dto.EmployeeCardId,
                AdditionalPaymentTypeId = dto.AdditionalPaymentTypeId,
                AccountingPeriod = dto.AccountingPeriod,
                Sum = dto.Sum
            };
        }

        /// <summary>
        /// Маппинг дополнительной выплаты
        /// </summary>
        /// <param name="additionalPayment">Дополнительная выплата</param>
        /// <returns>DTO "Дополнительная выплата"</returns>
        public static AdditionalPaymentDto MapAdditionalPaymentDto(this AdditionalPayment additionalPayment)
        {
            if (additionalPayment == null) throw new NullReferenceException(nameof(additionalPayment));

            return new AdditionalPaymentDto
            {
                Id = additionalPayment.Id,
                EmployeeCardId = additionalPayment.EmployeeCardId,
                EmployeeFullName = $"{additionalPayment.EmployeeCard?.LastName} " +
                                   $"{additionalPayment.EmployeeCard?.FirstName.FirstOrDefault()}. " +
                                   $"{additionalPayment.EmployeeCard?.MiddleName.FirstOrDefault()}.",
                EmployeeTaxIdentificationNumber = additionalPayment.EmployeeCard?.TaxIdentificationNumber,
                AdditionalPaymentTypeId = additionalPayment.AdditionalPaymentTypeId,
                AdditionalPaymentTypeName = additionalPayment.AdditionalPaymentType?.Name,
                AccountingPeriod = additionalPayment.AccountingPeriod,
                Sum = additionalPayment.Sum
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Дополнительная выплата"
        /// </summary>
        /// <param name="additionalPayments">Запрос последовательности "Дополнительная выплата"</param>
        /// <returns>Запрос последовательности DTO "Дополнительная выплата"</returns>
        public static IQueryable<AdditionalPaymentDto> SelectAdditionalPaymentDtos(
            this IQueryable<AdditionalPayment> additionalPayments)
        {
            return additionalPayments.Select(additionalPayment => new AdditionalPaymentDto
            {
                Id = additionalPayment.Id,
                EmployeeCardId = additionalPayment.EmployeeCardId,
                EmployeeFullName = $"{additionalPayment.EmployeeCard.LastName} " +
                                   $"{additionalPayment.EmployeeCard.FirstName.FirstOrDefault()}. " +
                                   $"{additionalPayment.EmployeeCard.MiddleName.FirstOrDefault()}.",
                EmployeeTaxIdentificationNumber = additionalPayment.EmployeeCard.TaxIdentificationNumber,
                AdditionalPaymentTypeId = additionalPayment.AdditionalPaymentTypeId,
                AdditionalPaymentTypeName = additionalPayment.AdditionalPaymentType.Name,
                AccountingPeriod = additionalPayment.AccountingPeriod,
                Sum = additionalPayment.Sum
            });
        }
    }
}
