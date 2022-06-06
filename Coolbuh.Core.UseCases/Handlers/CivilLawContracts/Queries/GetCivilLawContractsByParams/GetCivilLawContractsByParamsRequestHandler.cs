using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Dto;
using Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.CivilLawContracts.Queries.GetCivilLawContractsByParams
{
    /// <summary>
    /// Обработчик запроса "Получить список договоров ГПХ"
    /// </summary>
    public class GetCivilLawContractsByParamsRequestHandler
        : IRequestHandler<GetCivilLawContractsByParamsRequest, List<CivilLawContractDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetCivilLawContractsByParamsRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Договор ГПХ"</returns>
        public async Task<List<CivilLawContractDto>> Handle(GetCivilLawContractsByParamsRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));


            var civilLawContracts = _dbContext.CivilLawContracts.AsNoTracking()
                .Where(rec => rec.AccountingPeriod >= request.StartPeriod && rec.AccountingPeriod <= request.EndPeriod
                                                                          && (request.DepartmentId != null &&
                                                                              rec.DepartmentId == request.DepartmentId ||
                                                                              request.DepartmentId == null))
                .SelectCivilLawContractDtos();

            return await civilLawContracts.ToListAsync(cancellationToken);
        }
    }
}
