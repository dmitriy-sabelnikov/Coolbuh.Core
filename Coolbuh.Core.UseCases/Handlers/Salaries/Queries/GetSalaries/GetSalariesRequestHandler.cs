using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.Salaries.Dto;
using Coolbuh.Core.UseCases.Handlers.Salaries.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.Salaries.Queries.GetSalaries
{
    /// <summary>
    /// Обработчик запроса "Получить список зарплат"
    /// </summary>
    public class GetSalariesRequestHandler : IRequestHandler<GetSalariesRequest, List<SalaryDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetSalariesRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Зарплата"</returns>
        public async Task<List<SalaryDto>> Handle(GetSalariesRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var salaries = _dbContext.Salaries.AsNoTracking()
                .Where(rec => rec.AccountingPeriod >= request.StartPeriod && rec.AccountingPeriod <= request.EndPeriod
                                                                          && (request.DepartmentId != null &&
                                                                              rec.DepartmentId ==
                                                                              request.DepartmentId ||
                                                                              request.DepartmentId == null))
                .SelectSalaryDtos();

            return await salaries.ToListAsync(cancellationToken);
        }
    }
}
