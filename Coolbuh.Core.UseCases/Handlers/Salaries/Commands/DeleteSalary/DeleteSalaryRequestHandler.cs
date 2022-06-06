using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.Salaries.Dto;
using Coolbuh.Core.UseCases.Handlers.Salaries.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.Salaries.Commands.DeleteSalary
{
    /// <summary>
    /// Обработчик команды "Удалить зарплату"
    /// </summary>
    public class DeleteSalaryRequestHandler : IRequestHandler<DeleteSalaryRequest, SalaryDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteSalaryRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Зарплата"</returns>
        public async Task<SalaryDto> Handle(DeleteSalaryRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Salary == null) throw new NullReferenceException(nameof(request.Salary));

            var salary = await GetSalaryAsync(request.Salary.Id, cancellationToken);

            _dbContext.Salaries.Remove(salary);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return salary.MapSalaryDto();
        }

        /// <summary>
        /// Получить зарплату
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Зарплата</returns>
        private async Task<Salary> GetSalaryAsync(int id, CancellationToken cancellationToken)
        {
            var salary = await _dbContext.Salaries.AsNoTracking()
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (salary == null)
                throw new NotFoundEntityUseCaseException($"Відсутня зарплата в базі (id: {id})");

            return salary;
        }
    }
}
