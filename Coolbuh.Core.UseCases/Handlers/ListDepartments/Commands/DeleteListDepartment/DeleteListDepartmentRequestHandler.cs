using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Dto;
using Coolbuh.Core.UseCases.Handlers.ListDepartments.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.ListDepartments.Commands.DeleteListDepartment
{
    /// <summary>
    /// Обработчик команды "Удалить подразделение"
    /// </summary>
    public class DeleteListDepartmentRequestHandler
        : IRequestHandler<DeleteListDepartmentRequest, ListDepartmentDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteListDepartmentRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Подразделения"</returns>
        public async Task<ListDepartmentDto> Handle(DeleteListDepartmentRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Department == null) throw new InvalidOperationException("request.Department is null");

            var department = await GetListDepartmentAsync(request.Department.Id, cancellationToken);

            _dbContext.ListDepartments.Remove(department);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return department.MapListDepartmentDto();
        }

        /// <summary>
        /// Получить подразделение
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Подразделение</returns>
        private async Task<ListDepartment> GetListDepartmentAsync(int id, CancellationToken cancellationToken)
        {
            var department = await _dbContext.ListDepartments
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            return department ?? throw new NotFoundEntityUseCaseException($"Відсутній підрозділ в базі (id: {id})");
        }
    }
}
