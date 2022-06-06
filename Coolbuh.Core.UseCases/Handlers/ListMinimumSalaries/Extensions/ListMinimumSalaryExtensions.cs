using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Extensions
{
    /// <summary>
    /// Методы расширения минимальной зарплаты
    /// </summary>
    public static class ListMinimumSalaryExtensions
    {
        /// <summary>
        /// Маппинг минимальной зарплаты
        /// </summary>
        /// <param name="dto">DTO создания "Минимальные зарплаты"</param>
        /// <returns>Минимальная зарплата</returns>
        public static ListMinimumSalary MapListMinimumSalary(this CreateListMinimumSalaryDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListMinimumSalary
            {
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Sum = dto.Sum
            };
        }

        /// <summary>
        /// Маппинг минимальной зарплаты
        /// </summary>
        /// <param name="dto">DTO обновления "Минимальные зарплаты"</param>
        /// <returns>Минимальная зарплата</returns>
        public static ListMinimumSalary MapListMinimumSalary(this UpdateListMinimumSalaryDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListMinimumSalary
            {
                Id = dto.Id,
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Sum = dto.Sum
            };
        }

        /// <summary>
        /// Маппинг минимальной зарплаты
        /// </summary>
        /// <param name="minimumSalary">Минимальная зарплата</param>
        /// <returns>DTO "Минимальные зарплаты"</returns>
        public static ListMinimumSalaryDto MapListMinimumSalaryDto(this ListMinimumSalary minimumSalary)
        {
            if (minimumSalary == null) throw new NullReferenceException(nameof(minimumSalary));

            return new ListMinimumSalaryDto
            {
                Id = minimumSalary.Id,
                PeriodBegin = minimumSalary.PeriodBegin,
                PeriodEnd = minimumSalary.PeriodEnd,
                Sum = minimumSalary.Sum
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Минимальные зарплаты"
        /// </summary>
        /// <param name="minimumSalaries">Запрос последовательности "Минимальные зарплаты"</param>
        /// <returns>Запрос последовательности DTO "Минимальные зарплаты"</returns>
        public static IQueryable<ListMinimumSalaryDto> SelectListMinimumSalaryDtos(this IQueryable<ListMinimumSalary> minimumSalaries)
        {
            return minimumSalaries.Select(minimumSalary => new ListMinimumSalaryDto
            {
                Id = minimumSalary.Id,
                PeriodBegin = minimumSalary.PeriodBegin,
                PeriodEnd = minimumSalary.PeriodEnd,
                Sum = minimumSalary.Sum
            });
        }
    }
}
