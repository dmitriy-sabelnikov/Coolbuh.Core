using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListOtherAllowances.Queries.GetListOtherAllowances
{
    /// <summary>
    /// Обработчик запроса "Получить список надбавок"
    /// </summary>
    public class GetListOtherAllowancesRequestHandler
        : IRequestHandler<GetListOtherAllowancesRequest, List<ListOtherAllowanceDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetListOtherAllowancesRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Другие надбавки"</returns>
        public async Task<List<ListOtherAllowanceDto>> Handle(GetListOtherAllowancesRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var otherAllowances = _dbContext.ListOtherAllowances.AsNoTracking().SelectListOtherAllowanceDtos();

            return await otherAllowances.ToListAsync(cancellationToken);
        }
    }
}
