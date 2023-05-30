using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListPensionAllowances.Queries.GetListPensionAllowances
{
    /// <summary>
    /// Обработчик запроса "Получить список надбавок за пенсию"
    /// </summary>
    public class GetListPensionAllowancesRequestHandler
        : IRequestHandler<GetListPensionAllowancesRequest, List<ListPensionAllowanceDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetListPensionAllowancesRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Надбавки за пенсию льготы"</returns>
        public async Task<List<ListPensionAllowanceDto>> Handle(GetListPensionAllowancesRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var minimumSalaries = _dbContext.ListPensionAllowances.SelectListPensionAllowanceDtos();

            return await minimumSalaries.ToListAsync(cancellationToken);
        }
    }
}
