using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Extensions
{
    /// <summary>
    /// Методы расширения спецстажей
    /// </summary>
    public static class ListSpecialSeniorityExtensions
    {
        /// <summary>
        /// Маппинг спецстажа
        /// </summary>
        /// <param name="dto">DTO создания "Спецстажи"</param>
        /// <returns>Спецстаж</returns>
        public static ListSpecialSeniority MapListSpecialSeniority(this CreateListSpecialSeniorityDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new ListSpecialSeniority
            {
                Code = dto.Code,
                ReasonCode = dto.ReasonCode,
                Name = dto.Name
            };
        }

        /// <summary>
        /// Маппинг спецстажа
        /// </summary>
        /// <param name="dto">DTO обновления "Спецстажи"</param>
        /// <returns>Спецстаж</returns>
        public static ListSpecialSeniority MapListSpecialSeniority(this UpdateListSpecialSeniorityDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new ListSpecialSeniority
            {
                Id = dto.Id,
                Code = dto.Code,
                ReasonCode = dto.ReasonCode,
                Name = dto.Name
            };
        }

        /// <summary>
        /// Маппинг спецстажа
        /// </summary>
        /// <param name="specialSeniority">Спецстаж</param>
        /// <returns>DTO "Спецстажи"</returns>
        public static ListSpecialSeniorityDto MapListSpecialSeniorityDto(this ListSpecialSeniority specialSeniority)
        {
            if (specialSeniority == null) throw new ArgumentNullException(nameof(specialSeniority));

            return new ListSpecialSeniorityDto
            {
                Id = specialSeniority.Id,
                Code = specialSeniority.Code,
                ReasonCode = specialSeniority.ReasonCode,
                Name = specialSeniority.Name
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Спецстажи"
        /// </summary>
        /// <param name="specialSeniorities">Запрос последовательности "Спецстажи"</param>
        /// <returns>Запрос последовательности DTO "Спецстажи"</returns>
        public static IQueryable<ListSpecialSeniorityDto> SelectListSpecialSeniorityDtos(
            this IQueryable<ListSpecialSeniority> specialSeniorities)
        {
            return specialSeniorities.Select(specialSeniority => new ListSpecialSeniorityDto
            {
                Id = specialSeniority.Id,
                Code = specialSeniority.Code,
                ReasonCode = specialSeniority.ReasonCode,
                Name = specialSeniority.Name
            });
        }
    }
}
