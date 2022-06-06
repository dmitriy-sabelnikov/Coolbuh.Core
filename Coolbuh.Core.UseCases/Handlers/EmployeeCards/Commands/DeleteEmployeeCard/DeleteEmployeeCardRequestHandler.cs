using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Dto.EmployeeCard;
using Coolbuh.Core.UseCases.Handlers.EmployeeCards.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.EmployeeCards.Commands.DeleteEmployeeCard
{
    /// <summary>
    /// Обработчик команды "Удалить карточку работника"
    /// </summary>
    public class DeleteEmployeeCardRequestHandler
        : IRequestHandler<DeleteEmployeeCardRequest, EmployeeCardDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteEmployeeCardRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Карточка работника"</returns>
        public async Task<EmployeeCardDto> Handle(DeleteEmployeeCardRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.EmployeeCard == null) throw new NullReferenceException(nameof(request.EmployeeCard));

            var employeeCard = await GetEmployeeCardAsync(request.EmployeeCard.Id, cancellationToken);

            _dbContext.EmployeeCards.Remove(employeeCard);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return employeeCard.MapEmployeeCardDto();
        }

        /// <summary>
        /// Получить карточку работника
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Карточка работника</returns>
        private async Task<EmployeeCard> GetEmployeeCardAsync(int id, CancellationToken cancellationToken)
        {
            var employeeCard = await _dbContext.EmployeeCards.AsNoTracking()
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (employeeCard == null)
                throw new NotFoundEntityUseCaseException($"Відсутня картка робітника в базі (id: {id})");

            return employeeCard;
        }
    }
}
