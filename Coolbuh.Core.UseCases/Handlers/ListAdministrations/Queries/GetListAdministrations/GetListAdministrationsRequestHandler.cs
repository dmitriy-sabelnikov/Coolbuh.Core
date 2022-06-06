using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Dto;
using Coolbuh.Core.UseCases.Handlers.ListAdministrations.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListAdministrations.Queries.GetListAdministrations
{
    /// <summary>
    /// Обработчик запроса "Получить список администрации"
    /// </summary>
    public class GetListAdministrationsRequestHandler
        : IRequestHandler<GetListAdministrationsRequest, List<ListAdministrationDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetListAdministrationsRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Администрации"</returns>
        public async Task<List<ListAdministrationDto>> Handle(GetListAdministrationsRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var administrations = _dbContext.ListAdministrations.AsNoTracking().SelectListAdministrationsDtos();

            return await administrations.ToListAsync(cancellationToken);
        }
    }
}