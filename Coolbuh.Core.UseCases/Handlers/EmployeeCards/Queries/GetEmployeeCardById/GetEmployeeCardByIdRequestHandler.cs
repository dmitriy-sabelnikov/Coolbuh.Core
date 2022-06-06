using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Queries.GetEmployeeCardById
{
    /// <summary>
    /// Обработчик запроса "Получить карточку работника"
    /// </summary>
    public class GetEmployeeCardByIdRequestHandler : IRequestHandler<GetEmployeeCardByIdRequest, EmployeeCardDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public GetEmployeeCardByIdRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Карточка работника"</returns>
        public async Task<EmployeeCardDto> Handle(GetEmployeeCardByIdRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var employeeCard = _dbContext.EmployeeCards.AsNoTracking().SelectEmployeeCardDtos(request.Id);

            return await employeeCard.FirstOrDefaultAsync(cancellationToken);
        }
    }
}