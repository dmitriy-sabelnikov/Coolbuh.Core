using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Extensions
{
    /// <summary>
    /// Методы расширения надбавки за классность
    /// </summary>
    public static class ListGradeAllowanceExtensions
    {
        /// <summary>
        /// Маппинг надбавки за классность
        /// </summary>
        /// <param name="dto">DTO создания "Надбавки за классность"</param>
        /// <returns>Надбавка за классность</returns>
        public static ListGradeAllowance MapListGradeAllowance(this CreateListGradeAllowanceDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListGradeAllowance
            {
                Code = dto.Code,
                Name = dto.Name,
                Percent = dto.Percent,
                Grade = dto.Grade,
                DepartmentId = dto.DepartmentId,
                Flags = GetFlags(dto.UseAllowance)
            };
        }

        /// <summary>
        /// Маппинг надбавки за классность
        /// </summary>
        /// <param name="dto">DTO обновления "Надбавки за классность"</param>
        /// <returns>Надбавка за классность</returns>
        public static ListGradeAllowance MapListGradeAllowance(this UpdateListGradeAllowanceDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListGradeAllowance
            {
                Id = dto.Id,
                Code = dto.Code,
                Name = dto.Name,
                Percent = dto.Percent,
                Grade = dto.Grade,
                DepartmentId = dto.DepartmentId,
                Flags = GetFlags(dto.UseAllowance)
            };
        }

        /// <summary>
        /// Маппинг надбавки за классность
        /// </summary>
        /// <param name="gradeAllowance">Надбавка за классность</param>
        /// <returns>DTO "Надбавки за классность"</returns>
        public static ListGradeAllowanceDto MapListGradeAllowanceDto(this ListGradeAllowance gradeAllowance)
        {
            if (gradeAllowance == null) throw new NullReferenceException(nameof(gradeAllowance));

            return new ListGradeAllowanceDto
            {
                Id = gradeAllowance.Id,
                Code = gradeAllowance.Code,
                Name = gradeAllowance.Name,
                Percent = gradeAllowance.Percent,
                Grade = gradeAllowance.Grade,
                DepartmentId = gradeAllowance.DepartmentId,
                DepartmentName = gradeAllowance.Department?.Name,
                UseAllowance = (gradeAllowance.Flags & (int)ListGradeAllowanceFlags.NoUse) <= 0
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Надбавки за классность"
        /// </summary>
        /// <param name="gradeAllowances">Запрос последовательности "Надбавки за классность"</param>
        /// <returns>Запрос последовательности DTO "Надбавки за классность"</returns>
        public static IQueryable<ListGradeAllowanceDto> SelectListGradeAllowanceDtos(
            this IQueryable<ListGradeAllowance> gradeAllowances)
        {
            return gradeAllowances.Select(gradeAllowance => new ListGradeAllowanceDto
            {
                Id = gradeAllowance.Id,
                Code = gradeAllowance.Code,
                Name = gradeAllowance.Name,
                Percent = gradeAllowance.Percent,
                Grade = gradeAllowance.Grade,
                DepartmentId = gradeAllowance.DepartmentId,
                DepartmentName = gradeAllowance.Department.Name,
                UseAllowance = (gradeAllowance.Flags & (int)ListGradeAllowanceFlags.NoUse) <= 0
            });
        }

        /// <summary>
        /// Получить флаги надбавки за классность
        /// </summary>
        /// <param name="useAllowance">Флаг применения надбавки</param>
        /// <returns>Флаги надбавки за классность</returns>
        private static int GetFlags(bool useAllowance)
        {
            var flags = 0;
            if (!useAllowance)
                flags += (int)ListGradeAllowanceFlags.NoUse;

            return flags;
        }
    }
}
