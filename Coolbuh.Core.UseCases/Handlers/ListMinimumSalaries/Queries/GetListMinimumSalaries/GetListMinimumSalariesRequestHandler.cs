using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Queries.GetListMinimumSalaries
{
    /// <summary>
    /// Обработчик запроса "Получить список минимальных зарплат"
    /// </summary>
    public class GetListMinimumSalariesRequestHandler
        : IRequestHandler<GetListMinimumSalariesRequest, List<ListMinimumSalaryDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetListMinimumSalariesRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Минимальные зарплаты"</returns>
        public async Task<List<ListMinimumSalaryDto>> Handle(GetListMinimumSalariesRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var minimumSalaries = _dbContext.ListMinimumSalaries.SelectListMinimumSalaryDtos();

            return await minimumSalaries.ToListAsync(cancellationToken);
        }
    }
}
