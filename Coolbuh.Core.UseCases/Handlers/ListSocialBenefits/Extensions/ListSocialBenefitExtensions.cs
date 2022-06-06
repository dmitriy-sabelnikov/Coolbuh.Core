using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Dto;
using System;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Extensions
{
    /// <summary>
    /// Методы расширения cоциальной льготы
    /// </summary>
    public static class ListSocialBenefitExtensions
    {
        /// <summary>
        /// Маппинг cоциальной льготы
        /// </summary>
        /// <param name="dto">DTO создания "Социальная льгота"</param>
        /// <returns>Социальная льгота</returns>
        public static ListSocialBenefit MapListSocialBenefit(this CreateListSocialBenefitDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListSocialBenefit
            {
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Sum = dto.Sum,
                LimitSum = dto.LimitSum
            };
        }

        /// <summary>
        /// Маппинг cоциальной льготы
        /// </summary>
        /// <param name="dto">DTO обновления "Социальная льгота"</param>
        /// <returns>Социальная льгота</returns>
        public static ListSocialBenefit MapListSocialBenefit(this UpdateListSocialBenefitDto dto)
        {
            if (dto == null) throw new NullReferenceException(nameof(dto));

            return new ListSocialBenefit
            {
                Id = dto.Id,
                PeriodBegin = dto.PeriodBegin,
                PeriodEnd = dto.PeriodEnd,
                Sum = dto.Sum,
                LimitSum = dto.LimitSum
            };
        }

        /// <summary>
        /// Маппинг cоциальной льготы
        /// </summary>
        /// <param name="socialBenefit">Социальная льгота</param>
        /// <returns>DTO "Социальная льгота"</returns>
        public static ListSocialBenefitDto MapListSocialBenefitDto(this ListSocialBenefit socialBenefit)
        {
            if (socialBenefit == null) throw new NullReferenceException(nameof(socialBenefit));

            return new ListSocialBenefitDto
            {
                Id = socialBenefit.Id,
                PeriodBegin = socialBenefit.PeriodBegin,
                PeriodEnd = socialBenefit.PeriodEnd,
                Sum = socialBenefit.Sum,
                LimitSum = socialBenefit.LimitSum
            };
        }

        /// <summary>
        /// Получить запрос последовательности DTO "Социальные льготы"
        /// </summary>
        /// <param name="socialBenefits">Запрос последовательности "Социальные льготы"</param>
        /// <returns>Запрос последовательности DTO "Социальные льготы"</returns>
        public static IQueryable<ListSocialBenefitDto> SelectListSocialBenefitDtos(this IQueryable<ListSocialBenefit> socialBenefits)
        {
            return socialBenefits.Select(socialBenefit => new ListSocialBenefitDto
            {
                Id = socialBenefit.Id,
                PeriodBegin = socialBenefit.PeriodBegin,
                PeriodEnd = socialBenefit.PeriodEnd,
                Sum = socialBenefit.Sum,
                LimitSum = socialBenefit.LimitSum
            });
        }
    }
}
