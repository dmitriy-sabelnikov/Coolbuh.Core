using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.ListAdministrations.Extensions
{
    /// <summary>
    /// Методы расширения администрации
    /// </summary>
    public static class ListAdministrationExtensions
    {
        /// <summary>
        /// Маппинг администрации
        /// </summary>
        /// <param name="dto">DTO создания "Администрации"</param>
        /// <returns>Администрация</returns>
        public static ListAdministration MapListAdministration(this CreateListAdministrationDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListAdministration
            {
                TaxIdentificationNumber = dto.TaxIdentificationNumber,
                FullName = dto.FullName,
                TelephoneNumber = dto.TelephoneNumber,
                PositionId = dto.PositionId
            };
        }

        /// <summary>
        /// Маппинг администрации
        /// </summary>
        /// <param name="dto">DTO обновления "Администрации"</param>
        /// <returns>Администрация</returns>
        public static ListAdministration MapListAdministration(this UpdateListAdministrationDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListAdministration
            {
                Id = dto.Id,
                TaxIdentificationNumber = dto.TaxIdentificationNumber,
                FullName = dto.FullName,
                TelephoneNumber = dto.TelephoneNumber,
                PositionId = dto.PositionId
            };
        }

        /// <summary>
        /// Маппинг администрации
        /// </summary>
        /// <param name="administration">Администрация</param>
        /// <returns>DTO "Администрации"</returns>
        public static ListAdministrationDto MapListAdministrationDto(this ListAdministration administration)
        {
            if (administration == null) throw new NullReferenceException(nameof(administration));

            return new ListAdministrationDto
            {
                Id = administration.Id,
                TaxIdentificationNumber = administration.TaxIdentificationNumber,
                FullName = administration.FullName,
                TelephoneNumber = administration.TelephoneNumber,
                PositionId = administration.PositionId,
                PositionName = administration.Position?.Name
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Администрации"
        /// </summary>
        /// <param name="administrations">Запрос последовательности "Администрации"</param>
        /// <returns>Запрос последовательности DTO "Администрации"</returns>        
        public static IQueryable<ListAdministrationDto> SelectListAdministrationsDtos(
            this IQueryable<ListAdministration> administrations)
        {
            return administrations.Select(administration => new ListAdministrationDto
            {
                Id = administration.Id,
                TaxIdentificationNumber = administration.TaxIdentificationNumber,
                FullName = administration.FullName,
                TelephoneNumber = administration.TelephoneNumber,
                PositionId = administration.PositionId,
                PositionName = administration.Position.Name
            });
        }
    }
}
