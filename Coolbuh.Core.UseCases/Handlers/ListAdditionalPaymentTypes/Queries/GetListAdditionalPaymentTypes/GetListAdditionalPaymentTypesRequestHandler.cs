using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Dto;
using Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListAdditionalPaymentTypes.Queries.GetListAdditionalPaymentTypes
{
    /// <summary>
    /// Обработчик запроса "Получить список типов дополнительных выплат"
    /// </summary>
    public class GetListAdditionalPaymentTypesRequestHandler
        : IRequestHandler<GetListAdditionalPaymentTypesRequest, List<ListAdditionalPaymentTypeDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetListAdditionalPaymentTypesRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Типы дополнительных выплат"</returns>
        public async Task<List<ListAdditionalPaymentTypeDto>> Handle(GetListAdditionalPaymentTypesRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var additionalPaymentTypes = _dbContext.ListAdditionalPaymentTypes.AsNoTracking()
                .SelectListAdditionalPaymentTypeDtos();

            return await additionalPaymentTypes.ToListAsync(cancellationToken);
        }
    }
}
