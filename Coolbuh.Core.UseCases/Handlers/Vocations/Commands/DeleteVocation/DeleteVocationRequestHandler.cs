using Coolbuh.Core.Entities.Models;
using Coolbuh.Core.Infrastructure.Interfaces.DataAccess;
using Coolbuh.Core.UseCases.Exceptions;
using Coolbuh.Core.UseCases.Handlers.Vocations.Dto;
using Coolbuh.Core.UseCases.Handlers.Vocations.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Coolbuh.Core.UseCases.Handlers.Vocations.Commands.DeleteVocation
{
    /// <summary>
    /// Обработчик команды "Удалить отпуск"
    /// </summary>
    public class DeleteVocationRequestHandler : IRequestHandler<DeleteVocationRequest, VocationDto>
    {
        private readonly IDbContext _dbContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="dbContext">DB контекст</param>
        public DeleteVocationRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Обработчик запроса
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>DTO "Отпуск"</returns>
        public async Task<VocationDto> Handle(DeleteVocationRequest request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (request.Vocation == null) throw new InvalidOperationException("request.Vocation is null");

            var vocation = await GetVocationAsync(request.Vocation.Id, cancellationToken);

            _dbContext.Vocations.Remove(vocation);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return vocation.MapVocationDto();
        }

        /// <summary>
        /// Получить отпуск
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Отпуск</returns>
        private async Task<Vocation> GetVocationAsync(int id, CancellationToken cancellationToken)
        {
            var vocation = await _dbContext.Vocations
                .FirstOrDefaultAsync(rec => rec.Id == id, cancellationToken);

            if (vocation == null)
                throw new NotFoundEntityUseCaseException($"Відсутня відпустка в базі (id: {id})");

            return vocation;
        }
    }
}
