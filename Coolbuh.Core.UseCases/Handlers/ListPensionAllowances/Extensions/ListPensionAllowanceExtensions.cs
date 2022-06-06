using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Extensions
{
    /// <summary>
    /// Методы расширения надбавки за пенсию
    /// </summary>
    public static class ListPensionAllowanceExtensions
    {
        /// <summary>
        /// Маппинг надбавки за пенсию
        /// </summary>
        /// <param name="dto">DTO создания "Надбавки за пенсию"</param>
        /// <returns>Надбавка за пенсию</returns>
        public static ListPensionAllowance MapListPensionAllowance(this CreateListPensionAllowanceDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListPensionAllowance
            {
                Code = dto.Code,
                Name = dto.Name,
                Percent = dto.Percent,
                Flags = GetFlags(dto.UseAllowance)
            };
        }

        /// <summary>
        /// Маппинг надбавки за пенсию
        /// </summary>
        /// <param name="dto">DTO обновления "Надбавки за пенсию"</param>
        /// <returns>Надбавка за пенсию</returns>
        public static ListPensionAllowance MapListPensionAllowance(this UpdateListPensionAllowanceDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListPensionAllowance
            {
                Id = dto.Id,
                Code = dto.Code,
                Name = dto.Name,
                Percent = dto.Percent,
                Flags = GetFlags(dto.UseAllowance)
            };
        }

        /// <summary>
        /// Маппинг надбавки за пенсию
        /// </summary>
        /// <param name="pensionAllowance">Надбавки за пенсию</param>
        /// <returns>DTO "Надбавки за пенсию"</returns>
        public static ListPensionAllowanceDto MapListPensionAllowanceDto(this ListPensionAllowance pensionAllowance)
        {
            if (pensionAllowance == null) throw new NullReferenceException(nameof(pensionAllowance));

            return new ListPensionAllowanceDto
            {
                Id = pensionAllowance.Id,
                Code = pensionAllowance.Code,
                Name = pensionAllowance.Name,
                Percent = pensionAllowance.Percent,
                UseAllowance = (pensionAllowance.Flags & (int)ListPensionAllowanceFlags.NoUse) <= 0
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Надбавки за пенсию"
        /// </summary>
        /// <param name="pensionAllowances">Запрос последовательности "Надбавки за пенсию"</param>
        /// <returns>Запрос последовательности DTO "Надбавки за пенсию"</returns>
        public static IQueryable<ListPensionAllowanceDto> SelectListPensionAllowanceDtos(
            this IQueryable<ListPensionAllowance> pensionAllowances)
        {
            return pensionAllowances.Select(pensionAllowance => new ListPensionAllowanceDto
            {
                Id = pensionAllowance.Id,
                Code = pensionAllowance.Code,
                Name = pensionAllowance.Name,
                Percent = pensionAllowance.Percent,
                UseAllowance = (pensionAllowance.Flags & (int)ListPensionAllowanceFlags.NoUse) <= 0
            });
        }

        /// <summary>
        /// Получить флаги надбавки за пенсию
        /// </summary>
        /// <param name="useAllowance">Флаг применения надбавки</param>
        /// <returns>Флаг надбавки за пенсию</returns>
        private static int GetFlags(bool useAllowance)
        {
            var flags = 0;
            if (!useAllowance)
                flags += (int)ListPensionAllowanceFlags.NoUse;

            return flags;
        }
    }
}
