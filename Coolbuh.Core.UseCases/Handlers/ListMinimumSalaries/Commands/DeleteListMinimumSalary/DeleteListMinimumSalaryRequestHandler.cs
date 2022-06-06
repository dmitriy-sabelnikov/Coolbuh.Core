using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Dto;
using Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListMinimumSalaries.Commands.DeleteListMinimumSalary
{
    /// <summary>
    /// Тестирование команды "Удалить минимальную зарплату"
    /// </summary>
    public class DeleteListMinimumSalaryRequestHandler
        : IRequestHandler<DeleteListMinimumSalaryRequest, ListMinimumSalaryDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteListMinimumSalaryRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Минимальные зарплаты"</returns>
        public async Task<ListMinimumSalaryDto> Handle(DeleteListMinimumSalaryRequest request,
            CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.MinimumSalary == null) throw new NullReferenceException(nameof(request.MinimumSalary));

            var minimumSalary =
                await GetListMinimumSalaryAsync(request.MinimumSalary.Id, cancellationToken);

            _dbContext.ListMinimumSalaries.Remove(minimumSalary);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return minimumSalary.MapListMinimumSalaryDto();
        }

        /// <summary>
        /// Получить минимальную зарплату
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Минимальная зарплата</returns>
        private async Task<ListMinimumSalary> GetListMinimumSalaryAsync(int id, CancellationToken cancellationToken)
        {
            var minimumSalary = await _dbContext.ListMinimumSalaries.AsNoTracking()
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (minimumSalary == null)
                throw new NotFoundEntityUseCaseException($"Відсутня мінімальна зарплата в базі (id: {id})");

            return minimumSalary;
        }
    }
}
