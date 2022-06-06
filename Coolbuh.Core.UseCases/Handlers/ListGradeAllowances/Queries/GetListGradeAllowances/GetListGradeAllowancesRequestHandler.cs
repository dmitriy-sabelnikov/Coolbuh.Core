using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Queries.GetListGradeAllowances
{
    /// <summary>
    /// Обработчик запроса "Получить список надбавок за классность"
    /// </summary>
    public class GetListGradeAllowancesRequestHandler
        : IRequestHandler<GetListGradeAllowancesRequest, List<ListGradeAllowanceDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetListGradeAllowancesRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Надбавки за классность"</returns>
        public async Task<List<ListGradeAllowanceDto>> Handle(GetListGradeAllowancesRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var gradeAllowances = _dbContext.ListGradeAllowances.AsNoTracking().SelectListGradeAllowanceDtos();

            return await gradeAllowances.ToListAsync(cancellationToken);
        }
    }
}
