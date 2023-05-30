using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Dto;
using Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListSpecialSeniorities.Queries.GetListSpecialSeniorities
{
    /// <summary>
    /// Обработчик запроса "Получить список спецстажей"
    /// </summary>
    public class GetListSpecialSenioritiesRequestHandler
        : IRequestHandler<GetListSpecialSenioritiesRequest, List<ListSpecialSeniorityDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetListSpecialSenioritiesRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Спецстажи"</returns>
        public async Task<List<ListSpecialSeniorityDto>> Handle(GetListSpecialSenioritiesRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var specialSeniorities = _dbContext.ListSpecialSeniorities.SelectListSpecialSeniorityDtos();

            return await specialSeniorities.ToListAsync(cancellationToken);
        }
    }
}
