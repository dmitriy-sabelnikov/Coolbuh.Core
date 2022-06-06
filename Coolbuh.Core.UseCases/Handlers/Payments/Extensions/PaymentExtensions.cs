using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.Payments.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.Payments.Extensions
{
    /// <summary>
    /// Методы расширения выплаты
    /// </summary>
    public static class PaymentExtensions
    {
        /// <summary>
        /// Маппинг выплаты
        /// </summary>
        /// <param name="dto">DTO создания "Выплата"</param>
        /// <returns>Выплата</returns>
        public static Payment MapPayment(this CreatePaymentDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new Payment
            {
                EmployeeCardId = dto.EmployeeCardId,
                AccountingPeriod = dto.AccountingPeriod,
                Sum = dto.Sum
            };
        }

        /// <summary>
        /// Маппинг выплаты
        /// </summary>
        /// <param name="dto">DTO обновления "Выплата"</param>
        /// <returns>Выплата</returns>
        public static Payment MapPayment(this UpdatePaymentDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new Payment
            {
                Id = dto.Id,
                EmployeeCardId = dto.EmployeeCardId,
                AccountingPeriod = dto.AccountingPeriod,
                Sum = dto.Sum
            };
        }

        /// <summary>
        /// Маппинг выплаты
        /// </summary>
        /// <param name="payment">Выплата</param>
        /// <returns>DTO обновления "Выплата"</returns>
        public static PaymentDto MapPaymentDto(this Payment payment)
        {
            if (payment == null) throw new NullReferenceException(nameof(payment));

            return new PaymentDto
            {
                Id = payment.Id,
                EmployeeCardId = payment.EmployeeCardId,
                EmployeeFullName = $"{payment.EmployeeCard?.LastName} " +
                                   $"{payment.EmployeeCard?.FirstName.FirstOrDefault()}. " +
                                   $"{payment.EmployeeCard?.MiddleName.FirstOrDefault()}.",
                EmployeeTaxIdentificationNumber = payment.EmployeeCard?.TaxIdentificationNumber,
                AccountingPeriod = payment.AccountingPeriod,
                Sum = payment.Sum
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Выплата"
        /// </summary>
        /// <param name="payments">Запрос последовательности "Выплата"</param>
        /// <returns>Запрос последовательности DTO "Выплата"</returns>
        public static IQueryable<PaymentDto> SelectPaymentDtos(this IQueryable<Payment> payments)
        {
            return payments.Select(payment => new PaymentDto
            {
                Id = payment.Id,
                EmployeeCardId = payment.EmployeeCardId,
                EmployeeFullName = $"{payment.EmployeeCard.LastName} " +
                    $"{payment.EmployeeCard.FirstName.FirstOrDefault()}. " +
                    $"{payment.EmployeeCard.MiddleName.FirstOrDefault()}.",
                EmployeeTaxIdentificationNumber = payment.EmployeeCard.TaxIdentificationNumber,
                AccountingPeriod = payment.AccountingPeriod,
                Sum = payment.Sum
            });
        }
    }
}
