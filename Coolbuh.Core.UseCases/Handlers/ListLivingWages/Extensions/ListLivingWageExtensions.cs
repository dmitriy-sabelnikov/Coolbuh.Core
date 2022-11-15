using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.ListLivingWages.Extensions
{
    /// <summary>
    /// Методы расширения прожиточного минимуму
    /// </summary>
    public static class ListLivingWageExtensions
    {
        /// <summary>
        /// Маппинг прожиточного минимуму
        /// </summary>
        /// <param name="dto">DTO создания "Прожиточные минимумы"</param>
        /// <returns>Прожиточные минимумы</returns>
        public static ListLivingWage MapListLivingWage(this CreateListLivingWageDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new ListLivingWage
            {
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Sum = dto.Sum
            };
        }

        /// <summary>
        /// Маппинг прожиточного минимуму
        /// </summary>
        /// <param name="dto">DTO обновления "Прожиточные минимумы"</param>
        /// <returns>Прожиточные минимумы</returns>
        public static ListLivingWage MapListLivingWage(this UpdateListLivingWageDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new ListLivingWage
            {
                Id = dto.Id,
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Sum = dto.Sum
            };
        }

        /// <summary>
        /// Маппинг прожиточного минимуму
        /// </summary>
        /// <param name="livingWage">Прожиточный минимум</param>
        /// <returns>DTO "Прожиточный минимум"</returns>
        public static ListLivingWageDto MapListLivingWageDto(this ListLivingWage livingWage)
        {
            if (livingWage == null) throw new ArgumentNullException(nameof(livingWage));

            return new ListLivingWageDto
            {
                Id = livingWage.Id,
                PeriodBegin = livingWage.PeriodBegin,
                PeriodEnd = livingWage.PeriodEnd,
                Sum = livingWage.Sum
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Прожиточные минимумы"
        /// </summary>
        /// <param name="livingWages">Запрос последовательности "Прожиточные минимумы"</param>
        /// <returns>Запрос последовательности DTO "Прожиточные минимумы"</returns>
        public static IQueryable<ListLivingWageDto> SelectListLivingWageDtos(this IQueryable<ListLivingWage> livingWages)
        {
            return livingWages.Select(livingWage => new ListLivingWageDto
            {
                Id = livingWage.Id,
                PeriodBegin = livingWage.PeriodBegin,
                PeriodEnd = livingWage.PeriodEnd,
                Sum = livingWage.Sum
            });
        }
    }
}
