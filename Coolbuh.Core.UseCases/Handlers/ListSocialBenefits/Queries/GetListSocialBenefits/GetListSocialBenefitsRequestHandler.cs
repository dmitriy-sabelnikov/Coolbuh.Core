using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Dto;
using Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListSocialBenefits.Queries.GetListSocialBenefits
{
    /// <summary>
    /// Обработчик запроса "Получить список социальных льгот"
    /// </summary>
    public class
        GetListSocialBenefitsRequestHandler : IRequestHandler<GetListSocialBenefitsRequest, List<ListSocialBenefitDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetListSocialBenefitsRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Социальные льготы"</returns>
        public async Task<List<ListSocialBenefitDto>> Handle(GetListSocialBenefitsRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var socialBenefits = _dbContext.ListSocialBenefits.AsNoTracking().SelectListSocialBenefitDtos();

            return await socialBenefits.ToListAsync(cancellationToken);
        }
    }
}