using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Dto;
using Coolbuh.Core.UseCases.Handlers.ListLivingWages.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListLivingWages.Queries.GetListLivingWages
{
    /// <summary>
    /// Обработчик запроса "Получить список прожиточных минимумов"
    /// </summary>
    public class GetListLivingWagesRequestHandler : IRequestHandler<GetListLivingWagesRequest, List<ListLivingWageDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetListLivingWagesRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Прожиточные минимумы"</returns>
        public async Task<List<ListLivingWageDto>> Handle(GetListLivingWagesRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var livingWages = _dbContext.ListLivingWages.SelectListLivingWageDtos();

            return await livingWages.ToListAsync(cancellationToken);
        }
    }
}
