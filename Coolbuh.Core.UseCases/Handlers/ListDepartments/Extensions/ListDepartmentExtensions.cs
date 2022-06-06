using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.ListDepartments.Extensions
{
    /// <summary>
    /// Методы расширения подразделений
    /// </summary>
    public static class ListDepartmentExtensions
    {
        /// <summary>
        /// Маппинг подразделения
        /// </summary>
        /// <param name="dto">DTO создания "Подразделения"</param>
        /// <returns>Подразделение</returns>
        public static ListDepartment MapListDepartment(this CreateListDepartmentDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListDepartment
            {
                Code = dto.Code,
                Name = dto.Name,
            };
        }

        /// <summary>
        /// Маппинг подразделения
        /// </summary>
        /// <param name="dto">DTO обновления "Подразделения"</param>
        /// <returns>Подразделение</returns>
        public static ListDepartment MapListDepartment(this UpdateListDepartmentDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListDepartment
            {
                Id = dto.Id,
                Code = dto.Code,
                Name = dto.Name,
            };
        }

        /// <summary>
        /// Маппинг подразделения
        /// </summary>
        /// <param name="department">Подразделение</param>
        /// <returns>DTO "Подразделения"</returns>
        public static ListDepartmentDto MapListDepartmentDto(this ListDepartment department)
        {
            if (department == null) throw new NullReferenceException(nameof(department));

            return new ListDepartmentDto
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Подразделений"
        /// </summary>
        /// <param name="departments">Запрос последовательности "Подразделений"</param>
        /// <returns>Запрос последовательности DTO "Подразделений"</returns>
        public static IQueryable<ListDepartmentDto> SelectListDepartmentDtos(this IQueryable<ListDepartment> departments)
        {
            return departments.Select(department => new ListDepartmentDto
            {
                Id = department.Id,
                Code = department.Code,
                Name = department.Name
            });
        }
    }
}
