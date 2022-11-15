using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Extensions
{
    /// <summary>
    /// Методы расширения других надбавок
    /// </summary>
    public static class ListOtherAllowanceExtensions
    {
        /// <summary>
        /// Маппинг другой надбавки
        /// </summary>
        /// <param name="dto">DTO создания "Другие надбавки"</param>
        /// <returns>Другая надбавка</returns>
        public static ListOtherAllowance MapListOtherAllowance(this CreateListOtherAllowanceDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new ListOtherAllowance
            {
                Code = dto.Code,
                Name = dto.Name,
                Percent = dto.Percent,
                Flags = GetFlags(dto.UseAllowance)
            };
        }

        /// <summary>
        /// Маппинг другой надбавки
        /// </summary>
        /// <param name="dto">DTO обновления "Другие надбавки"</param>
        /// <returns>Другая надбавка</returns>
        public static ListOtherAllowance MapListOtherAllowance(this UpdateListOtherAllowanceDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            return new ListOtherAllowance
            {
                Id = dto.Id,
                Code = dto.Code,
                Name = dto.Name,
                Percent = dto.Percent,
                Flags = GetFlags(dto.UseAllowance)
            };
        }

        /// <summary>
        /// Маппинг другой надбавки
        /// </summary>
        /// <param name="otherAllowance">Другая надбавка</param>
        /// <returns>DTO "Другие надбавки"</returns>
        public static ListOtherAllowanceDto MapListOtherAllowanceDto(this ListOtherAllowance otherAllowance)
        {
            if (otherAllowance == null) throw new ArgumentNullException(nameof(otherAllowance));

            return new ListOtherAllowanceDto
            {
                Id = otherAllowance.Id,
                Code = otherAllowance.Code,
                Name = otherAllowance.Name,
                Percent = otherAllowance.Percent,
                UseAllowance = (otherAllowance.Flags & (int)ListOtherAllowanceActions.NoUse) <= 0
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Другие надбавки"
        /// </summary>
        /// <param name="otherAllowances">Запрос последовательности "Другие надбавки"</param>
        /// <returns>Запрос последовательности DTO "Другие надбавки"</returns>
        public static IQueryable<ListOtherAllowanceDto> SelectListOtherAllowanceDtos(
            this IQueryable<ListOtherAllowance> otherAllowances)
        {
            return otherAllowances.Select(otherAllowance => new ListOtherAllowanceDto
            {
                Id = otherAllowance.Id,
                Code = otherAllowance.Code,
                Name = otherAllowance.Name,
                Percent = otherAllowance.Percent,
                UseAllowance = (otherAllowance.Flags & (int)ListOtherAllowanceActions.NoUse) <= 0
            });
        }

        /// <summary>
        /// Получить флаги другой надбавки
        /// </summary>
        /// <param name="useAllowance">Флаг применения надбавки</param>
        /// <returns>Флаг другой надбавки</returns>
        private static int GetFlags(bool useAllowance)
        {
            var flags = 0;
            if (!useAllowance)
                flags += (int)ListOtherAllowanceActions.NoUse;

            return flags;
        }
    }
}
