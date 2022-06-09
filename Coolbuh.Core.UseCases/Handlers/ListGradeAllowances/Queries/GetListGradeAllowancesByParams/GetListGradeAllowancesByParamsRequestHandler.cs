using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Dto;
using Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListGradeAllowances.Queries.GetListGradeAllowancesByParams;

/// <summary>
/// Обработчик запроса "Получить надбавки за классность"
/// </summary>    
public class GetListGradeAllowancesByParamsRequestHandler
    : IRequestHandler<GetListGradeAllowancesByParamsRequest, List<ListGradeAllowanceDto>>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">DB контекст</param>
    public GetListGradeAllowancesByParamsRequestHandler(IDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <summary>
    /// Обработчик запроса
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список DTOs "Надбавки зарплата"</returns>
    public async Task<List<ListGradeAllowanceDto>> Handle(GetListGradeAllowancesByParamsRequest request,
        CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        var gradeAllowances = _dbContext.ListGradeAllowances.Where(rec =>
                rec.DepartmentId == request.DepartmentId && rec.Grade == request.Grade)
            .SelectListGradeAllowanceDtos();

        return await gradeAllowances.ToListAsync(cancellationToken);
    }
}
