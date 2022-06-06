using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Queries.GetListGradeAllowanceByParams
{
    /// <summary>
    /// Обработчик запроса "Получить надбавку за классность"
    /// </summary>    
    public class GetListGradeAllowanceByParamsRequestHandler
        : IRequestHandler<GetListGradeAllowanceByParamsRequest, ListGradeAllowanceDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetListGradeAllowanceByParamsRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Надбавки зарплата"</returns>
        public async Task<ListGradeAllowanceDto> Handle(GetListGradeAllowanceByParamsRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var gradeAllowance = await _dbContext.ListGradeAllowances.FirstOrDefaultAsync(rec =>
                    rec.DepartmentId == request.DepartmentId && rec.Grade == request.Grade,
                cancellationToken: cancellationToken);

            return gradeAllowance?.MapListGradeAllowanceDto();
        }
    }
}
