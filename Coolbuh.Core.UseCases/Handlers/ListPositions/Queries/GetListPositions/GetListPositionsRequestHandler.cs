using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListPositions.Dto;
using Coolbuh.Core.UseCases.Handlers.ListPositions.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListPositions.Queries.GetListPositions
{
    /// <summary>
    /// Обработчик запроса "Получить список должностей"
    /// </summary>
    public class GetListPositionsRequestHandler : IRequestHandler<GetListPositionsRequest, List<ListPositionDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetListPositionsRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Должности"</returns>
        public async Task<List<ListPositionDto>> Handle(GetListPositionsRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var positions = _dbContext.ListPositions.AsNoTracking().SelectListPositionDtos();

            return await positions.ToListAsync(cancellationToken);
        }
    }
}