using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Dto;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalAccrualTypes.Queries.GetListAdditionalAccrualTypes
{
    /// <summary>
    /// Обработчик запроса "Получить типы дополнительных начислений"
    /// </summary>
    public class GetListAdditionalAccrualTypesRequestHandler
        : IRequestHandler<GetListAdditionalAccrualTypesRequest, List<ListAdditionalAccrualTypeDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetListAdditionalAccrualTypesRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Типы дополнительных начислений"</returns>
        public async Task<List<ListAdditionalAccrualTypeDto>> Handle(GetListAdditionalAccrualTypesRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var additionalAccrualTypes = _dbContext.ListAdditionalAccrualTypes.AsNoTracking()
                .SelectListAdditionalAccrualTypeDtos();

            return await additionalAccrualTypes.ToListAsync(cancellationToken);
        }
    }
}
