using Coolbuh.Core.Entities.Enums;
using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Extensions
{
    /// <summary>
    /// Методы расширения типа дополнительных начислений
    /// </summary>
    public static class ListAdditionalAccrualTypeExtensions
    {
        /// <summary>
        /// Маппинг типа дополнительных начислений
        /// </summary>
        /// <param name="dto">DTO создания "Типы дополнительных начислений"</param>
        /// <returns>Тип дополнительных начислений</returns>
        public static ListAdditionalAccrualType MapListAdditionalAccrualType(this CreateListAdditionalAccrualTypeDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListAdditionalAccrualType
            {
                Code = dto.Code,
                Name = dto.Name,
                Flags = GetFlags(dto.IsCalculate)
            };
        }

        /// <summary>
        /// Маппинг типа дополнительных начислений
        /// </summary>
        /// <param name="dto">DTO обновления "Типы дополнительных начислений"</param>
        /// <returns>Тип дополнительных начислений</returns>
        public static ListAdditionalAccrualType MapListAdditionalAccrualType(this UpdateListAdditionalAccrualTypeDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListAdditionalAccrualType
            {
                Id = dto.Id,
                Code = dto.Code,
                Name = dto.Name,
                Flags = GetFlags(dto.IsCalculate)
            };
        }

        /// <summary>
        /// Маппинг типа дополнительных начислений
        /// </summary>
        /// <param name="additionalAccrualType">Тип дополнительных начислений</param>
        /// <returns>DTO "Типы дополнительных начислений"</returns>
        public static ListAdditionalAccrualTypeDto MapListAdditionalAccrualTypeDto(
            this ListAdditionalAccrualType additionalAccrualType)
        {
            if (additionalAccrualType == null) throw new NullReferenceException(nameof(additionalAccrualType));

            return new ListAdditionalAccrualTypeDto
            {
                Id = additionalAccrualType.Id,
                Code = additionalAccrualType.Code,
                Name = additionalAccrualType.Name,
                IsCalculate = (additionalAccrualType.Flags & (int)ListAdditionalAccrualTypeFlags.Calculate) > 0
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Типы дополнительных начислений"
        /// </summary>
        /// <param name="additionalAccrualTypes">Запрос последовательности "Типы дополнительных начислений"</param>
        /// <returns>Запрос последовательности DTO "Типы дополнительных начислений"</returns>
        public static IQueryable<ListAdditionalAccrualTypeDto> SelectListAdditionalAccrualTypeDtos(this
            IQueryable<ListAdditionalAccrualType> additionalAccrualTypes)
        {
            return additionalAccrualTypes.Select(additionalAccrualType => new ListAdditionalAccrualTypeDto
            {
                Id = additionalAccrualType.Id,
                Code = additionalAccrualType.Code,
                Name = additionalAccrualType.Name,
                IsCalculate = (additionalAccrualType.Flags & (int)ListAdditionalAccrualTypeFlags.Calculate) > 0
            });
        }

        /// <summary>
        /// Получить флаги типа дополнительных начислений
        /// </summary>
        /// <param name="isCalculate">Включать в расчет</param>
        /// <returns>Флаги</returns>
        private static int GetFlags(bool isCalculate)
        {
            var flags = 0;
            if (isCalculate)
                flags += (int)ListAdditionalAccrualTypeFlags.Calculate;

            return flags;
        }
    }
}
