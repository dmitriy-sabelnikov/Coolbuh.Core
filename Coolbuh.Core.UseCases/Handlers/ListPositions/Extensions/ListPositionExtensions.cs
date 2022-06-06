using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.UseCases.Handlers.ListPositions.Dto;
using System.Linq;

namespace Coolbuh.Core.UseCases.Handlers.ListPositions.Extensions
{
    public static class ListPositionExtensions
    {
        /// <summary>
        /// Получить запрос последовательности DTO "Должности"
        /// </summary>
        /// <param name="positions">Запрос последовательности "Должности"</param>
        /// <returns>Запрос последовательности DTO "Должности"</returns>
        public static IQueryable<ListPositionDto> SelectListPositionDtos(this IQueryable<ListPosition> positions)
        {
            return positions.Select(position => new ListPositionDto
            {
                Id = position.Id,
                Code = position.Code,
                Name = position.Name
            });
        }
    }
}
