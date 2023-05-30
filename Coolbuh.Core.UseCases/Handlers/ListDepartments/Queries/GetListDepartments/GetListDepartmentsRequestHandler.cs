using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Dto;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListDepartments.Queries.GetListDepartments
{
    /// <summary>
    /// Обработчик запроса "Получить список подразделений"
    /// </summary>
    public class GetListDepartmentsRequestHandler : IRequestHandler<GetListDepartmentsRequest, List<ListDepartmentDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetListDepartmentsRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Подразделения"</returns>
        public async Task<List<ListDepartmentDto>> Handle(GetListDepartmentsRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var departments = _dbContext.ListDepartments.SelectListDepartmentDtos();

            return await departments.ToListAsync(cancellationToken);
        }
    }
}
