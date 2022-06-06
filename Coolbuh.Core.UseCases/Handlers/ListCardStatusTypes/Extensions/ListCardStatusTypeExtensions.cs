using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.ListCardStatusTypes.Dto;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.ListCardStatusTypes.Extensions
{
    /// <summary>
    /// Методы расширения типа статусов карточки
    /// </summary>
    public static class ListCardStatusTypeExtensions
    {
        /// <summary>
        /// Получить запрос последовательности DTO "Типы статусов карточки"
        /// </summary>
        /// <param name="cardStatusTypes">Запрос последовательности "Типы статусов карточки"</param>
        /// <returns>Запрос последовательности DTO "Типы статусов карточки"</returns>
        public static IQueryable<ListCardStatusTypeDto> SelectListCardStatusTypeDtos(
            this IQueryable<ListCardStatusType> cardStatusTypes)
        {
            return cardStatusTypes.Select(rec => new ListCardStatusTypeDto
            {
                Id = rec.Id,
                Code = rec.Code,
                Name = rec.Name
            });
        }
    }
}
