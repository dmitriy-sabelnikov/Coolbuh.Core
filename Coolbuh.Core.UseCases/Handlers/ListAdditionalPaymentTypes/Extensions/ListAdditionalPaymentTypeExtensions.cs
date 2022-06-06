using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Extensions
{
    /// <summary>
    /// Методы расширения типа дополнительных выплат
    /// </summary>
    public static class ListAdditionalPaymentTypeExtensions
    {
        /// <summary>
        /// Маппинг типа дополнительных выплат
        /// </summary>
        /// <param name="dto">DTO создания "Типы дополнительных выплат"</param>
        /// <returns>Тип дополнительных выплат</returns>
        public static ListAdditionalPaymentType MapListAdditionalPaymentType(this CreateListAdditionalPaymentTypeDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListAdditionalPaymentType
            {
                Code = dto.Code,
                Name = dto.Name
            };
        }

        /// <summary>
        /// Маппинг типа дополнительных выплат
        /// </summary>
        /// <param name="dto">DTO обновления "Типы дополнительных выплат"</param>
        /// <returns>Тип дополнительных выплат</returns>
        public static ListAdditionalPaymentType MapListAdditionalPaymentType(this UpdateListAdditionalPaymentTypeDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListAdditionalPaymentType
            {
                Id = dto.Id,
                Code = dto.Code,
                Name = dto.Name
            };
        }

        /// <summary>
        /// Маппинг типа дополнительных выплат
        /// </summary>
        /// <param name="additionalPaymentType">DTO "Типы дополнительных выплат"</param>
        /// <returns>Тип дополнительных выплат</returns>
        public static ListAdditionalPaymentTypeDto MapListAdditionalPaymentTypeDto(
            this ListAdditionalPaymentType additionalPaymentType)
        {
            if (additionalPaymentType == null) throw new NullReferenceException(nameof(additionalPaymentType));

            return new ListAdditionalPaymentTypeDto
            {
                Id = additionalPaymentType.Id,
                Code = additionalPaymentType.Code,
                Name = additionalPaymentType.Name
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Типы дополнительных выплат"
        /// </summary>
        /// <param name="additionalPaymentTypes">Запрос последовательности "Типы дополнительных выплат"</param>
        /// <returns>Запрос последовательности DTO "Типы дополнительных выплат"</returns>
        public static IQueryable<ListAdditionalPaymentTypeDto> SelectListAdditionalPaymentTypeDtos(
            this IQueryable<ListAdditionalPaymentType> additionalPaymentTypes)
        {
            return additionalPaymentTypes.Select(additionalPaymentType => new ListAdditionalPaymentTypeDto
            {
                Id = additionalPaymentType.Id,
                Code = additionalPaymentType.Code,
                Name = additionalPaymentType.Name
            });
        }
    }
}
