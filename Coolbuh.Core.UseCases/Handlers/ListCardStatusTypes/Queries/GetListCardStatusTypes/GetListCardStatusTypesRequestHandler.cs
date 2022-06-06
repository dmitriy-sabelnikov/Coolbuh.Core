using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListCardStatusTypes.Dto;
using Coolbuh.Core.UseCases.Handlers.ListCardStatusTypes.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListCardStatusTypes.Queries.GetListCardStatusTypes
{
    /// <summary>
    /// Обработчик запроса "Получить список типов статусов карточки"
    /// </summary>
    public class GetListCardStatusTypesRequestHandler
        : IRequestHandler<GetListCardStatusTypesRequest, List<ListCardStatusTypeDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetListCardStatusTypesRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Типы статусов карточки"</returns>
        public async Task<List<ListCardStatusTypeDto>> Handle(GetListCardStatusTypesRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var cardStatusTypes = _dbContext.ListCardStatusTypes.AsNoTracking().SelectListCardStatusTypeDtos();

            return await cardStatusTypes.ToListAsync(cancellationToken);
        }
    }
}