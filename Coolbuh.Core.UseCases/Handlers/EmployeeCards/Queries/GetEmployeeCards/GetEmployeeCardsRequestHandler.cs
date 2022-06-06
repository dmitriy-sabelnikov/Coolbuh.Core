using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Queries.GetEmployeeCards
{
    /// <summary>
    /// Обработчик запроса "Получить карточки работников"
    /// </summary>
    public class GetEmployeeCardsRequestHandler : IRequestHandler<GetEmployeeCardsRequest, List<EmployeeCardDto>>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetEmployeeCardsRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Список DTOs "Карточка работника"</returns>
        public async Task<List<EmployeeCardDto>> Handle(GetEmployeeCardsRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var employeeCards = _dbContext.EmployeeCards.AsNoTracking().SelectEmployeeCardDtos();

            return await employeeCards.ToListAsync(cancellationToken);
        }
    }
}