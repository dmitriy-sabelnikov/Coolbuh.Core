using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.SickLists.Dto;
using Coolbuh.Core.UseCases.Handlers.SickLists.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.SickLists.Queries.GetSickListsByParams
{
    /// <summary>
    /// Обработчик запроса "Получить список больничных листов"
    /// </summary>
    public class GetSickListsByParamsRequestHandler : IRequestHandler<GetSickListsByParamsRequest, List<SickListDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetSickListsByParamsRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Больничный лист"</returns>
        public async Task<List<SickListDto>> Handle(GetSickListsByParamsRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var sickLists = _dbContext.SickLists.AsNoTracking()
                .Where(rec => rec.AccountingPeriod >= request.StartPeriod && rec.AccountingPeriod <= request.EndPeriod
                                                                          && (request.DepartmentId != null &&
                                                                              rec.DepartmentId ==
                                                                              request.DepartmentId ||
                                                                              request.DepartmentId == null))
                .SelectSickListDtos();

            return await sickLists.ToListAsync(cancellationToken);
        }
    }
}
